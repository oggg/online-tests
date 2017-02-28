using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineTest.Web.Models;

namespace OnlineTest.Web.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        [HttpGet]
        public ActionResult Solve(int testId, int question)
        {
            var currentUserId = User.Identity.GetUserId();
            var currentTestCacheKey = currentUserId + testId;
            var currentTest = (TestCacheModel)this.HttpContext.Cache[currentTestCacheKey];

            var currentQuestion = currentTest.Questions[currentTest.QuestionIndex];

            return View(currentQuestion);
        }
    }
}