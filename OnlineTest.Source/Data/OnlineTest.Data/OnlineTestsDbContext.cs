namespace OnlineTest.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OnlineTest.Models;

    public class OnlineTestsDbContext : IdentityDbContext<User>
    {
        public OnlineTestsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Answer> Answer { get; set; }

        public virtual IDbSet<Question> Question { get; set; }

        public virtual IDbSet<Score> Score { get; set; }

        public virtual IDbSet<Test> Test { get; set; }

        public static OnlineTestsDbContext Create()
        {
            return new OnlineTestsDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Ignore(u => u.PhoneNumber)
                                       .Ignore(u => u.PhoneNumberConfirmed)
                                       .Ignore(u => u.Roles)
                                       .Ignore(u => u.TwoFactorEnabled);
            base.OnModelCreating(modelBuilder);
        }
    }
}
