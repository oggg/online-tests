using System.Web.Mvc;
using OnlineTest.Services.Contracts;

namespace OnlineTest.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IScoreService scores;

        public BaseController(IScoreService scores)
        {
            this.scores = scores;
        }
    }
}