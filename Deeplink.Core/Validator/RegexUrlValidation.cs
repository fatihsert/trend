using System.Text.RegularExpressions;

namespace Deeplink.Core
{
    public class RegexUrlValidation : IDeeplinkValidation
    {
        private readonly string pattern;

        public RegexUrlValidation(string pattern)
        {
            this.pattern = pattern;
        }
        public bool Valid(string url)
        {
            return Regex.IsMatch(url, pattern);
        }
    }
}
