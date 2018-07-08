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


        #region Create
        
        public void CreateClient(Client instance)
        {
            var session = _dbProvider.GetSession(clientsCollectionName);
            
            session.Create(instance);
        }

        public async Task CreateClientAsync(Client instance)
        {
            var session = _dbProvider.GetSession(clientsCollectionName);
            
            await session.CreateAsync(instance);
        }

        public void CreateClients(List<Client> instances)
        {
            var session = _dbProvider.GetSession(clientsCollectionName);
            
            session.CreateMany(instances);
        }

        public async Task CreateClientsAsync(List<Client> instances)
        {
            var session = _dbProvider.GetSession(clientsCollectionName);

            await session.CreateManyAsync(instances);
        }

        #endregion
        
        #region Read
        
        public Client ReadClient(long id)
        {
            var session = _dbProvider.GetSession(clientsCollectionName);

            var client = session.Read<Client>(id);

            return client;
        }

        public async Task<Client> ReadClientAsync(long id)
        {
            var session = _dbProvider.GetSession(clientsCollectionName);

            var client = await session.ReadAsync<Client>(id);

            return client;
        }

        public List<Client> ReadAllClients()
        {
            var session = _dbProvider.GetSession(clientsCollectionName);

            var clients = session.ReadAll<Client>();

            return clients;
        }

        public async Task<List<Client>> ReadAllClientsAsync()
        {
            var session = _dbProvider.GetSession(clientsCollectionName);

            var task = session.ReadAllAsync<Client>();

            var clients = await task;


            return clients;
        }
        
        #endregion
        
    }
}