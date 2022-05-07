using System.Text.RegularExpressions;

namespace Deeplink.Core
{
    public class DeeplinkContentIdFormater : IDeeplinkParameterFormater
    {
        private readonly string prefixPattern;
        private readonly string suffixPattern;

        public DeeplinkContentIdFormater(string prefixPattern, string suffixPattern)
        {
            this.prefixPattern = prefixPattern;
            this.suffixPattern = suffixPattern;
        }

        public string Format(string url)
        {
            var urlSuffix = Regex.Replace(url, prefixPattern, string.Empty);

            return Regex.Match(urlSuffix, suffixPattern).Value;
        }
    }
}
