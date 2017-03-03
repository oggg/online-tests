using System;
using System.Linq;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using OnlineTest.Models;
using OnlineTest.Services.Contracts;
using OnlineTest.Web.Models;

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
        public ActionResult Solve(int testId, int question)
        {
            string currentUserId = User.Identity.GetUserId();
            string currentTestCacheKey = currentUserId + testId;
            TestCacheModel currentTest = (TestCacheModel)this.HttpContext.Cache[currentTestCacheKey];

            var currentQuestion = currentTest.Questions[question];

            QuestionViewModel currentQuestionView = new QuestionViewModel()
            {
                Answers = currentQuestion.Answers,
                Description = currentQuestion.Description,
                Index = question,
                Text = currentQuestion.Text,
                TestId = testId,
                IsFirst = question == 0 ? true : false,
                IsLast = question == currentTest.Questions.Count - 1 ? true : false
            };

            return View(currentQuestionView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Solve(int selectedAnswerId, int testId, int question)
        {
            string currentUserId = User.Identity.GetUserId();
            string currentTestCacheKey = currentUserId + testId;

            TestCacheModel currentTest = (TestCacheModel)this.HttpContext.Cache[currentTestCacheKey];

            if (currentTest == null)
            {
                return RedirectToAction("Logoff", "Account");
            }

            QuestionCacheModel currentQuestion = currentTest.Questions[question];

            if (currentQuestion.CorrectAnswerId == selectedAnswerId)
            {
                currentQuestion.Guessed = true;
            }
            else
            {
                currentQuestion.Guessed = false;
            }

            if (question == currentTest.Questions.Count - 1)
            {
                double result = CalculateTestResult(currentTest);
                SaveTestResult(currentTest, currentUserId, result);

                return RedirectToAction("Index", "Tests");
            }

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

            currentTest.QuestionIndex = question + 1;
            return RedirectToAction("Solve", new RouteValueDictionary(new { testId = testId, question = currentTest.QuestionIndex }));
        }

        private double CalculateTestResult(TestCacheModel currentTest)
        {
            int correctAnswers = currentTest.Questions.Where(q => q.Guessed).Count();
            return ((double)correctAnswers / currentTest.Questions.Count) * 100;
        }

        private void SaveTestResult(TestCacheModel currentTest, string userId, double result)
        {
            Score score = new Score()
            {
                UserId = userId,
                TestId = currentTest.Id,
                Result = result
            };

            this.scores.Add(score);
        }
    }
}