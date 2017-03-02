namespace OnlineTest.Web.Models
{
    public class QuestionPostModel
    {
        public int Id { get; set; }
        
        public byte Direction { get; set; }

        public int SelectedAnswerid { get; set; }

        public int TestId { get; set; }

        public int Radio { get; set; }
    }
}