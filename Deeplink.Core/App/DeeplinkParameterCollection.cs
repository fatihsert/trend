using System.Collections.Specialized;
using System.Text;

namespace Deeplink.Core
{
    public class DeeplinkParameterCollection : NameValueCollection
    {
        public override string ToString()
        {
            StringBuilder parameterBuilder = new StringBuilder();

            if (AllKeys != null && AllKeys.Length > 0)
            {
                foreach (var item in AllKeys)
                {
                    parameterBuilder.Append($"{item}={this[item]}&");
                }

                parameterBuilder.Length--;
            }

            return parameterBuilder.ToString();
        }
    }
}
