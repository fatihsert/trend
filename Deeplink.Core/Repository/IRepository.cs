namespace Deeplink.Core
{
    public interface IRepository
    {
        void Set<T>(string key, T value);

        T Get<T>(string key);
    }
}
