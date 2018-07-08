using System.Collections.Generic;
using System.Threading.Tasks;
using DbLayer;
using Models;

namespace PersistanceLayer
{
    public class MongoPropertiesRepository : IPropertiesRepository
    {
        private IDbProvider _dbProvider;

        private string _workingCollection;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="provider">Provide intreactions with db</param>
        /// <param name="context">working collection</param>
        public MongoPropertiesRepository(IDbProvider provider, string context)
        {
            _dbProvider = provider;
            _workingCollection = context;
        }
        
        #region Create
        
        public void CreateProperty(Properties property)
        {
            throw new System.NotImplementedException();
        }

        public Task CreatePropertyAsync(Properties property)
        {
            throw new System.NotImplementedException();
        }

        public void CreateProperties(List<Properties> properties)
        {
            throw new System.NotImplementedException();
        }

        public Task CreatePropertiesAsync(List<Properties> propertieses)
        {
            throw new System.NotImplementedException();
        }
        
        #endregion

        #region Read 
        
        public Properties ReadProperty(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Properties> ReadPropertyAsync(long id)
        {
            throw new System.NotImplementedException();
        }
        
        #endregion
        
    }
}