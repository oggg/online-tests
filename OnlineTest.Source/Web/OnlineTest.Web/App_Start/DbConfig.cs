namespace OnlineTest.Web
{
    using System.Data.Entity;
    using Data;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnlineTestsDbContext, Data.Migrations.Configuration>());
        }
    }
}