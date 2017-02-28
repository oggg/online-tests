namespace OnlineTest.Services.Contracts
{
    using System.Linq;
    using Models;
    using System.Collections.Generic;

    public interface IScoreService
    {
        Score Add(Score score);

        IQueryable<Score> GetAll();

        IEnumerable<Score> GetByUserId(string id);

        Score UpdateById(string id, Score updateScore);
    }
}
