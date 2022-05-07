namespace Deeplink.Core
{
    public class WebUrlRepository : IWebUrlRepository
    {
        private readonly IRepository repository;

        public WebUrlRepository(IRepository repository)
        {
            this.repository = repository;
        }

        public string Get(string deeplink)
        {
            return this.repository.Get<string>(deeplink);
        }
    }
}
