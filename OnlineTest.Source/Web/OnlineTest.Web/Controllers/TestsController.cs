using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineTest.Services.Contracts;
using OnlineTest.Web.Models;
using OnlineTest.Models;

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
            //TODO: add cache for the test

            Test currentTest = this.tests.GetById(id);
            TestStartViewModel tsvm = new TestStartViewModel()
                            {
                                Id = currentTest.Id,
                                Name = currentTest.Name
                            };
            return View(tsvm);
        }
    }
}