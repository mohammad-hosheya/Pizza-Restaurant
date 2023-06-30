using Microsoft.AspNetCore.Mvc;
using PizzaResturant.Models;

namespace PizzaResturant.Controllers
{
    public class AuthController : Controller
    {
        private readonly Context context;
        public AuthController(Context context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            string usermane = HttpContext.Session.GetString("Username");
            ViewBag.Usermane = usermane;

            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            var Username = HttpContext.Session.GetString("Username");
            if (Username != null)
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthModel User)
        {
            var Username = HttpContext.Session.GetString("Username");
            if (Username != null)
            {
                return RedirectToAction("index", "home");
            }

            var user = context.Users.Find(User.Username);
            if (user != null && user.AdminFlag == true)
            {
                HttpContext.Session.SetString("Username", User.Username);
                return RedirectToAction("index", "admin");
            }

            if (user != null && user.Password == User.Password)
            {
                HttpContext.Session.SetString("Username",User.Username);
                return RedirectToAction("index", "home");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Signup() {

            var Username = HttpContext.Session.GetString("Username");
            if (Username != null)
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Signup(AuthModel User)
        {

            var Username = HttpContext.Session.GetString("Username");
            if (Username != null)
            {
                return RedirectToAction("index", "home");
            }

            var isUser = context.Users.Find(User.Username);
            if(isUser == null)
            {
                var user = new UserModel { Username = User.Username, Password = User.Password, AdminFlag = false };
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("index", "home");
            };
            return View();
        }
    }
}    
