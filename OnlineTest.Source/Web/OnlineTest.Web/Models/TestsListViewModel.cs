using System.Collections.Generic;
using OnlineTest.Models;

namespace OnlineTest.Web.Models
{
    public class TestsListViewModel
    {
        public IEnumerable<Test> Tests { get; set; }

        public Dictionary<int, Score> UserScore { get; set; }
    }
}