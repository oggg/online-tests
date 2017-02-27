namespace OnlineTest.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Score
    {
        private ICollection<Test> tests;
        public Score()
        {
            this.tests = new HashSet<Test>();
        }

        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        public double Result { get; set; }

        public virtual ICollection<Test> Tests { get { return this.tests; } set { this.tests = value; } }
    }
}
