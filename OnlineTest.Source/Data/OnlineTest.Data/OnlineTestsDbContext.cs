namespace OnlineTest.Data
{
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
    }
}
