using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DbLayer
{
    /// <summary>
    /// Interface to interact with one of db collections
    /// during one session
    /// </summary>
    public interface IDbSession
    {
        /// <summary>
        /// Synchroniously get client entity from
        /// db
        /// </summary>
        /// <returns>Client class</returns>
        Client GetClient(long id);

        /// <summary>
        /// Asynchroniously get client entity from
        /// db
        /// </summary>
        /// <param name="id">Client identifier</param>
        /// <returns>Task of getting client</returns>
        Task<Client> GetClientAsync(long id);

        /// <summary>
        /// Synchroniouslt get properties class
        /// </summary>
        /// <param name="id">Property identifier</param>
        /// <returns>Property class</returns>
        Properties GetProperties(long id);

        /// <summary>
        /// Asynchroniously get properties class
        /// </summary>
        /// <param name="id">Property identifier</param>
        /// <returns>Task with property</returns>
        Task<Properties> GetPropertiesAsync(long id);

        /// <summary>
        /// Synchroniously get all clients from db
        /// </summary>
        /// <returns>List of clients</returns>
        List<Client> GetClients();

        /// <summary>
        /// Asynchroniously get all clients from db
        /// </summary>
        /// <returns>Task with list of clients</returns>
        Task<List<Client>> GetClientsAsync();
    }
}