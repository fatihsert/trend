namespace Deeplink.Core
{
    public class EmptyUrlValidation : IDeeplinkValidation
    {
        public bool Valid(string url)
        {
            return !string.IsNullOrEmpty(url);
        }
    }
}
