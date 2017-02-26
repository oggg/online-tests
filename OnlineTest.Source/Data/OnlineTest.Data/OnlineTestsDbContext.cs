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
