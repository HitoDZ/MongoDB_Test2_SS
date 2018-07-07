using System.Threading.Tasks;
using Models;

namespace PersistanceLayer
{
    /// <summary>
    /// CRUD operations with clients
    /// </summary>
    public interface IClientsRepository
    {
        /// <summary>
        /// Synchroniously read info from DB and convert
        /// it into lient class
        /// </summary>
        /// <param name="id">Client`s id</param>
        /// <returns>CLient instance</returns>
        Client Read(long id);
        
        /// <summary>
        /// Asynchroniously read info from DB and convert
        /// it into lient class
        /// </summary>
        /// <param name="id">Client`s id</param>
        /// <returns>Task with client instance</returns>
        Task<Client> ReadAsync(long id);
    }
}