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

        /// <summary>
        /// Synchronously create instance in the db
        /// </summary>
        /// <param name="instance">Instance to create</param>
        /// <typeparam name="T">Type of instance</typeparam>
        void Create<T>(T instance) where T : IIdentifieble;

        /// <summary>
        /// Asynchronously create instance in the db
        /// </summary> 
        /// <param name="instance">Instance to create</param>
        /// <typeparam name="T">Type of instance</typeparam>
        Task CreateAsync<T>(T instance) where T : IIdentifieble;

        /// <summary>
        /// Synchronously create instances in the db
        /// </summary>
        /// <param name="instances">Instances to create</param>
        /// <typeparam name="T">Type of instance</typeparam>
        void CreateMany<T>(List<T> instances) where T : IIdentifieble;
        
        /// <summary>
        /// Asynchronously create instance in the db
        /// </summary>
        /// <param name="instances">Instances to create</param>
        /// <typeparam name="T">Type of instances</typeparam>
        Task CreateManyAsync<T>(List<T> instances) where T : IIdentifieble;
        
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