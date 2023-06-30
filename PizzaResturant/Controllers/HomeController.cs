using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaResturant.Models;
using System.Diagnostics;

namespace PizzaResturant.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context context;
        public HomeController(Context context)
        {
            this.context = context;
        }

        //---------------------------------------------
        public IActionResult Search(string searchTerm)
        {
            var Username = HttpContext.Session.GetString("Username");
            if (Username == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            // Pass the search term to the view for display
            ViewBag.SearchTerm = searchTerm;

            // Perform the search logic and retrieve the results
            var searchResults = context.Pizzas.Where(p => p.Name.Contains(searchTerm)).ToList();

            return View(searchResults);
        }


        //-----------------------------------------

        public IActionResult Index()
        {
           var  Username = HttpContext.Session.GetString("Username");
           if(Username ==null)
            {
                return RedirectToAction("Login","Auth");
            }
            var pizzas= context.Pizzas.ToList();
            return View(pizzas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}