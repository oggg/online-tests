namespace OnlineTest.Services
{
    using System.Linq;
    using Data.Repositories;
    using Models;

    public class TestsService
    {
        GenericRepository<Test> tests;

        public TestsService(GenericRepository<Test> tests)
        {
            this.tests = tests;
        }

        public IQueryable<Test> GetAll()
        {
            return this.tests.All();
        }

        public Test GetById(int categoryId)
        {
            Test category = this.tests.All().FirstOrDefault(w => w.Id == categoryId);
            return category;
        }
    }
}
