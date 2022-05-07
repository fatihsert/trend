using Deeplink.Core;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Deeplink.Test.Core
{
    public class DeeplinkServiceFinderTest
    {
        private readonly Mock<IDeeplinkConfiguration> deeplinkConfiguration;

        public DeeplinkServiceFinderTest()
        {
            deeplinkConfiguration = new Mock<IDeeplinkConfiguration>();

            deeplinkConfiguration.SetupGet(q => q.Root).Returns("ty://?");
        }

        private IList<DeeplinkDefinition> GetHomeDeeplinkDefinitions()
        {
            IList<DeeplinkDefinition> deeplinkDefinitions = new List<DeeplinkDefinition>();

            DeeplinkDefinition other = new DeeplinkDefinition();
            deeplinkDefinitions.Add(other);

            other.Name = "Home";
            other.RootPattern = @"^(http|https):\/\/(www\.)?trendyol\.com\/.*";

            other.DefaultParameters = new Dictionary<string, string>();
            other.DefaultParameters.Add("Page", other.Name);

            other.Validations = new List<IDeeplinkValidation>
                    {
                        new EmptyUrlValidation(),
                        new RegexUrlValidation(other.RootPattern)
                    };

            deeplinkConfiguration.SetupGet(q => q.DeeplinkDefinitions).Returns(deeplinkDefinitions);

            return deeplinkDefinitions;
        }

        [Fact]
        public void Find_WhenUrlForOtherPage_ReturnDeeplinkService()
        {
            string otherPageUrl = "https://www.trendyol.com/#/profile";

            IList<DeeplinkDefinition> HomeDeeplinkDefinitions = GetHomeDeeplinkDefinitions();

            deeplinkConfiguration.SetupGet(q => q.DeeplinkDefinitions).Returns(HomeDeeplinkDefinitions);

            IDeeplinkServiceFinder deeplinkServiceFinder = new DeeplinkServiceFinder(deeplinkConfiguration.Object);
            IDeeplinkService otherDeeplinkService = deeplinkServiceFinder.Find(otherPageUrl);

            Assert.NotNull(otherDeeplinkService);
        }


        [Fact]
        public void Find_UrlIsEmpty_NotFoundDeeplinkServiceExceptionThrown()
        {
            IDeeplinkServiceFinder deeplinkServiceFinder = new DeeplinkServiceFinder(deeplinkConfiguration.Object);

            Assert.Throws<NotFoundDeeplinkServiceException>(() =>
            {
                deeplinkServiceFinder.Find(null);
            });
        }

        [Fact]
        public void Find_UrlIsValid_NotFoundDeeplinkServiceExceptionThrown()
        {
            string invalidUrl = "https://www.google.com/#";

            IList<DeeplinkDefinition> HomeDeeplinkDefinitions = GetHomeDeeplinkDefinitions();

            deeplinkConfiguration.SetupGet(q => q.DeeplinkDefinitions).Returns(HomeDeeplinkDefinitions);

            IDeeplinkServiceFinder deeplinkServiceFinder = new DeeplinkServiceFinder(deeplinkConfiguration.Object);

            Assert.Throws<NotFoundDeeplinkServiceException>(() =>
            {
                deeplinkServiceFinder.Find(invalidUrl);
            });
        }
    }

}
