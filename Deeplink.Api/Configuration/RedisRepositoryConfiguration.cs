using Deeplink.Core;

namespace Deeplink.Api.Configuration
{
    public class RedisRepositoryConfiguration : IRepositoryConfiguration
    {
        public string Connection { get; set; }

        public RedisRepositoryConfiguration()
        {
            this.Connection = "localhost:6379";
        }
    }
}
