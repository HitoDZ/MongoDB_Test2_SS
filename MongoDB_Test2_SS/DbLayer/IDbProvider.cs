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
        /// <returns>Client class</returns>
        Client GetClient(long id);
    }
}