using Cuba_Staterkit.Models;
using Cuba_Staterkit.RepoServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;
using System.Text.Json.Nodes;
using static System.Collections.Specialized.BitVector32;

namespace Cuba_Staterkit.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestion Question;
        private readonly IToastNotification toastNotification;
        private readonly IWebHostEnvironment _environment;

        public QuestionController(IQuestion question, IToastNotification _toastNotification, IWebHostEnvironment environment)
        {
            Question = question;
            toastNotification = _toastNotification;
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> formData)
        {
            try
            {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                var filePaths = new Dictionary<string, string>();
                foreach (var formFile in Request.Form.Files)
                {
                    if (formFile.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(formFile.FileName);
                        var filePath = Path.Combine(uploads, fileName);
                        string name = formFile.Name;

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }

                        filePaths.Add(name, filePath);
                    }
                }
                return Ok(filePaths);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] QuestionUploadVM data)
        {
            if (ModelState.IsValid)
            {
                Guid firstQuestionId = Guid.NewGuid();
                for (int i = 0; i < data.questions.Count; i++)
                {
                    StringBuilder correctAnswerStr = new StringBuilder();
                    List<string> correctAnswerURL = new List<string>();
                    foreach (var item in data.filePaths)
                    {
                        if (item.Key.Contains("bodyImage_") && item.Key[item.Key.Length - 1].ToString() != (i).ToString())
                            break;
                        if (item.Key != ("bodyImage_" + i))
                        {
                            correctAnswerURL.Add(item.Value);
                            correctAnswerStr.Append(item.Value);
                            correctAnswerStr.Append(",");
                            data.filePaths.Remove(item.Key);
                        }
                    }
                    string? answersUrl = correctAnswerStr.ToString().TrimEnd(',') == "" ? null : correctAnswerStr.ToString().TrimEnd(',');
                    string? correctAnswerUrl = correctAnswerStr.Length <= 0 ? null : correctAnswerURL[data.questions[i].CorrectAnswerIndex];
                    string? imgUrl = data.filePaths.GetValueOrDefault("bodyImage_" + i);
                    Console.WriteLine(imgUrl);
                    Question question = new Question()
                    {
                        ID = (i == 0) ? firstQuestionId : Guid.NewGuid(),
                        Body = data.questions[i].Body,
                        ImgUrl = data.filePaths.GetValueOrDefault("bodyImage_" + i),
                        Answers = string.Join(",", data.questions[i].Answers),
                        AnswersURL = answersUrl,
                        CorrectAnswerUrl = correctAnswerUrl,
                        CorrectAnswer = data.questions[i].CorrectAnswer,
                        QuestionType = Questiontype.String,
                        AnswerType = Questiontype.String,
                        QuizID = new Guid(data.questions[i].QuizID),
                        VersionID = firstQuestionId.ToString(),
                    };
                    Question.InsertQuestion(question);
                    data.filePaths.Remove("bodyImage_" + i);
                }
            }
            toastNotification.AddSuccessToastMessage("Questions Added Successfully");
            return RedirectToAction("CreateQuiz", "Assesment");
        }

        [HttpPost]
        public ActionResult CreateHomework([FromBody] List<QuestionHomeworkViewModel> questions)
        {
            if (ModelState.IsValid)
            {
                // Generate a GUID for the first question
                Guid firstQuestionId = Guid.NewGuid();

                // Process the received questions (e.g., save to the database)
                for (int i = 0; i < questions.Count; i++)
                {
                    Question question = new Question()
                    {
                        ID = (i == 0) ? firstQuestionId : Guid.NewGuid(), // Generate a new GUID for each question
                        Body = questions[i].Body,
                        ImgUrl = questions[i].ImgUrl,
                        Answers = string.Join(",", questions[i].Answers),
                        CorrectAnswer = questions[i].CorrectAnswer,
                        QuestionType = Questiontype.String,
                        AnswerType = Questiontype.String,
                        HomeWorkID = new Guid(questions[i].HomeworkId),
                        VersionID = firstQuestionId.ToString(), // Set VersionID to the ID of the first question for all questions
                    };

                    Question.InsertQuestion(question);
                }
            }
            return RedirectToAction("CreateHomework", "Assesment");
        }

        public ActionResult EditQuestions(string id)
        {
            var questions = Question.GetQuestionById(id).ToList();
            return View(questions);
        }

        [HttpPost]
        public IActionResult DeleteQuestion([FromBody] DeleteQuestionRequest request)
        {

            try
            {
                Question.DeleteQuestion(request.Id);
                return Json(new { success = true, redirectUrl = Url.Action("EditQuestions", "Question", new { id = request.QuizId }) });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw; 
            }
        }
       
        public IActionResult DeleteVersion(Guid id,Guid quizId)
        {
            Question.DeleteQuestion(id);
            return RedirectToAction("EditQuestions", "Question", new { id = quizId });
        }
    }
}
