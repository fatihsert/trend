using System.Text;

namespace Deeplink.Core
{
    public class DeeplinkBuilder : IDeeplinkBuilder
    {
        private readonly IDeeplinkConfiguration configuration;

        public DeeplinkBuilder(IDeeplinkConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Build(string url, IDeeplinkService deeplinkService)
        {
            StringBuilder deeplink = new StringBuilder();

            deeplink.Append(this.configuration.Root);

            DeeplinkParameterCollection parameterCollection = new DeeplinkParameterCollection();

            deeplinkService.SetDefaultParameters(parameterCollection);
            deeplinkService.SetFormatParameters(url, parameterCollection);
            deeplinkService.SetQueryParameters(url, parameterCollection);

            deeplink.Append(parameterCollection);

            return deeplink.ToString();
        }
    }

}
