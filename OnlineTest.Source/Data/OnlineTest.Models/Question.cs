using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Models
{
    public class Question
    {
        private ICollection<Test> tests;
        private ICollection<Answer> answers;

        public Question()
        {
            this.tests = new HashSet<Test>();
            this.answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int CorrectAnswerId { get; set; }

        public virtual Answer CorrectAnswer { get; set; }

        public virtual ICollection<Test> Tests { get { return this.tests; } set { this.tests = value; } }
        public virtual ICollection<Answer> Answers { get { return this.answers; } set { this.answers = value; } }
    }
}