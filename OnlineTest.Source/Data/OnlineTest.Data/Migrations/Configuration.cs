namespace OnlineTest.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Common;
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
            Questions(context);
        }

        private void Answers(OnlineTestsDbContext context)
        {
            context.Answer.Add(new Answer() { Text = "lorem" });
            context.Answer.Add(new Answer() { Text = "ipsum" });
            context.Answer.Add(new Answer() { Text = "dolor" });
            context.Answer.Add(new Answer() { Text = "sit" });
            context.Answer.Add(new Answer() { Text = "amet" });

            context.SaveChanges();
        }

        private void Questions(OnlineTestsDbContext context)
        {
            var answers = context.Answer.ToArray();

            context.Question.Add(new Question
            {
                Text = "What is the first word in the following text?",
                Answers = new HashSet<Answer>()
                                       {
                                           answers[0],
                                           answers[1],
                                           answers[2]
                                       },
                CorrectAnswerId = answers[0].Id,
                Description = TestsConstants.DescriptionTextForQuestions
            });
            context.Question.Add(new Question
            {
                Text = "What is the second word in the following text?",
                Answers = new HashSet<Answer>()
                                      {
                                          answers[0],
                                          answers[1],
                                          answers[2]
                                      },
                CorrectAnswerId = answers[1].Id,
                Description = TestsConstants.DescriptionTextForQuestions
            });
            context.Question.Add(new Question
            {
                Text = "What is the third word in the following text?",
                Answers = new HashSet<Answer>()
                                      {
                                          answers[0],
                                          answers[1],
                                          answers[2]
                                      },
                CorrectAnswerId = answers[2].Id,
                Description = TestsConstants.DescriptionTextForQuestions
            });
            context.Question.Add(new Question
            {
                Text = "What is the fourth word in the following text?",
                Answers = new HashSet<Answer>()
                                      {
                                          answers[1],
                                          answers[2],
                                          answers[3]
                                      },
                CorrectAnswerId = answers[3].Id,
                Description = TestsConstants.DescriptionTextForQuestions
            });
            context.Question.Add(new Question
            {
                Text = "What is the fifth word in the following text?",
                Answers = new HashSet<Answer>()
                                      {
                                          answers[6],
                                          answers[7],
                                          answers[4]
                                      },
                CorrectAnswerId = answers[4].Id,
                Description = TestsConstants.DescriptionTextForQuestions
            });

            context.SaveChanges();
        }

        private void Tests(OnlineTestsDbContext context)
        {
            Question[] questions = context.Question.ToArray();

            for (int i = 1; i <= TestsConstants.NumberOfTests; i++)
            {
                var questionsForCurrentTest = GetRandomQuestions(questions);
                context.Test.Add(new Test()
                {
                    Name = "Test " + i,
                    Questions = new HashSet<Question>(questionsForCurrentTest)
                });
            }

            context.SaveChanges();
        }

        private ICollection<Question> GetRandomQuestions(IList<Question> questions)
        {
            int numberOfQuestions = random.Next(2, questions.Count);
            ICollection<Question> randomQuestions = new HashSet<Question>();

            while (randomQuestions.Count < numberOfQuestions)
            {
                randomQuestions.Add(questions[random.Next(questions.Count)]);
            }
            return randomQuestions;
        }
    }
}
