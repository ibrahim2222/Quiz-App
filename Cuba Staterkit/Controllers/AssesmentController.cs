using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Cuba_Staterkit.Controllers
{
    [Authorize]
    public class AssesmentController : Controller
    {
        public IActionResult AssesmentForm()
        {
            return View();
        }

        public IActionResult GradeLevelForm()
        {
            return View();
        }
        public IActionResult CreateQuiz(Guid id)
        {
            // Read the value of the cookie
            // string quizId = Request.Cookies["quizId"];
            //Hello
            // ViewBag.QuizId = id;
            return View(id);
        }
        
        public IActionResult CreateHomework()
        {
            // Read the value of the cookie
            string homeworkId = Request.Cookies["homeworkId"];

            ViewBag.HomeworkId = homeworkId;
            return View();
        }
    }
}
