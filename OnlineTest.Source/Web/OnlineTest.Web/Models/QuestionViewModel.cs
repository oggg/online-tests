using System.Collections.Generic;
using OnlineTest.Models;

namespace OnlineTest.Web.Models
{
    public class QuestionViewModel
    {
        public int Index { get; set; }

        public string Text { get; set; }

        public string Description { get; set; }

        public int TestId { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public bool IsFirst { get; set; }

        public bool IsLast { get; set; }
    }
}