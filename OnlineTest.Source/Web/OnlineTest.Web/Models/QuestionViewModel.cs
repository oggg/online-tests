﻿namespace OnlineTest.Web.Models
{
    using System.Collections.Generic;
    using OnlineTest.Models;

    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string TestName { get; set; }

        public string Description { get; set; }

        public int CorrectAnswerId { get; set; }

        public int OfferedAnswerId { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}