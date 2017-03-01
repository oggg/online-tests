using System.Collections.Generic;

namespace OnlineTest.Web.Models
{
    public class TestCacheModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<QuestionCacheModel> Questions { get; set; }

        public int QuestionIndex { get; set; }
    }
}