using System.Collections.Generic;
using System.Threading.Tasks;
using DbLayer;
using Models;

namespace PersistanceLayer
{
    public class MongoPropertiesRepository : IPropertiesRepository
    {
        private IDbProvider _dbProvider;
        private IDbSession _session;

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

            _session = _dbProvider.GetSession(_workingCollection);
        }
        
        public void ChangeContext(string newContext)
        {
            _workingCollection = newContext;

            _session = _dbProvider.GetSession(_workingCollection);
        }
        
        #region Create

        public void CreateProperty(Properties property)
        {
            _session.Create(property);
        }

        public async Task CreatePropertyAsync(Properties property)
        {
            await _session.CreateAsync(property);
        }

        public void CreateProperties(List<Properties> properties)
        {
            _session.CreateMany(properties);
        }

        public async Task CreatePropertiesAsync(List<Properties> properties)
        {
            await _session.CreateManyAsync(properties);
        }
        
        #endregion

        #region Read 
        
        public Properties ReadProperty(long id)
        {
            var property = _session.Read<Properties>(id);

            return property;
        }

        public async Task<Properties> ReadPropertyAsync(long id)
        {
            var property = await _session.ReadAsync<Properties>(id);

            return property;
        }
        
        #endregion
        
    }
}