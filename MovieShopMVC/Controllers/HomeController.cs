﻿using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // action methods inside the controller

        [HttpGet] // this specifies which http method
        public IActionResult Index()
        {
            // home page
            // top 30 higest grossing movies
            // go to db and get 30 movies
            // List<Movies> in C#, which we need to send to the view
            // we need to send the model data to the view (the List<Movies>)
            // passing data from controller/action methods to views, through C# models

            var movieService = new MovieService();
            var movieCards = movieService.GetTopRevenueMovies();
            
            return View(movieCards);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TopRatedMovies()
        {
            // return View("Privacy"); to return the specific view with the name in the parenthesis
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}