using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTest.Web.Controllers
{
    public class QuestionController : Controller
    {
        public ActionResult Solve(int testId, int questionId)
        {
            return Content("Question controller index for Test" + testId + "and question " + questionId);
        }
    }
}