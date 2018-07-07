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


        public IDbSession GetSession(string context)
        {
            return new MongoDbSession(_db, context);
        }
    }
}