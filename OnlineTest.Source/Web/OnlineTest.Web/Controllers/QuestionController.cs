﻿using System;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using OnlineTest.Models;
using OnlineTest.Services.Contracts;
using OnlineTest.Web.Models;
using System.Linq;

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

            if (model.Direction > 0)
            {
                QuestionCacheModel question = currentTest.Questions[currentTest.QuestionIndex];
                double result;

                if (currentTest.QuestionIndex == currentTest.Questions.Count - 1)
                {
                    if (question.CorrectAnswerId == model.SelectedAnswerid)
                    {
                        question.Guessed = true;
                    }

                    result = CalculateTestResult(currentTest);
                    SaveTestResult(currentTest, currentUserId, result);
                    return RedirectToAction("Index", "Tests");
                }

                currentTest.QuestionIndex++;
            }
            //TODO: remove, because of the browser back button?
            else
            {
                currentTest.QuestionIndex--;
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

            return RedirectToAction("Solve", new RouteValueDictionary(new { testId = currentTestId, question = currentTest.QuestionIndex }));
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