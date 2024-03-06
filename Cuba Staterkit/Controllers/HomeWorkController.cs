//using Cuba_Staterkit.Models;
//using Cuba_Staterkit.RepoServices;
//using Microsoft.AspNetCore.Mvc;

//namespace Cuba_Staterkit.Controllers
//{
//    public class HomeWorkController : Controller
//    {
//        private readonly IHomeWork _homework;
//        private readonly IClassSession _session;

//        public HomeWorkController(IHomeWork homework, IClassSession session)
//        {
//            _homework = homework;
//            _session = session;
//        }

//        [HttpGet]
//        public IActionResult AllHomeworks()
//        {
//            List<HomeWork> homeWorks = _homework.GetAll();

//            return View(homeWorks);
//        }

//        [HttpPost]
//        public IActionResult CreateHomework(ClassSessionVm classSession)
//        {
//            // dealing with session in creation of quiz
//            bool sessionExists = _session.SessionExists(classSession.SessionName.ToLower());
//            Session session;
//            if (sessionExists)
//            {
//                session = _session.GetSessionByName(classSession.SessionName);
//            }
//            else
//            {
//                session = new Session() { ID = new Guid(), Name = classSession.SessionName.ToLower() };
//                _session.InsertSession(session);
//            }

//            HomeWork homework = new HomeWork() { Id = new Guid(), Name = classSession.HomeworkName, SessionID = session.ID };
//            _homework.InsertHomeWork(homework);

//            // Create a new cookie
//            Response.Cookies.Append("homeworkId", homework.Id.ToString(), new CookieOptions
//            {
//                Expires = DateTime.Now.AddDays(1)
//            });
//            //return View(homework);
//            return RedirectToAction("CreateHomework", "Assesment");
//        }
//    }
//}
