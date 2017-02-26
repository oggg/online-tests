using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Models
{
    public class Answer
    {
        private ICollection<Question> questions;

        public Answer()
        {
            this.questions = new HashSet<Question>();
        }
        public int Id { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        public virtual ICollection<Question> Questions { get { return this.questions; } set { this.questions = value; } }
    }
}