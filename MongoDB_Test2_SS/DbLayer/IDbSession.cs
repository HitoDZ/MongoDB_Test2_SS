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

        Properties GetProperties(long id);
    }
}