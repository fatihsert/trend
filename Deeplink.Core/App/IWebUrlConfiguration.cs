using System.Collections.Generic;

namespace Deeplink.Core
{
    public interface IWebUrlConfiguration
    {
        IList<IDeeplinkValidation> Validations { get; }
    }
}