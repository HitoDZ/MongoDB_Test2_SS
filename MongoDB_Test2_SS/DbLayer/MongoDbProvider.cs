using System.Threading.Tasks;
using Models;
using MongoDB.Driver;

namespace DbLayer
{
    public class MongoDbProvider : IDbProvider
    {
        private IMongoDatabase _db;
        

        /// <param name="connectionUri">http://localhost:27107</param>
        /// <param name="dbName">testDb</param>
        public MongoDbProvider(string connectionUri, string dbName)
        {
            var client = new MongoClient(connectionUri);

            _db = client.GetDatabase(dbName);
        }
        
        
        public Client GetClient(long id, string collectionName)
        {
            var clientsCollection = _db.GetCollection<Client>(collectionName);

            var client = clientsCollection.FindSync((c) => c.Id == id).Single();

            return client;
        }

        public async Task<Client> GetClientAsync(long id, string collectionName)
        {
            var clientsCollection = _db.GetCollection<Client>(collectionName);

            //get hot task
            var task = clientsCollection.FindAsync((c) => c.Id == id);

            //tying get the result
            var client = await task;

            //return just single result
            return client.Single();
        }
    }
}