using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace PersistanceLayer
{
    public interface IRepository<T> where T : IIdentifieble
    {
        /// <summary>
        /// Change working context
        /// </summary>
        /// <param name="newContext">new context to work in</param>
        void ChangeContext(string newContext);
        
        #region Create

        /// <summary>
        /// Synchronously create instance in db
        /// </summary>
        /// <param name="instance">T instance</param>
        void Create(T instance);

        /// <summary>
        /// Asynchronously create instance in db
        /// </summary>
        /// <param name="instance">T instance</param>
        Task CreateAsync(T instance);

        /// <summary>
        /// Synchronously create instances in db
        /// </summary>
        /// <param name="instances">Collection of T instances</param>
        void CreateMany(IEnumerable<T> instances);

        /// <summary>
        /// Asynchronously create instances in db
        /// </summary>
        /// <param name="instances">Collection of T instances</param>
        Task CreateManyAsync(IEnumerable<T> instances);

        #endregion

        #region Read

        /// <summary>
        /// Synchronously read T instance from db
        /// </summary>
        /// <param name="id">Id of T instance</param>
        /// <returns>T instance</returns>
        T Read(long id);

        /// <summary>
        /// Asynchronously read T instance from db
        /// </summary>
        /// <param name="id">Id of T instance</param>
        /// <returns>T instance</returns>
        Task<T> ReadAsync(long id);

        /// <summary>
        /// Synchronously read all T insances form db
        /// </summary>
        /// <returns>Collection of T instances</returns>
        IEnumerable<T> ReadAll();

        /// <summary>
        /// Asynchronously read all T insances form db
        /// </summary>
        /// <returns>Collection of T instances</returns>
        Task<IEnumerable<T>> ReadAllAsync();

        #endregion
    }
}