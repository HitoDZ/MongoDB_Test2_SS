using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace PersistanceLayer
{
    public interface IPropertiesRepository
    {
        #region Create

        /// <summary>
        /// Synchronously create property insance in db
        /// </summary>
        /// <param name="property">Property instance</param>
        void CreateProperty(Properties property);

        /// <summary>
        /// Asynchronously create property instance in db
        /// </summary>
        /// <param name="property">Property instance</param>
        /// <returns>Task with creating instance</returns>
        Task CreatePropertyAsync(Properties property);

        /// <summary>
        /// Synchronously create lis of property insances in db
        /// </summary>
        /// <param name="properties">Property instances</param>
        void CreateProperties(List<Properties> properties);

        /// <summary>
        /// Asynchronously create property instances in db
        /// </summary>
        /// <param name="properties">List of properties</param>
        /// <returns>Task with creating</returns>
        Task CreatePropertiesAsync(List<Properties> properties);

        #endregion

        #region Read

        /// <summary>
        /// Synchronously read property from db
        /// </summary>
        /// <param name="id">Id of property</param>
        /// <returns>Property instance</returns>
        Properties ReadProperty(long id);

        /// <summary>
        /// Asynchronously read porperty from db
        /// </summary>
        /// <param name="id">Id of property</param>
        /// <returns>Task with property instance</returns>
        Task<Properties> ReadPropertyAsync(long id);
        

        #endregion
    }
}