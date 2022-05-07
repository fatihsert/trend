using System.Collections.Generic;

namespace Deeplink.Core
{
    public interface IDeeplinkConfiguration
    {
        string Root { get; set; }
        IList<DeeplinkDefinition> DeeplinkDefinitions { get; set; }
    }
}
