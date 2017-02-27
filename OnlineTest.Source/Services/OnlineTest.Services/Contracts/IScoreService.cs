namespace OnlineTest.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IScoreService
    {
        Score Add(Score score);

        IQueryable<Score> GetAll();

        Score GetByUserId(string id);

        Score UpdateById(string id, Score updateScore);
    }
}
