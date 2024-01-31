using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaResturant.Models;

namespace PizzaResturant.Controllers
{
    public class AdminController : Controller
    {
        private readonly Context context;
        public AdminController(Context context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {

            var Username = HttpContext.Session.GetString("Username");
            if (Username == null)
            {   
                return RedirectToAction("Login", "Auth");
            }
            var User = context.Users.Find(Username);
            if (User != null && User.AdminFlag ==true)
            {
                return View();
            }
            return RedirectToAction("index", "home");
        }


        [HttpGet]
        public IActionResult Delete()
        {

            var Username = HttpContext.Session.GetString("Username");
            if (Username == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var User = context.Users.Find(Username);
            if (User != null && User.AdminFlag == true)
            {
                ViewBag.options = context.Pizzas.ToList();
                return View();
            }
            return RedirectToAction("index", "home");

        }

        [HttpPost]
        public IActionResult Delete(PizzaModel pizza)
        {
            var recordToDelete = context.Pizzas.Find(pizza.PizzaId);

            var Username = HttpContext.Session.GetString("Username");
            if (Username == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (recordToDelete == null)
            {
                return NotFound();
            }

            context.Pizzas.Remove(recordToDelete);
            context.SaveChanges();

            return RedirectToAction("index","admin");

        }


        [HttpGet]
        public IActionResult Add()
        {
            var Username = HttpContext.Session.GetString("Username");
            if (Username == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var User = context.Users.Find(Username);
            if (User != null && User.AdminFlag == true)
            {
                return View(new PizzaModel()); 
            }
            return RedirectToAction("index", "home");
        }

        [HttpPost]
        public IActionResult Add(PizzaModel pizza)
        {
          
                context.Pizzas.Add(pizza);
                context.SaveChanges();
                return RedirectToAction("Index", "admin");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            ViewBag.options = context.Pizzas.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Edit(PizzaModel pizza)
        {
                context.Pizzas.Update(pizza);
                context.SaveChanges();
                return RedirectToAction("Index" ,"admin");
        }


    }
}
