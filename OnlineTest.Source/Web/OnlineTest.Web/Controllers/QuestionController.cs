using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineTest.Web.Models;

namespace OnlineTest.Web.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        [HttpGet]
        public ActionResult Solve(int testId)
        {
            var currentUserId = User.Identity.GetUserId();
            var currentTestCacheKey = currentUserId + testId;
            var currentTest = (TestCacheModel)this.HttpContext.Cache[currentTestCacheKey];
            
            var currentQuestion = currentTest.Questions[currentTest.QuestionIndex];
            
            var currentQuestionView = new QuestionViewModel()
            {
                Answers = currentQuestion.Answers,
                Description = currentQuestion.Description,
                Id = currentQuestion.Id,
                Text = currentQuestion.Text,
                TestId = testId,
                IsFirst = currentTest.QuestionIndex == 0 ? true : false,
                IsLast = currentTest.QuestionIndex == currentTest.Questions.Count - 1 ? true : false
            };
            
            return View(currentQuestionView);
        }

        //[HttpPost]
        //public ActionResult Solve()
        //{
        //    var currentUserId = User.Identity.GetUserId();
        //    var currentTestCacheKey = currentUserId + testId;
        //    var currentTest = (TestCacheModel)this.HttpContext.Cache[currentTestCacheKey];

        //    var currentQuestion = currentTest.Questions[currentTest.QuestionIndex];
        //    var currentQuestionView = new QuestionViewModel()
        //    {
        //        Answers = currentQuestion.Answers,
        //        Description = currentQuestion.Description,
        //        Id = currentQuestion.Id,
        //        Text = currentQuestion.Text,
        //        IsFirst = question == 0 ? true : false,
        //        IsLast = question == currentTest.Questions.Count - 1 ? true : false
        //    };

        //    return View(currentQuestionView);
        //}
    }
}