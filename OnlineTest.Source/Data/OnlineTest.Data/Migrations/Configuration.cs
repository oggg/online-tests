namespace OnlineTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<OnlineTest.Data.OnlineTestsDbContext>
    {
        private static Random random = new Random();
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OnlineTestsDbContext context)
        {
            Answers(context);
        }

        private void Answers(OnlineTestsDbContext context)
        {
            context.Answer.Add(new Answer() { Text = "lorem" });
            context.Answer.Add(new Answer() { Text = "ipsum" });
            context.Answer.Add(new Answer() { Text = "dolor" });
            context.Answer.Add(new Answer() { Text = "sit" });
            context.Answer.Add(new Answer() { Text = "amet" });
            context.Answer.Add(new Answer() { Text = "id" });
            context.Answer.Add(new Answer() { Text = "iisque" });
            context.Answer.Add(new Answer() { Text = "singulis" });

            context.SaveChanges();
        }

        private void Questions(OnlineTestsDbContext context)
        {

        }

        private void Tests(OnlineTestsDbContext context)
        {

        }
    }
}
