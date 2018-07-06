using System.Collections.Generic;
using Models;
using MongoDB.Driver;

namespace DBLayer
{
    /// <summary>
    /// Provide CRUD operation on the abstract DB
    /// </summary>
    public interface IDBProvider
    {

        void CreateDocument<T>(string collection, T doc);

        void CreateDocuments<T>(string collection, List<T> docs);

        void CreateCollection(string name);

        IMongoCollection<Client> GetClients(string name);
    }
}