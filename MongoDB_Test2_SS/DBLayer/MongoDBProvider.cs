using System.Collections.Generic;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DBLayer
{
    public class MongoDBProvider : IDBProvider
    {
        private string _dbName;

        private IMongoDatabase _db;
        
        

        public MongoDBProvider(string dbName)
        {
            //set _dbName
            _dbName = dbName;
            
            //create service to interact with db
            _db = new MongoClient().GetDatabase(_dbName);
        }
        

        /// <summary>
        /// returns collection of db collection
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IMongoCollection<Client> GetClients(string name)
        {
            //get client to interact with db
            var client = new MongoClient();
            
            //get session
            var session = client.StartSession();

            return _db.GetCollection<Client>(name);
        }
        
        
        
        public void CreateDocument<T>(string collection, T doc)
        {
            var session = new MongoClient().StartSession();
            
            _db.GetCollection<T>(collection).InsertOne(session, doc);
        }

        public void CreateDocuments<T>(string collection, List<T> docs)
        {
            var session = new MongoClient().StartSession();
            
            _db.GetCollection<T>(collection).InsertMany(session, docs);
        }

        public void CreateCollection(string name)
        {
            //get session
            var session = new MongoClient().StartSession();
            
            //create collection
            _db.CreateCollection(session, name);
        }
        
    }
    
    
}