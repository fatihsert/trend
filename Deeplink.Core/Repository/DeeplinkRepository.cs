namespace Deeplink.Core
{
    public class DeeplinkRepository : IDeeplinkRepository
    {
        private readonly IRepository repository;

        public DeeplinkRepository(IRepository repository)
        {
            this.repository = repository;
        }
        public void Save(string request, string response)
        {
            repository.Set<string>(response, request);
        }
    }
}
