namespace Deeplink.Core
{
    public class WebUrlFlow : IWebUrlFlow
    {
        private readonly IWebUrlValidator webUrlValidator;
        private readonly IWebUrlRepository webUrlRepository;

        public WebUrlFlow(IWebUrlValidator webUrlValidator,
                          IWebUrlRepository webUrlRepository)
        {
            this.webUrlValidator = webUrlValidator;
            this.webUrlRepository = webUrlRepository;
        }
        public string Run(string deeplink)
        {
            webUrlValidator.Validate(deeplink);
            
            return webUrlRepository.Get(deeplink);
        }
    }
}
