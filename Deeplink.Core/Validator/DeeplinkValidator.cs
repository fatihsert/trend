using System.Collections.Generic;

namespace Deeplink.Core
{
    public class DeeplinkValidator : IDeeplinkValidatior
    {
        public void Validate(string url, IDeeplinkService deeplinkService)
        {
            IList<IDeeplinkValidation> validations = deeplinkService.GetValidations();

            foreach (var validation in validations)
            {
                if (!validation.Valid(url))
                {
                    throw new InvalidDeeplinkException();
                }
            }
        }
    }
}
