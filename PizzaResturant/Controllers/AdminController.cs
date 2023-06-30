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


        public IActionResult Delete(int id)
        {
            var recordToDelete = context.Pizzas.Find(id);

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
    }
}
