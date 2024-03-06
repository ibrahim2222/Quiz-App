using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cuba_Staterkit.Controllers
{
    public class DashboardController : Controller
    {
        // GET: DashboardController
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
