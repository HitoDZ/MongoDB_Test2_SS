using System.Collections.Generic;
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

        public List<Client> GetClients()
        {
            var clientsCollection = _db.GetCollection<Client>(_workingCollection);

            var clients = clientsCollection.FindSync((c) => true);

            return clients.ToList();
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            var clientsCollection = _db.GetCollection<Client>(_workingCollection);

            var task = clientsCollection.FindAsync((c) => true);

            var clients = await task;

            return clients.ToList();
        }

        public void Create<T>(T instance)
        {
            var collection = _db.GetCollection<T>(_workingCollection);
            
            collection.InsertOne(instance);
        }

        public async void CreateAsync<T>(T instance)
        {
            var collection = _db.GetCollection<T>(_workingCollection);

            await collection.InsertOneAsync(instance);
        }

        public void CreateMany<T>(List<T> instancies)
        {
            var collection = _db.GetCollection<T>(_workingCollection);
            
            collection.InsertMany(instancies);
        }

        public async void CreateManyAsync<T>(List<T> instancies)
        {
            var collection = _db.GetCollection<T>(_workingCollection);

            await collection.InsertManyAsync(instancies);
        }

        public T Read<T>(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> ReadAsync<T>(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<T> ReadAll<T>()
        {
            var collection = _db.GetCollection<T>(_workingCollection);

            var result = collection.FindSync((_) => true);

            return result.ToList();
        }

        public async Task<List<T>> ReadAllAsync<T>()
        {
            var collection = _db.GetCollection<T>(_workingCollection);

            var task = collection.FindAsync((_) => true);

            var result = await task;

            return result.ToList();
        }
    }
}