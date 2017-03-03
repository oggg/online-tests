namespace OnlineTest.Services.Contracts
{
    public interface ICacheService
    {
        T Get<T>(string itemName, T data, int durationInDays);

        void Set(string itemName, object data, int durationInDays);

        void Remove(string itemName);
    }
}
