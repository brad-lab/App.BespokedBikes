using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace App.BespokedBikes.Presentation.Home
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}