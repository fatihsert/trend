using System.Collections.Generic;

namespace Deeplink.Core
{
    public class WebUrlValidator : IWebUrlValidator
    {
        private readonly IWebUrlConfiguration webUrlConfiguration;

        public WebUrlValidator(IWebUrlConfiguration webUrlConfiguration) 
        {
            this.webUrlConfiguration = webUrlConfiguration;
        }
        public void Validate(string deeplink)
        {
            IList<IDeeplinkValidation> validations = webUrlConfiguration.Validations;

            foreach (var validation in validations)
            {
                if (!validation.Valid(deeplink))
                {
                    throw new InvalidDeeplinkException();
                }
            }
        }
    }
}
