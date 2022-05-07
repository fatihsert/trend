using Deeplink.Api.Controllers;
using Deeplink.Core;
using Moq;
using Xunit;

namespace Deeplink.Test.Api
{
    public class ConvertToDeeplinkTest
    {
        private readonly Mock<IDeeplinkFlow> deeplinkFlow;
        public ConvertToDeeplinkTest()
        {
            deeplinkFlow = new Mock<IDeeplinkFlow>();
        }

        [Fact]
        public void ConvertToDeeplink_UrlIsEmpty_NotFoundDeeplinkServiceExceptionThrown()
        {
            deeplinkFlow.Setup(x => x.Run(null)).Throws(new NotFoundDeeplinkServiceException());

            DeeplinkController deeplinkController = new DeeplinkController(deeplinkFlow.Object);

            Assert.Throws<NotFoundDeeplinkServiceException>(() =>
            {
                deeplinkController.ConvertToDeeplink(null);
            });
        }
        [Fact]
        public void ConvertToDeeplink_InvalidUrl_NotFoundDeeplinkServiceExceptionThrown()
        {
            string invalidUrl = "google.com";

            deeplinkFlow.Setup(x => x.Run(invalidUrl)).Throws(new NotFoundDeeplinkServiceException());

            DeeplinkController deeplinkController = new DeeplinkController(deeplinkFlow.Object);

            Assert.Throws<NotFoundDeeplinkServiceException>(() =>
            {
                deeplinkController.ConvertToDeeplink(invalidUrl);
            });
        }
        [Fact]
        public void ConvertToDeeplink_ValidUrl_Deeplink()
        {
            string validUrl = "https://www.trendyol.com/";
            string expectedUrl = "ty://?Page=Home";

            deeplinkFlow.Setup(x => x.Run(validUrl)).Returns(expectedUrl);

            DeeplinkController deeplinkController = new DeeplinkController(deeplinkFlow.Object);

            string actualUrl = deeplinkController.ConvertToDeeplink(validUrl);

            Assert.Equal(expectedUrl, actualUrl);
        }
    }
}
