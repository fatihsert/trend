using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Web;

namespace Deeplink.Core
{
    public static class DeeplinkParameterHelper
    {
        public static NameValueCollection GetQueryStringParameters(string url, string pattern)
        {
            var querystring = Regex.Replace(url, pattern, string.Empty);

            return HttpUtility.ParseQueryString(querystring);
        }
    }
}
