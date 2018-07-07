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

            //trying get the result
            var client = await task;

            //return just single result
            return client.Single();
        }

        public Properties GetProperties(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}