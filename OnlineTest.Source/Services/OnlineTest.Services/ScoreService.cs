﻿namespace OnlineTest.Services
{
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class ScoreService : IScoreService
    {
        IRepository<Score> scores;

        public ScoreService(IRepository<Score> scores)
        {
            this.scores = scores;
        }

        public Score Add(Score score)
        {
            this.scores.Add(score);
            this.scores.SaveChanges();
            return score;
        }

        public IQueryable<Score> GetAll()
        {
            return this.scores.All();
        }

        public Score GetById(string id)
        {
            return this.scores.All().FirstOrDefault(s => s.Id == id);
        }

        public Score UpdateById(string id, Score updateScore)
        {
            var scoreToUpdate = this.scores.GetById(id);

            throw new System.NotImplementedException();

            //this.scores.SaveChanges();

            //return scoreToUpdate;
        }
    }
}
