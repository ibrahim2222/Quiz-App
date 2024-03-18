using Cuba_Staterkit.Models;
using Cuba_Staterkit.RepoServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Net;

namespace Cuba_Staterkit.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private readonly IQuiz Quiz;
        private readonly IClassSession _session;
        private readonly IToastNotification toastNotification;


        public QuizController(IQuiz quiz, IClassSession session, IToastNotification _toastNotification)
        {
            Quiz = quiz;
            _session = session;
            toastNotification = _toastNotification;
        }

        [HttpGet]
        public IActionResult AllQuizes()
        {
            List<Quiz> Quizes = Quiz.GetAll();
            string GradeNum = HttpContext.Request.Query["Grade"];
            ViewBag.Grade = GradeNum;
            ViewBag.lastSessionNumber = _session.GetLastSessionNumber(GradeNum);
            return View(Quizes);
        }

        [HttpPost]
        public IActionResult CreateQuiz(ClassSessionVm classSession)
        {
            bool sessionExists = _session.SessionExists(classSession.SessionNumber,classSession.GradeLevel);

            if (sessionExists)
            {
                // Session already exists, return JSON response
                return Json(new { sessionExists = true });
            }
            else
            {
                Session session = new Session() { ID = Guid.NewGuid(), Name = "Default", SessionNumber = classSession.SessionNumber,GradeLvl= classSession.GradeLevel };
                _session.InsertSession(session);

                Quiz quiz = new Quiz() { Id = Guid.NewGuid(), Name = classSession.QuizName, SessionID = session.ID, GradeLvl = classSession.GradeLevel };
                Quiz.InsertQuiz(quiz);

                //Response.Cookies.Append("quizId", quiz.Id.ToString(), new CookieOptions
                //{
                //    Expires = DateTime.Now.AddDays(1)
                //});
                toastNotification.AddSuccessToastMessage("Session / Quiz Added");

                // Session doesn't exist, return JSON response
                return Json(new { sessionExists = false });
            }
        }

        public IActionResult Check(Guid id)
        {
            bool questionsExists = Quiz.QuizQuestionsExist(id);

            if(questionsExists)
            {
                return RedirectToAction("EditQuestions","Question",new {id =id});
            }  
            else
            {
                return RedirectToAction("CreateQuiz", "Assesment", new {id = id});
            }
        }
        public void DeleteQuiz(Guid Id)
        {
            _session.DeleteSession(Id);
        }

        [HttpPost]
        public IActionResult EditQuizName([FromBody] QuizVM quizInfo)
        {
            Quiz.ChangeQuizName(quizInfo.QuizName, quizInfo.QuizId);
            return Json(new { success = true }); // Return JSON response
        }

    }
}