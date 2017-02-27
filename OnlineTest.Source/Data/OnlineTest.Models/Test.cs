using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Models
{
    public class Test
    {
        private ICollection<Question> questions;
        private ICollection<Score> scores;

        public Test()
        {
            this.questions = new HashSet<Question>();
            this.scores = new HashSet<Score>();
        }

        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get { return this.questions; } set { this.questions = value; } }

        public virtual ICollection<Score> Scores { get { return this.scores; } set { this.scores = value; } }
    }
}
