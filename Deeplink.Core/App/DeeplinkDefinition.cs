using System.Collections.Generic;

namespace Deeplink.Core
{
    public class DeeplinkDefinition
    {
        public string RootPattern { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> ParameterKeyMap { get; set; }
        public IList<IDeeplinkValidation> Validations { get; set; }
        public Dictionary<string, IDeeplinkParameterFormater> ParameterFormatMap { get; set; }
        public Dictionary<string, string> DefaultParameters { get; set; }
    }
}
