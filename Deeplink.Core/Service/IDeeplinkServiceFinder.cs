namespace Deeplink.Core
{
    public interface IDeeplinkServiceFinder
    {
        IDeeplinkService Find(string url);
    }
}
