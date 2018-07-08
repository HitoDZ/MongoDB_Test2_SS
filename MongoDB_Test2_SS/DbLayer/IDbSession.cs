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
        #region ToDelete
        
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

        #endregion
        
        #region Create

        void Create<T>(T instance);

        void CreateAsync<T>(T instance);

        void CreateMany<T>(List<T> instancies);
        
        void CreateManyAsync<T>(List<T> instancies);
        
        #endregion
        
        #region Read
        
        /// <summary>
        /// Synchronously Read one item from the collection
        /// </summary>
        /// <param name="id">item identifier</param>
        /// <typeparam name="T">item type</typeparam>
        /// <returns>T instance</returns>
        T Read<T>(long id);

        /// <summary>
        /// Asynchronously Read one item from the collection
        /// </summary>
        /// <param name="id">item identifier</param>
        /// <typeparam name="T">item type</typeparam>
        /// <returns>Task with T instance</returns>
        Task<T> ReadAsync<T>(long id);

        /// <summary>
        /// Synchronously Read all items from the collection
        /// </summary>
        /// <typeparam name="T">items type</typeparam>
        /// <returns>List of T instancies</returns>
        List<T> ReadAll<T>();

        /// <summary>
        /// Asynchronously Read all items from the collection
        /// </summary>
        /// <typeparam name="T">items type</typeparam>
        /// <returns>Task with List of T instancies</returns>
        Task<List<T>> ReadAllAsync<T>();
        
        #endregion
    }
}