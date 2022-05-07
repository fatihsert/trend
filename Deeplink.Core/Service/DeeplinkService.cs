using System.Collections.Generic;
using System.Collections.Specialized;

namespace Deeplink.Core
{
    public class DeeplinkService : IDeeplinkService
    {
        private readonly DeeplinkDefinition definition;

        public DeeplinkService(DeeplinkDefinition definition)
        {
            this.definition = definition;
        }

        public void SetFormatParameters(string url, NameValueCollection parameters)
        {
            if (definition.ParameterFormatMap != null)
            {
                foreach (var item in definition.ParameterFormatMap)
                {
                    parameters.Add(item.Key, item.Value.Format(url));
                }
            }
        }

        public void SetQueryParameters(string url, NameValueCollection parameters)
        {
            NameValueCollection queryStringParameters = DeeplinkParameterHelper.GetQueryStringParameters(url, definition.RootPattern);

            if (queryStringParameters != null)
            {
                foreach (var item in queryStringParameters.AllKeys)
                {
                    string key = item;
                    string value = queryStringParameters[item];

                    if (key != null && value != null)
                    {
                        if (definition.ParameterKeyMap != null &&
                            definition.ParameterKeyMap.ContainsKey(item))
                        {
                            key = definition.ParameterKeyMap[item];
                        }

                        parameters.Add(key, value);
                    }
                }
            }
        }

        public IList<IDeeplinkValidation> GetValidations()
        {
            return definition.Validations;
        }

        public void SetDefaultParameters(NameValueCollection parameters)
        {
            if (definition.DefaultParameters != null)
            {
                foreach (var item in definition.DefaultParameters)
                {
                    parameters.Add(item.Key, item.Value);
                }
            }
        }
    }
}
