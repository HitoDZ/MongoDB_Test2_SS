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
        
        #region Create

        void Create<T>(T instance) where T : IIdentifieble;

        void CreateAsync<T>(T instance) where T : IIdentifieble;

        void CreateMany<T>(List<T> instancies) where T : IIdentifieble;
        
        void CreateManyAsync<T>(List<T> instancies) where T : IIdentifieble;
        
        #endregion
        
        #region Read

        /// <summary>
        /// Synchronously Read one item from the collection
        /// </summary>
        /// <param name="id">item identifier</param>
        /// <typeparam name="T">item type</typeparam>
        /// <returns>T instance</returns>
        T Read<T>(long id) where T : IIdentifieble;

        /// <summary>
        /// Asynchronously Read one item from the collection
        /// </summary>
        /// <param name="id">item identifier</param>
        /// <typeparam name="T">item type</typeparam>
        /// <returns>Task with T instance</returns>
        Task<T> ReadAsync<T>(long id) where T : IIdentifieble;

        /// <summary>
        /// Synchronously Read all items from the collection
        /// </summary>
        /// <typeparam name="T">items type</typeparam>
        /// <returns>List of T instancies</returns>
        List<T> ReadAll<T>() where T : IIdentifieble;

        /// <summary>
        /// Asynchronously Read all items from the collection
        /// </summary>
        /// <typeparam name="T">items type</typeparam>
        /// <returns>Task with List of T instancies</returns>
        Task<List<T>> ReadAllAsync<T>() where T : IIdentifieble;
        
        #endregion
    }
}