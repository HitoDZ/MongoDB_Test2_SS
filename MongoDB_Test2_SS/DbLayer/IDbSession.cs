using System.Threading.Tasks;
using Models;

namespace DbLayer
{
    /// <summary>
    /// Interact with one of db collections/tables
    /// </summary>
    public interface IDbSession
    {
        /// <summary>
        /// Synchroniously get client entity from
        /// db
        /// </summary>
        /// <param name="id">Client identifier</param>
        /// <param name="collectioName">Name of collection that contains info about clients</param>
        /// <returns>Client class</returns>
        Client GetClient(long id);

        /// <summary>
        /// Asynchroniously get client entity from
        /// db
        /// </summary>
        /// <param name="id">Client identifier</param>
        /// <param name="collectioName">Name of collection that contains info about clients</param>
        /// <returns>Client class</returns>
        Task<Client> GetClientAsync(long id);

        Properties GetProperties(long id);
    }
}