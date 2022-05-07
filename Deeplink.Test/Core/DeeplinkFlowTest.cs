using Deeplink.Core;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Deeplink.Test.Core
{
    public class DeeplinkFlowTest
    {
        private readonly Mock<IDeeplinkServiceFinder> deeplinkServiceFinder;
        private readonly Mock<IDeeplinkValidatior> deeplinkValidatior;
        private readonly Mock<IDeeplinkBuilder> deeplinkBuilder;
        private readonly Mock<IDeeplinkRepository> deeplinkRepository;
        private readonly Mock<DeeplinkDefinition> deeplinkDefinition;

        public DeeplinkFlowTest()
        {
            deeplinkServiceFinder = new Mock<IDeeplinkServiceFinder>();
            deeplinkValidatior = new Mock<IDeeplinkValidatior>();
            deeplinkBuilder = new Mock<IDeeplinkBuilder>();
            deeplinkRepository = new Mock<IDeeplinkRepository>();
            deeplinkDefinition = new Mock<DeeplinkDefinition>();

            DeeplinkDefinition other = new DeeplinkDefinition();

            other.Name = "Home";
            other.RootPattern = @"^(http|https):\/\/(www\.)?trendyol\.com\/.*";

            other.DefaultParameters = new Dictionary<string, string>();
            other.DefaultParameters.Add("Page", other.Name);

            other.Validations = new List<IDeeplinkValidation>
                    {
                        new EmptyUrlValidation(),
                        new RegexUrlValidation(other.RootPattern)
                    };

            deeplinkDefinition.SetReturnsDefault<DeeplinkDefinition>(other);
        }

        [Fact]
        public void Run_UrlIsEmpty_NotFoundDeeplinkServiceExceptionThrown()
        {
            deeplinkServiceFinder.Setup(q => q.Find(null)).Throws(new NotFoundDeeplinkServiceException());

            DeeplinkFlow deeplinkFlow = new DeeplinkFlow(deeplinkServiceFinder.Object,
                                                         deeplinkValidatior.Object,
                                                         deeplinkBuilder.Object,
                                                         deeplinkRepository.Object);

            Assert.Throws<NotFoundDeeplinkServiceException>(() =>
            {
                deeplinkFlow.Run(null);
            });
        }

        [Fact]
        public void Run_Empty_ValidUrl_NotFoundDeeplinkServiceExceptionThrown()
        {
            string validUrl = "https://www.trendyol.com/";
            string expectedUrl = "ty://?Page=Home";

            IDeeplinkService deeplinkService = new DeeplinkService(deeplinkDefinition.Object);

            deeplinkServiceFinder.Setup(q => q.Find(validUrl))
                                 .Returns(deeplinkService);

            deeplinkBuilder.Setup(q => q.Build(validUrl, deeplinkService)).Returns(expectedUrl);

            DeeplinkFlow deeplinkFlow = new DeeplinkFlow(deeplinkServiceFinder.Object,
                                                         deeplinkValidatior.Object,
                                                         deeplinkBuilder.Object,
                                                         deeplinkRepository.Object);

            var actualUrl = deeplinkFlow.Run(validUrl);

            Assert.Equal(expectedUrl, actualUrl);
        }
    }
}
