namespace Deeplink.Core
{
    public class DeeplinkFlow : IDeeplinkFlow
    {
        private readonly IDeeplinkServiceFinder deeplinkServiceFinder;
        private readonly IDeeplinkValidatior deeplinkValidatior;
        private readonly IDeeplinkBuilder deeplinkBuilder;
        private readonly IDeeplinkRepository deeplinkRepository;

        public DeeplinkFlow(IDeeplinkServiceFinder deeplinkFinder,
                            IDeeplinkValidatior deeplinkValidatior,
                            IDeeplinkBuilder deeplinkBuilder,
                            IDeeplinkRepository deeplinkRepository)
        {
            this.deeplinkServiceFinder = deeplinkFinder;
            this.deeplinkValidatior = deeplinkValidatior;
            this.deeplinkBuilder = deeplinkBuilder;
            this.deeplinkRepository = deeplinkRepository;
        }

        public string Run(string url)
        {
            IDeeplinkService deeplinkService = deeplinkServiceFinder.Find(url);

            deeplinkValidatior.Validate(url, deeplinkService);

            string deeplink = deeplinkBuilder.Build(url, deeplinkService);

            deeplinkRepository.Save(url, deeplink);

            return deeplink;
        }
    }
}
