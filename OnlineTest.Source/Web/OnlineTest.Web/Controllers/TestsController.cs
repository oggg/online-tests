using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineTest.Services.Contracts;
using OnlineTest.Web.Models;

namespace OnlineTest.Web.Controllers
{
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
            var scores = this.scores.GetByUserId(currentUserId);
            TestsListViewModel model = new TestsListViewModel()
            {
                Tests = tests,
                UserScore = scores
            };

            return View(model);
        }
    }
}