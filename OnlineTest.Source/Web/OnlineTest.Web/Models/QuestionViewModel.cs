using OnlineTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTest.Web.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Description { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public int SelectedAnswerId { get; set; }

        public bool IsFirst { get; set; }

        public bool IsLast { get; set; }
    }
}