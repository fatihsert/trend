namespace Deeplink.Core
{
    public interface IDeeplinkValidatior
    {
        void Validate(string url, IDeeplinkService deeplinkService);
    }
}
