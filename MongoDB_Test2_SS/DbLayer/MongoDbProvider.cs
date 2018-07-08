using System.Threading.Tasks;
using Models;
using MongoDB.Driver;

namespace DbLayer
{
    public class MongoDbProvider : IDbProvider
    {
        private IMongoDatabase _db;
        
        
        /// <summary>
        /// Create instance to communicate with MongoDb
        /// </summary>
        /// <param name="connectionUri">http://localhost:27107</param>
        /// <param name="dbName">create or open db with dbName name</param>
        public MongoDbProvider(string connectionUri, string dbName)
        {
            var client = new MongoClient(connectionUri);

            _db = client.GetDatabase(dbName);
        }


        public IDbSession GetSession(string context)
        {
            return new MongoDbSession(_db, context);
        }

        public void CreateCollection(string name)
        {
            _db.CreateCollection(name);
        }
    }
}