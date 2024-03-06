using Cuba_Staterkit.Models;
using Cuba_Staterkit.RepoServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cuba_Staterkit.Controllers
{
    [Authorize]
    public class PublishedController : Controller
    {
        private readonly IClassSession _session;
        private readonly IQuiz _Quiz;

        public PublishedController(IClassSession session,IQuiz quiz)
        {
            _session= session;
            _Quiz = quiz; 
        }
        public IActionResult GetAllZ()
        {
            List<Session> sessions = _session.GetAll();

            return View(sessions);
        }
    }
}
