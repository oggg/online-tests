using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineTest.Web.Models;
using System;
using System.Web.Caching;
using System.Web.Routing;
using OnlineTest.Services.Contracts;
using OnlineTest.Models;

namespace OnlineTest.Web.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IScoreService scores;

        public QuestionController(IScoreService scores)
        {
            this.scores = scores;
        }

        [HttpGet]
        public ActionResult Solve(int testId)
        {
            string currentUserId = User.Identity.GetUserId();
            string currentTestCacheKey = currentUserId + testId;
            TestCacheModel currentTest = (TestCacheModel)this.HttpContext.Cache[currentTestCacheKey];
            
            var currentQuestion = currentTest.Questions[currentTest.QuestionIndex];

            QuestionViewModel currentQuestionView = new QuestionViewModel()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Solve(QuestionPostModel model)
        {
            string currentUserId = User.Identity.GetUserId();
            int currentTestId = model.TestId;
            string currentTestCacheKey = currentUserId + currentTestId;

            TestCacheModel currentTest = (TestCacheModel)this.HttpContext.Cache[currentTestCacheKey];

            QuestionCacheModel question = currentTest.Questions[currentTest.QuestionIndex];

            if (question.CorrectAnswerId == model.SelectedAnswerid)
            {
                currentTest.Guessed++;
            }

            if (currentTest.QuestionIndex == currentTest.Questions.Count - 1)
            {
                double result = CalculateTestResult(currentTest);

            }

            currentTest.QuestionIndex++;

            if (this.HttpContext.Cache[currentTestCacheKey] == null)
            {
                this.HttpContext.Cache.Insert(
                    currentTestCacheKey,
                    currentTest,
                    null,
                    DateTime.Now.AddDays(1),
                    TimeSpan.Zero,
                    CacheItemPriority.Default,
                    null);
            }
            else
            {
                this.HttpContext.Cache[currentTestCacheKey] = currentTest;
            }

            return RedirectToAction("Solve", new RouteValueDictionary(new { testId = currentTestId }));
        }

        private double CalculateTestResult(TestCacheModel currentTest)
        {
            return (currentTest.Guessed / currentTest.Questions.Count) * 100;
            //Score score = new Score()
            //{
            //    UserId = currentUserId,
            //    TestId = currentTest.Id,
            //    Result = result
            //};
        }

        private void SaveTestResult(TestCacheModel currentTest, string userId, double result)
        {
            Score score = new Score()
            {
                UserId = userId,
                TestId = currentTest.Id,
                Result = result
            };

            //TODO: continue with the saving of test score
        }
    }
}