using Deeplink.Api.Configuration;
using Deeplink.Core;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Deeplink.Test.Core
{
    public class DeeplinkValidatiorTest
    {
        Mock<IDeeplinkService> deeplinkService;

        public DeeplinkValidatiorTest()
        {
            deeplinkService = new Mock<IDeeplinkService>();
        }

        private IList<IDeeplinkValidation> GetValidations()
        {
            DeeplinkConfiguraiton deeplinkConfiguraiton = new DeeplinkConfiguraiton();

            return deeplinkConfiguraiton.DeeplinkDefinitions.Where(q => q.Name == "Search").FirstOrDefault().Validations;
        }

        [Fact]
        public void Validate_UrlIsInvalid_InvalidDeeplinkExceptionThrown()
        {
            string searchUrl = "https://www.google.com/#/profile";

            deeplinkService.Setup(q => q.GetValidations()).Returns(GetValidations());

            IDeeplinkValidatior deeplinkValidatior = new DeeplinkValidator();

            Assert.Throws<InvalidDeeplinkException>(() =>
            {
                deeplinkValidatior.Validate(searchUrl, deeplinkService.Object);
            });
        }

        [Fact]
        public void Validate_UrlIsEmpty_InvalidDeeplinkExceptionThrown()
        {
            string searchUrl = string.Empty;

            deeplinkService.Setup(q => q.GetValidations()).Returns(GetValidations());

            IDeeplinkValidatior deeplinkValidatior = new DeeplinkValidator();

            Assert.Throws<InvalidDeeplinkException>(() =>
            {
                deeplinkValidatior.Validate(searchUrl, deeplinkService.Object);
            });
        }
    }

}
