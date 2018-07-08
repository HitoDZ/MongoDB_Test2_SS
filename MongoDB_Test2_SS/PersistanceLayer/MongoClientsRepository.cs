using System.Collections.Generic;
using System.Threading.Tasks;
using DbLayer;
using Models;

namespace PersistanceLayer
{
    public class MongoClientsRepository : IClientsRepository
    {
        private IDbProvider _dbProvider;

        private IDbSession _session;

        private string clientsCollectionName;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="provider">Provide interactions with db</param>
        /// <param name="context">Context specialization(in case with mongo = clients collection name)</param>
        public MongoClientsRepository(IDbProvider provider, string context)
        {
            _dbProvider = provider;
            clientsCollectionName = context;

            _session = _dbProvider.GetSession(clientsCollectionName);
        }


        #region Create
        
        public void CreateClient(Client instance)
        {
            _session.Create(instance);
        }

        public async Task CreateClientAsync(Client instance)
        {
            await _session.CreateAsync(instance);
        }

        public void CreateClients(List<Client> instances)
        {
            _session.CreateMany(instances);
        }

        public async Task CreateClientsAsync(List<Client> instances)
        {
            await _session.CreateManyAsync(instances);
        }

        #endregion
        
        #region Read
        
        public Client ReadClient(long id)
        {
            var client = _session.Read<Client>(id);

            return client;
        }

        public async Task<Client> ReadClientAsync(long id)
        {
            var client = await _session.ReadAsync<Client>(id);

            return client;
        }

        public List<Client> ReadAllClients()
        {
            var clients = _session.ReadAll<Client>();

            return clients;
        }

        public async Task<List<Client>> ReadAllClientsAsync()
        {
            var task = _session.ReadAllAsync<Client>();

            var clients = await task;


            return clients;
        }
        
        #endregion
        
    }
}