namespace OnlineTest.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Score
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        public int TestId { get; set; }

        public virtual Test Test { get; set; }

        public double Result { get; set; }
    }
}
