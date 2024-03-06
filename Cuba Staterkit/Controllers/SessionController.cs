using Microsoft.AspNetCore.Mvc;

namespace Cuba_Staterkit.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
