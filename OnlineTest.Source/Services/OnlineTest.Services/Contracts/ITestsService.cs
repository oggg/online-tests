using System.Linq;
using OnlineTest.Models;

namespace OnlineTest.Services.Contracts
{
    interface ITestsService
    {
        IQueryable<Test> GetAll();

        Test GetById(int categoryId);
    }
}
