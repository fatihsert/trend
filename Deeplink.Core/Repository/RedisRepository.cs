using Newtonsoft.Json;
using StackExchange.Redis;

namespace Deeplink.Core
{
    public class RedisRepository : IRepository
    {
        private readonly ConnectionMultiplexer connection;

        public RedisRepository(IRepositoryConfiguration configuration)
        {
            connection = ConnectionMultiplexer.Connect(configuration.Connection);
        }
        private IDatabase GetDatabase()
        {
            return connection.GetDatabase();
        }

        public T Get<T>(string key)
        {
            IDatabase database = GetDatabase();

            string data = database.StringGet(key);

            return JsonConvert.DeserializeObject<T>(data);
        }

        public void Set<T>(string key, T value)
        {
            IDatabase database = GetDatabase();

            var data = JsonConvert.SerializeObject(value);

            database.StringSet(key, data);
        }
    }
}
