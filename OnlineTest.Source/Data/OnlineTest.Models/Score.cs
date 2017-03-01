namespace OnlineTest.Models
{
    public class Score
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public double Result { get; set; }

        public int TestId { get; set; }

        public virtual Test Test { get; set; }
    }
}
