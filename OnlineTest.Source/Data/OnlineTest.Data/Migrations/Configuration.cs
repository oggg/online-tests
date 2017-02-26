namespace OnlineTest.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<OnlineTest.Data.OnlineTestsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OnlineTest.Data.OnlineTestsDbContext context)
        {

        }
    }
}
