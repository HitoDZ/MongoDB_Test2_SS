using System.Threading.Tasks;
using Models;

namespace DbLayer
{
    /// <summary>
    /// Provide interface to interact with Db
    /// </summary>
    public interface IDbProvider
    {
        /// <summary>
        /// Synchroniously get client entity from
        /// db
        /// </summary>
        /// <param name="id">Client identifier</param>
        /// <param name="collectioName">Name of collection that contains info about clients</param>
        /// <returns>Client class</returns>
        Client GetClient(long id, string collectioName);

        /// <summary>
        /// Asynchroniously get client entity from
        /// db
        /// </summary>
        /// <param name="id">Client identifier</param>
        /// <param name="collectioName">Name of collection that contains info about clients</param>
        /// <returns>Client class</returns>
        Task<Client> GetClientAsync(long id, string collectionName);
    }
}