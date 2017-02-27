using System.Linq;
using System.Web.Mvc;
using OnlineTest.Services.Contracts;

namespace OnlineTest.Web.Controllers
{
    public class TestsController : Controller
    {
        private readonly ITestsService tests;
        public TestsController(ITestsService tests)
        {
            this.tests = tests;
        }

        public ActionResult Index()
        {
            var tests = this.tests.GetAll().ToList();
            return View(tests);
        }
    }
}