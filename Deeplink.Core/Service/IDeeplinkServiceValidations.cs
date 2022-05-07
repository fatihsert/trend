using System.Collections.Generic;

namespace Deeplink.Core
{
    public interface IDeeplinkServiceValidations
    {
        IList<IDeeplinkValidation> GetValidations();
    }
}
