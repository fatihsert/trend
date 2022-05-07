namespace Deeplink.Core
{
    public interface IDeeplinkBuilder
    {
        string Build(string url, IDeeplinkService deeplinkService);
    }
}
