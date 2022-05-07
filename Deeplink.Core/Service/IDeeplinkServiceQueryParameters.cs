using System.Collections.Specialized;

namespace Deeplink.Core
{
    public interface IDeeplinkServiceQueryParameters
    {
        void SetQueryParameters(string url, NameValueCollection parameters);
    }
}
