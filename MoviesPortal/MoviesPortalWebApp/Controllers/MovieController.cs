﻿using AutoMapper;
using BusinessLogic.ApiHandler;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesPortalWebApp.Models;
using MoviesPortalWebApp.ServicesForControllers;

namespace MoviesPortalWebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        private readonly IGenreService _genreService;
        private readonly ICreativePersonService _creativePersonService;
        private readonly ICommentService _commentService;
        private readonly PersonsAgregator _personAgregator;
        private readonly CommentsPicker _commentPicker;
        private readonly RatingsFormatter _ratings;
        private ApiClient client = new();


        public MovieController(IMovieService movieService, IMapper mapper, IGenreService genreService, ICreativePersonService creativePersonService, PersonsAgregator personAgregator, ICommentService commentService, CommentsPicker commentPicker, RatingsFormatter ratings)
        {
            _movieService = movieService;
            _mapper = mapper;
            _genreService = genreService;
            _creativePersonService = creativePersonService;
            _personAgregator = personAgregator;
            _commentService = commentService;
            _commentPicker = commentPicker;
            _ratings = ratings;
        }

        #region User

        #region User movies list
        public async Task<IActionResult> IndexUser(string genre)
        {
            var model = _movieService.GetAllMovies();
            var movies = _mapper.Map<IList<MovieVM>>(model);
            var moviesFromApi = await client.GetTrendingMoviesOfTheDay();
            var moviesMapped = _mapper.Map<IList<MovieVM>>(moviesFromApi);
            var newMovies = movies.Concat(moviesMapped).DistinctBy(m => m.Title).ToList();

            var newMoviesAndSubscription = new MoviesAndSubscriptionVM();
            newMoviesAndSubscription.Movies = newMovies;

            return View(newMoviesAndSubscription);
        }
        #endregion

        #region User movie details
        public async Task<IActionResult> DetailsUser(int id)
        {
            dynamic model;

            if (_movieService.GetAllMovies().Any(m => m.Id == id))
            {
                model = await _movieService.GetMovieIdByAsync(id);
            }
            else
            {
                model = await client.GetMovieDetails(id);
            }

            MovieVM movie = _mapper.Map<MovieVM>(model);
            ViewBag.Directors = await _personAgregator.GetPersonsForMovie(movie, BusinessLogic.Enums.CastOrCrewPicker.Crew);
            ViewBag.Actors = await _personAgregator.GetPersonsForMovie(movie, BusinessLogic.Enums.CastOrCrewPicker.Cast);

            if (id > 1000)
            {
                var providersStore = await client.GetProviders(id, BusinessLogic.ApiHandler.ApiModels.ContentProvidersClasses.ProviderPicker.PL);

                if (providersStore != null)
                {
                    var providers = providersStore.Flatrate;
                    ViewBag.Providers = _mapper.Map<List<ProviderVM>>(providers);
                }

                var imdb_id = int.Parse(movie.Imdb_Id.Substring(2));
                
                ViewBag.Ratings = await _ratings.GetFormattedRatingsForMovieAsync(imdb_id, movie.ImdbRatio);

            }
            else
            {
                List<string> ratings = new List<string>() { movie.ImdbRatio, "N/A", "N/A"};
                ViewBag.Ratings = ratings;
            }
            CommentsPicker commentsPicker = new();
            movie.Comments = await _commentPicker.GetCommentsAsync(movie.Id);
            return View(movie);
        }
        #endregion

        #endregion

        #region Admin

        #region Admin movies list
        public async Task<IActionResult> Index()
        {
            var model = _movieService.GetAllMovies();
            var movies = _mapper.Map<IList<MovieVM>>(model);
            return View(movies);
        }
        #endregion

        #region Admin movie details
        public async Task<IActionResult> Details(int? id)
        {
            var model = await _movieService.GetMovieIdByAsync(id);
            var movie = _mapper.Map<MovieVM>(model);
            return View(movie);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            MovieVM model = new();
            //model.Genres = await _genreService.GetAllGenresAsStrings();


            List<int> genresIds = new List<int>();
            List<int> actorsIds = new List<int>();
            var genres = await _genreService.GetAllGenres();
            var persons = await _creativePersonService.GetAllCreativePersons();

            var movie = new MovieModel();
            model = _mapper.Map<MovieVM>(movie);
            model.selectedGenres = genres
               .Select(x => new SelectListItem { Text = x.Genre, Value = x.Id.ToString() }).ToList();
            model.selectedActors = persons
               .Select(x => new SelectListItem { Text = string.Format("{0} {1}", x.Name, x.SurName), Value = x.Id.ToString() }).ToList();
            model.selectedDirectors = persons
               .Select(x => new SelectListItem { Text = string.Format("{0} {1}", x.Name, x.SurName), Value = x.Id.ToString() }).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieVM model)
        {
            MovieModel movie = new MovieModel();
            List<MovieGenre> movieGenres = new List<MovieGenre>();
            List<Movie_CreativeP_Role> movieActorsRole = new List<Movie_CreativeP_Role>();

            movie.Title = model.Title;
            movie.Description = model.Description;
            movie.ProductionYear = model.ProductionYear;
            movie.PosterPath = model.PosterPath;
            movie.TrailerUrl = model.TrailerUrl;
            movie.BackgroundPoster = model.BackgroundPoster;
            movie.ImdbRatio = model.ImdbRatio;
            movie.IsForKids = model.IsForKids;

            if (model.GenresIds.Length > 0)
            {

                foreach (var genreId in model.GenresIds)
                {
                    movieGenres.Add(new MovieGenre { GenreId = genreId, MovieId = model.Id });
                }

                movie.MovieGenres = movieGenres;
            }

            if (model.ActorsIds.Length > 0)
            {
                foreach (var actorId in model.ActorsIds)
                {
                    movieActorsRole.Add(new Movie_CreativeP_Role { CreativePersonId = actorId, MovieId = model.Id, RoleId = 1 });
                }

                foreach (var drId in model.DirectorsIds)
                {
                    movieActorsRole.Add(new Movie_CreativeP_Role { CreativePersonId = drId, MovieId = model.Id, RoleId = 2 });
                }

                movie.RoleCreativeMovie = movieActorsRole;
            }

            await _movieService.CreateNewMovie(movie);

            return RedirectToAction("Index");
        }

        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int? Id)
        {
            MovieVM model = new MovieVM();
            List<int> genresIds = new List<int>();
            List<int> actorsIds = new List<int>();
            List<int> directorsIds = new List<int>();
            var genres = await _genreService.GetAllGenres();
            var persons = await _creativePersonService.GetAllCreativePersons();

            if (Id.HasValue)
            {
                // get movie              
                var movie = await _movieService.GetMovieIdByAsync(Id);

                // get movie genres and add each genresIds into genresIds list
                movie.Genres.ToList().ForEach(x => genresIds.Add(x.Id));
                movie.RoleCreativeMovie.Where(d => d.Role.RoleName == "Actor").ToList().ForEach(x => actorsIds.Add(x.CreativePersonId));
                movie.RoleCreativeMovie.Where(d => d.Role.RoleName == "Director").ToList().ForEach(x => directorsIds.Add(x.CreativePersonId));

                var vm = _mapper.Map<MovieVM>(movie);

                //bind model 
                model.selectedGenres = genres
                        .Select(x => new SelectListItem { Text = x.Genre, Value = x.Id.ToString() }).ToList();

                model.selectedActors = persons
                        .Select(x => new SelectListItem { Text = string.Format("{0} {1}", x.Name, x.SurName), Value = x.Id.ToString() }).ToList();

                model.selectedDirectors = persons
                        .Select(x => new SelectListItem { Text = string.Format("{0} {1}", x.Name, x.SurName), Value = x.Id.ToString() }).ToList();


                model.Id = vm.Id;
                model.Title = vm.Title;
                model.Description = vm.Description;
                model.ProductionYear = vm.ProductionYear;
                model.PosterPath = vm.PosterPath;
                model.TrailerUrl = vm.TrailerUrl;
                model.IsForKids = vm.IsForKids;
                model.GenresIds = genresIds.ToArray();
                model.ActorsIds = actorsIds.ToArray();
                model.DirectorsIds = directorsIds.ToArray();

            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieVM model)
        {
            MovieModel Movie = await _movieService.GetMovieIdByAsync(model.Id);
            var oldMovieGenres = Movie.Genres.ToList();
            var oldMovieActors = Movie.RoleCreativeMovie.Where(x => x.Role.RoleName == "Actor").ToList();
            var oldMovieDirectors = Movie.RoleCreativeMovie.Where(x => x.Role.RoleName == "Director").ToList();


            if (model.Id > 0)
            {
                //_context.Movie_Genre.RemoveRange(movieGenres);
                //_context.Role_CreativeP_Movie.RemoveRange(movieActors);
                //_context.Role_CreativeP_Movie.RemoveRange(movieDirectors);
                //_context.SaveChanges();

                Movie.Title = model.Title;
                Movie.Id = model.Id;
                Movie.Description = model.Description;
                Movie.ProductionYear = model.ProductionYear;
                Movie.PosterPath = model.PosterPath;
                Movie.TrailerUrl = model.TrailerUrl;
                Movie.IsForKids = model.IsForKids;

                if (model.GenresIds.Length > 0)
                {

                    List<MovieGenre> movieGenres = new List<MovieGenre>();

                    foreach (var genreId in model.GenresIds)
                    {
                        movieGenres.Add(new MovieGenre { GenreId = genreId, MovieId = model.Id });
                    }

                    Movie.MovieGenres = movieGenres;
                }

                if (model.ActorsIds.Length > 0)
                {

                    List<Movie_CreativeP_Role> movieActors = new List<Movie_CreativeP_Role>();

                    foreach (var actId in model.ActorsIds)
                    {
                        movieActors.Add(new Movie_CreativeP_Role { CreativePersonId = actId, MovieId = model.Id, RoleId = 1 });
                    }

                    foreach (var drId in model.DirectorsIds)
                    {
                        movieActors.Add(new Movie_CreativeP_Role { CreativePersonId = drId, MovieId = model.Id, RoleId = 2 });
                    }

                    Movie.RoleCreativeMovie = movieActors;

                }
                //_context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        // GET: MovieController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _movieService.GetMovieIdByAsync(id);
            var movie = _mapper.Map<MovieVM>(model);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: MovieController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieService.DeleteMovieByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #endregion

    }
}
