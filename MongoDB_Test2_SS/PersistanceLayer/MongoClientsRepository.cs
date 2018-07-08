using System.Collections.Generic;
using System.Threading.Tasks;
using DbLayer;
using Models;

namespace PersistanceLayer
{
    public class MongoClientsRepository : IClientsRepository
    {
        private IDbProvider _dbProvider;

        //it should be moved from there it the future
        private static string clientsCollectionName = "ClientsCollection";

        public MongoClientsRepository(IDbProvider provider)
        {
            _dbProvider = provider;
        }
        
        
        
        public Client Read(long id)
        {
            var session = _dbProvider.GetSession(clientsCollectionName);

            var client = session.Read<Client>(id);

            return client;
        }

        public async Task<Client> ReadAsync(long id)
        {
            var session = _dbProvider.GetSession(clientsCollectionName);

            var client = await session.ReadAsync<Client>(id);

            return client;
        }

        public List<Client> ReadAll()
        {
            var session = _dbProvider.GetSession(clientsCollectionName);

            var clients = session.ReadAll<Client>();

            return clients;
        }

        public async Task<List<Client>> ReadAllAsync()
        {
            var session = _dbProvider.GetSession(clientsCollectionName);

            var task = session.ReadAllAsync<Client>();

            var clients = await task;


            return clients;
        }
    }
}