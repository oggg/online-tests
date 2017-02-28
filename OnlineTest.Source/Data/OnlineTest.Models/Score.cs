namespace OnlineTest.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Score
    {
        public int Id { get; set; }

        [Index]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public double Result { get; set; }

        public virtual Test Test { get; set; }
    }
}
