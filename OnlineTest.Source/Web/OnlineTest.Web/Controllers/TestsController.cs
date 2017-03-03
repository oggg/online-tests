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
    public class TestsController : BaseController
    {
        private readonly ITestsService tests;

        public TestsController(ITestsService tests, IScoreService scores)
            : base(scores)
        {
            this.tests = tests;
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
                Name = currentTest.Name,
                Question = 0
            };

            this.HttpContext.Cache.Insert(
                testCacheKey,
                testCache,
                null,
                DateTime.Now.AddDays(1),
                TimeSpan.Zero,
                CacheItemPriority.Default,
                null);


            return View(tsvm);
        }
    }
}