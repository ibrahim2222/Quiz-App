using Cuba_Staterkit.Models;
using Cuba_Staterkit.RepoServices;
using Microsoft.AspNetCore.Mvc;

namespace Cuba_Staterkit.Controllers
{
    public class SessionController : Controller
    {
        private readonly IClassSession Session;

        public SessionController(IClassSession session)
        {
            Session = session;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditSessionName([FromBody] SessionVM sessionInfo)
        {
            bool exist = Session.SessionExists(sessionInfo.SessionNumber,sessionInfo.GradeLevel);

            if(exist)
            {
                return Json(new { success = false }); 
            }
            Session.ChangeSessionName(sessionInfo.SessionNumber, sessionInfo.SessionId);
            return Json(new { success = true }); 
        }

    }
}
