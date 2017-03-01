using System;
using System.Linq;
using System.Web.Caching;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineTest.Models;
using OnlineTest.Services.Contracts;
using OnlineTest.Web.Models;

namespace OnlineTest.Web.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        private readonly ITestsService tests;
        private readonly IScoreService scores;
        public TestsController(ITestsService tests, IScoreService scores)
        {
            this.tests = tests;
            this.scores = scores;
        }

        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var tests = this.tests.GetAll().ToList();
            var userTests = this.scores.GetByUserId(currentUserId).ToDictionary(k => k.Test.Id);

            TestsListViewModel model = new TestsListViewModel()
            {
                Tests = tests,
                UserScore = userTests
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult SelectTest(int id)
        {
            Test currentTest = this.tests.GetById(id);
            TestCacheModel testCache = new TestCacheModel()
            {
                Id = id,
                Name = currentTest.Name,
                Questions = currentTest.Questions.Select(x => new QuestionCacheModel
                {
                    Id = x.Id,
                    Text = x.Text,
                    Description = x.Description,
                    Answers = x.Answers,
                    CorrectAnswerId = x.CorrectAnswerId
                }).ToList(),
                QuestionIndex = 0
            };

            string currentUserId = User.Identity.GetUserId();
            string testCacheKey = currentUserId + currentTest.Id;

            TestStartViewModel tsvm = new TestStartViewModel()
            {
                Id = currentTest.Id,
                Name = currentTest.Name
            };

            if (this.HttpContext.Cache[testCacheKey] == null)
            {
                this.HttpContext.Cache.Insert(
                    testCacheKey,
                    testCache,
                    null,
                    DateTime.Now.AddDays(1),
                    TimeSpan.Zero,
                    CacheItemPriority.Default,
                    null);
            }

            return View(tsvm);
        }
    }
}