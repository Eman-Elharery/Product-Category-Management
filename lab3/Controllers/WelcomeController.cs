using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
