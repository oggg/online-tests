namespace OnlineTest.Web.Models
{
    using System.Collections.Generic;
    using OnlineTest.Models;

    public class QuestionCacheModel
    {
        public int Id { get; set; }

        public string Text { get; set; }
        
        public string Description { get; set; }

        public int CorrectAnswerId { get; set; }
        
        public ICollection<Answer> Answers { get; set; }
    }
}