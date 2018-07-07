using System.Threading.Tasks;
using Models;
using MongoDB.Driver;

namespace DbLayer
{
    public class MongoDbSession : IDbSession
    {
        private IMongoDatabase _db;
        private string _workingCollection;

        
        
        public MongoDbSession(IMongoDatabase db, string context)
        {
            _db = db;
            _workingCollection = context;
        }
        
        
        
        public Client GetClient(long id)
        {
            var clientsCollection = _db.GetCollection<Client>(_workingCollection);

            var client = clientsCollection.FindSync((c) => c.Id == id).Single();

            return client;
        }

        public async Task<Client> GetClientAsync(long id)
        {
            var clientsCollection = _db.GetCollection<Client>(_workingCollection);

            //get hot task
            var task = clientsCollection.FindAsync((c) => c.Id == id);

            //trying get set of clients against find statement
            var clients = await task;

            //return just single result
            return clients.Single();
        }

        public Properties GetProperties(long id)
        {
            var propertiesCollection = _db.GetCollection<Properties>(_workingCollection);

            var property = propertiesCollection.FindSync((p) => p.Id == id).Single();

            return property;
        }

        public async Task<Properties> GetPropertiesAsync(long id)
        {
            var propertiesCollection = _db.GetCollection<Properties>(_workingCollection);

            //get hot task
            var task = propertiesCollection.FindAsync((p) => p.Id == id);

            //trying get set of properties against find statement
            var properties = await task;

            //return just one single result
            return properties.Single();
        }
    }
}