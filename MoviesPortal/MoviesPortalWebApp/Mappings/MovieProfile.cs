﻿using AutoMapper;
using BusinessLogic.ApiHandler.ApiModels;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using MoviesPortalWebApp.AssigmentsVM;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.Mappings
{
    public class MovieProfile : Profile
    {

        public MovieProfile()
        {
            CreateMap<MovieModel, MovieVM>();
            CreateMap<MovieGenre, MovieGenreVM>();
            CreateMap<GenreModel, GenreVM>();
            CreateMap<CreativePersonModel, CreativePersonVM>().ReverseMap();
            CreateMap<RoleModel, RoleVM>();
            CreateMap<Movie_CreativeP_Role, RoleCreativeMovieVM>()
                //.ForMember(d => d.Id, o=>o.MapFrom(s => s.MovieId))
                .ReverseMap();            
            CreateMap<CreativePersonModel, CreativePersonVM>();
            CreateMap<CommentModel, CommentVM>()
                .ForMember(l => l.UserLogin, o => o.MapFrom(s => s.ApplicationUser.UserName)).ReverseMap();

            //Api Mappings

            CreateMap<Genre, GenreVM>()
                .ForMember(d => d.Genre, o => o.MapFrom(s => s.Name)).ReverseMap();

            CreateMap<Cast, CreativePersonVM>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name.Split(' ', ' ').First()))
                .ForMember(d => d.SurName, o => o.MapFrom(s => s.Name.Split(' ', ' ').Last()))
                .ForMember(d => d.PhotographyPath, o => o.MapFrom(s => s.Profile_Path)).ReverseMap()
                ;

            CreateMap<PersonDetails, CreativePersonVM>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name.Split(' ', ' ').First()))
                .ForMember(d => d.SurName, o => o.MapFrom(s => s.Name.Split(' ', ' ').Last()))
                .ForMember(d => d.PhotographyPath, o => o.MapFrom(s => "https://image.tmdb.org/t/p/w600_and_h900_bestv2" + s.Profile_Path))
                .ForMember(d => d.DateOfBirth, o => o.MapFrom(s => DateTime.Parse(s.Birthday)))
                .ForMember(d => d.Biography, o => o.MapFrom(s => s.Biography));


            CreateMap<Crew, CreativePersonVM>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name.Split(' ', ' ').First()))
                .ForMember(d => d.SurName, o => o.MapFrom(s => s.Name.Split(' ', ' ').Last()))
                .ForMember(d => d.PhotographyPath, o => o.MapFrom(s => s.Profile_Path)).ReverseMap();


            CreateMap<Movie, MovieVM>()
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.ProductionYear, o => o.MapFrom(s => s.Release_Date.Substring(0, 4)))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Overview))
                .ForMember(d => d.PosterPath, o => o.MapFrom(s => "https://image.tmdb.org/t/p/w600_and_h900_bestv2" + s.Poster_Path))
                .ForMember(d => d.BackgroundPoster, o => o.MapFrom(s => "https://image.tmdb.org/t/p/w600_and_h900_bestv2" + s.Backdrop_Path))
                .ForMember(d => d.ImdbRatio, o => o.MapFrom(s => s.Vote_Average.ToString()))
                .ForMember(d => d.IsForKids, o => o.MapFrom(s => !s.Adult))
                .ForMember(d => d.Genres, o => o.MapFrom(s => s.Genres)).ReverseMap()
                ;

                
                
        }
               
    }
}
