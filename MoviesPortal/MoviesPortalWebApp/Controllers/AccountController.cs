﻿using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesPortalWebApp.Models;
using System.Security.Claims;

namespace MoviesPortalWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly MoviePortalContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, MoviePortalContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Index(string id)
        {
            var movies = from m in _context.UserFavourities.Include(x => x.Movie)
                         select m;
            movies = movies.Where(s => s.UserId == id);
            
            return View(await movies.ToListAsync());
        }

        public async Task<IActionResult> AddMovieToFavourities(int? id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var fMovie = new UserFavourities();
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);

            fMovie.UserId = userId;
            fMovie.MovieId = movie.Id;

            _context.UserFavourities.Add(fMovie);
            await _context.SaveChangesAsync();

            return RedirectToAction("IndexUser", "Movie");
        }

        public async Task<IActionResult> RemoveMovieToFavourities(int? id)
        {
            var movie = _context.UserFavourities.FirstOrDefault(x => x.Id == id);
            _context.UserFavourities.Remove(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction("IndexUser", "Movie");
        }


        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }


        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRole.User);

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }



    }
}
