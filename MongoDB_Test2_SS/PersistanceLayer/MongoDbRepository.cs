using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using MongoDB.Driver;

namespace PersistanceLayer
{
    public class MongoDbRepository<T> : IRepository<T> where T : IIdentifieble
    {
        private string _context;
        private IMongoDatabase _db;
        private IMongoCollection<T> _collection;

        public MongoDbRepository(string connectionUri, string dbName, string context)
        {
            _context = context;
            
            _db = new MongoClient(connectionUri).GetDatabase(dbName);

            _collection = _db.GetCollection<T>(_context);
        }

        public void ChangeContext(string newContext)
        {
            _context = newContext;

            _collection = _db.GetCollection<T>(_context);
        }

        #region Create
        
        public void Create(T instance)
        {
            _collection.InsertOne(instance);
        }

        public async Task CreateAsync(T instance)
        {
            await _collection.InsertOneAsync(instance);
        }

        public void CreateMany(IEnumerable<T> instances)
        {
            _collection.InsertMany(instances);
        }

        public async Task CreateManyAsync(IEnumerable<T> instances)
        {
            await _collection.InsertManyAsync(instances);
        }

        #endregion
        
        #region Read
        
        public T Read(long id)
        {
            var item = _collection.FindSync((i) => i.Id == id);

            return item.Single();
        }

        public async Task<T> ReadAsync(long id)
        {
            var task = _collection.FindAsync((i) => i.Id == id);

            var item = await task;

            return item.Single();
        }

        public IEnumerable<T> ReadAll()
        {
            var items = _collection.FindSync((i) => true);

            return items.ToEnumerable();
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            var task = _collection.FindAsync((i) => true);

            var items = await task;

            return items.ToEnumerable();
        }
        
        #endregion
        
    }
}