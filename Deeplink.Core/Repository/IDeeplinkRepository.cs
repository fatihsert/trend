namespace Deeplink.Core
{
    public interface IDeeplinkRepository
    {
        void Save(string request, string response);
    }
}
