using Deeplink.Api.Configuration;
using Deeplink.Core;
using Moq;
using System.Linq;
using Xunit;

namespace Deeplink.Test.Core
{
    public class DeeplinkBuilderTest
    {
        private readonly Mock<IDeeplinkConfiguration> deeplinkConfiguration;
        private readonly Mock<IDeeplinkService> deeplinkService;
        public DeeplinkBuilderTest()
        {
            deeplinkService = new Mock<IDeeplinkService>();

            deeplinkConfiguration = new Mock<IDeeplinkConfiguration>();
            deeplinkConfiguration.Setup(q => q.Root).Returns("ty://?");

        }
        private DeeplinkDefinition FindConfig(string service)
        {
            DeeplinkConfiguraiton deeplinkConfiguraiton = new DeeplinkConfiguraiton();

            return deeplinkConfiguraiton.DeeplinkDefinitions.Where(q => q.Name == service).FirstOrDefault();
        }

        [Fact]
        public void Build_UrlIsInvalid_ReturnsExpectedUrl()
        {
            string searchUrl = "https://www.google.com/#";
            string expectedUrl = "ty://?";

            deeplinkConfiguration.SetupGet(q => q.Root).Returns(expectedUrl);

            IDeeplinkBuilder deeplinkBuilder = new DeeplinkBuilder(deeplinkConfiguration.Object);

            string actualUrl = deeplinkBuilder.Build(searchUrl, deeplinkService.Object);

            Assert.Equal(expectedUrl, actualUrl);
        }

        [Fact]
        public void Build_UrlIsEmpty_ReturnsExpectedUrl()
        {
            string searchUrl = "";
            string expectedUrl = "ty://?";

            deeplinkConfiguration.SetupGet(q => q.Root).Returns(expectedUrl);

            IDeeplinkBuilder deeplinkBuilder = new DeeplinkBuilder(deeplinkConfiguration.Object);

            string actualUrl = deeplinkBuilder.Build(searchUrl, deeplinkService.Object);

            Assert.Equal(expectedUrl, actualUrl);
        }

        [Fact]
        public void Build_ValidUrlForSearch_ReturnsExpectedUrl()
        {
            string searchUrl = "https://www.trendyol.com/tum--urunler?q=deneme";
            string expectedUrl = "ty://?Page=Search&Query=deneme";

            IDeeplinkBuilder deeplinkBuilder = new DeeplinkBuilder(deeplinkConfiguration.Object);
            IDeeplinkService deeplinkService = new DeeplinkService(FindConfig("Search"));

            string actualUrl = deeplinkBuilder.Build(searchUrl, deeplinkService);

            Assert.Equal(expectedUrl, actualUrl);
        }

        [Fact]
        public void Build_ValidUrlForProductDetailWithoutQueryString_ReturnsExpectedUrl()
        {
            string productDetailUrl = "https://www.trendyol.com/xiaoMi3/mi-wifi-pro-sinyal-yakinlastirici-turkiye-uyumlu-global-versiyon-300-mbps-mi-wifi-pro-p-35801405";
            string expectedUrl = "ty://?Page=Product&ContentId=35801405";

            IDeeplinkBuilder deeplinkBuilder = new DeeplinkBuilder(deeplinkConfiguration.Object);
            IDeeplinkService deeplinkService = new DeeplinkService(FindConfig("Product"));

            string actualUrl = deeplinkBuilder.Build(productDetailUrl, deeplinkService);

            Assert.Equal(expectedUrl, actualUrl);
        }
        [Fact]
        public void Build_ValidUrlForProductDetailWithQueryString_ReturnsExpectedUrl()
        {
            string productDetailUrl = "https://www.trendyol.com/trendyolmilla/camel-dantel-detayli-triko-kazak-twoaw21kz0092-p-45732409?boutiqueId=550825&merchantId=968";
            string expectedUrl = "ty://?Page=Product&ContentId=45732409&campaingId=550825&merchantId=968";

            IDeeplinkBuilder deeplinkBuilder = new DeeplinkBuilder(deeplinkConfiguration.Object);
            IDeeplinkService deeplinkService = new DeeplinkService(FindConfig("Product"));

            string actualUrl = deeplinkBuilder.Build(productDetailUrl, deeplinkService);

            Assert.Equal(expectedUrl, actualUrl);
        }
        [Fact]
        public void Build_ValidUrlForOther_ReturnsExpectedUrl()
        {
            string otherUrl = "https://www.trendyol.com/#/öç";
            string expectedUrl = "ty://?Page=Home";

            IDeeplinkBuilder deeplinkBuilder = new DeeplinkBuilder(deeplinkConfiguration.Object);
            IDeeplinkService deeplinkService = new DeeplinkService(FindConfig("Home"));

            string actualUrl = deeplinkBuilder.Build(otherUrl, deeplinkService);

            Assert.Equal(expectedUrl, actualUrl);
        }
    }

}
