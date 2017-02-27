using System.Linq;
using System.Web.Mvc;
using OnlineTest.Services;

namespace OnlineTest.Web.Controllers
{
    public class TestsController : Controller
    {
        private readonly TestsService tests;
        public TestsController(TestsService tests)
        {
            this.tests = tests;
        }

        public TestsController()
        {
        }
        public ActionResult Index()
        {
            var tests = this.tests.GetAll().ToList();
            return View(tests);
        }
    }
}