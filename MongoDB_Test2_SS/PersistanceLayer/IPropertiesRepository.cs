using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace PersistanceLayer
{
    public interface IPropertiesRepository
    {
        #region Create

        void CreateProperty(Properties property);

        Task CreatePropertyAsync(Properties property);

        void CreateProperties(List<Properties> properties);

        Task CreatePropertiesAsync(List<Properties> propertieses);

        #endregion

        #region Read

        Properties ReadProperty(long id);

        Task<Properties> ReadPropertyAsync(long id);
        

        #endregion
    }
}