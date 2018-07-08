using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace PersistanceLayer
{
    /// <summary>
    /// CRUD operations with clients
    /// </summary>
    public interface IClientsRepository
    {
        #region Create

        /// <summary>
        /// Synchronously create client instance in db
        /// </summary>
        /// <param name="instance">Client`s instance</param>
        void CreateClient(Client instance);

        /// <summary>
        /// Aynchronously create client instance in db
        /// </summary>
        /// <param name="instance">Client`s instance</param>
        Task CreateClientAsync(Client instance);

        /// <summary>
        /// Synchronously create client instances in db
        /// </summary>
        /// <param name="instances">List of instance</param>
        void CreateClients(List<Client> instances);

        /// <summary>
        /// Asynchronously create client instances in db
        /// </summary>
        /// <param name="instances">List of instance</param>
        Task CreateClientsAsync(List<Client> instances);

        #endregion
        
        #region Read
        
        /// <summary>
        /// Synchroniously read info from DB and convert
        /// it into lient class
        /// </summary>
        /// <param name="id">Client`s id</param>
        /// <returns>CLient instance</returns>
        Client ReadClient(long id);
        
        /// <summary>
        /// Asynchroniously read info from DB and convert
        /// it into lient class
        /// </summary>
        /// <param name="id">Client`s id</param>
        /// <returns>Task with client instance</returns>
        Task<Client> ReadClientAsync(long id);

        /// <summary>
        /// Synchroniously read info from DB and convert
        /// it into list of all clients
        /// </summary>
        /// <returns>List of all clients instances</returns>
        List<Client> ReadAllClients();
        
        /// <summary>
        /// Asynchroniously read info from DB and convert
        /// it into list of all clients
        /// </summary>
        /// <returns>Task woth list of all clients instances</returns>
        Task<List<Client>> ReadAllClientsAsync();
        
        #endregion
        
    }
}