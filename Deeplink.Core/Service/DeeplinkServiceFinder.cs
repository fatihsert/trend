using System.Text.RegularExpressions;

namespace Deeplink.Core
{
    public class DeeplinkServiceFinder : IDeeplinkServiceFinder
    {
        public DeeplinkServiceFinder(IDeeplinkConfiguration deeplinkConfiguration)
        {
            DeeplinkConfiguration = deeplinkConfiguration;
        }

        public IDeeplinkConfiguration DeeplinkConfiguration { get; }

        public IDeeplinkService Find(string url)
        {
            if (DeeplinkConfiguration != null && !string.IsNullOrEmpty(url))
            {
                foreach (var item in DeeplinkConfiguration.DeeplinkDefinitions)
                {
                    if (Regex.IsMatch(url, item.RootPattern))
                    {
                        return new DeeplinkService(item);
                    }
                }
            }

            throw new NotFoundDeeplinkServiceException();
        }
    }
}
