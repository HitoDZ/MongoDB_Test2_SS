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
        
        
        
        #region Create
        
        public void Create<T>(T instance) where T : IIdentifieble
        {
            var collection = _db.GetCollection<T>(_workingCollection);
            
            collection.InsertOne(instance);
        }

        public async Task CreateAsync<T>(T instance) where T : IIdentifieble
        {
            var collection = _db.GetCollection<T>(_workingCollection);

            await collection.InsertOneAsync(instance);
        }

        public void CreateMany<T>(List<T> instances) where T : IIdentifieble
        {
            var collection = _db.GetCollection<T>(_workingCollection);
            
            collection.InsertMany(instances);
        }

        public async Task CreateManyAsync<T>(List<T> instances) where T : IIdentifieble
        {
            var collection = _db.GetCollection<T>(_workingCollection);

            await collection.InsertManyAsync(instances);
        }
        
        #endregion
        
        #region Read

        public T Read<T>(long id) where T : IIdentifieble
        {
            var collection = _db.GetCollection<T>(_workingCollection);

            var item = collection.FindSync((t) => t.Id == id);

            return item.Single();
        }

        public async Task<T> ReadAsync<T>(long id) where T : IIdentifieble
        {
            var collection = _db.GetCollection<T>(_workingCollection);

            var task = collection.FindAsync((t) => t.Id == id);

            var result = await task;

            return result.Single();
        }

        public List<T> ReadAll<T>() where T : IIdentifieble
        {
            var collection = _db.GetCollection<T>(_workingCollection);

            var result = collection.FindSync((_) => true);

            return result.ToList();
        }

        public async Task<List<T>> ReadAllAsync<T>() where T : IIdentifieble
        {
            var collection = _db.GetCollection<T>(_workingCollection);

            var task = collection.FindAsync((_) => true);

            var result = await task;

            return result.ToList();
        }
        
        #endregion
    }
}