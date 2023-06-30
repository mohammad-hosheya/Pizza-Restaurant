using Microsoft.AspNetCore.Mvc;

namespace PizzaResturant.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Order()
        {
            var Username = HttpContext.Session.GetString("Username");
            if (Username == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }
    }
}
