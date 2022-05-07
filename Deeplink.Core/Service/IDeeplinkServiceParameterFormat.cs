using System.Collections.Specialized;

namespace Deeplink.Core
{
    public interface IDeeplinkServiceParameterFormat
    {
        void SetFormatParameters(string url, NameValueCollection parameters);
    }
}
