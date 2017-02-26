using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Models
{
    public class Test
    {
        private ICollection<Question> questions;

        public Test()
        {
            this.questions = new HashSet<Question>();
        }

        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get { return this.questions; } set { this.questions = value; } }
    }
}
