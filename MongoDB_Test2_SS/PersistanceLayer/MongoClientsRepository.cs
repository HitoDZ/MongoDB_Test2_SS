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

            var client = session.GetClient(id);

            return client;
        }

        public async Task<Client> ReadAsync(long id)
        {
            var session = _dbProvider.GetSession(clientsCollectionName);

            var client = await session.GetClientAsync(id);

            return client;
        }

        public List<Client> ReadAll()
        {
            var session = _dbProvider.GetSession(clientsCollectionName);

            var clients = session.GetClients();

            return clients;
        }
    }
}