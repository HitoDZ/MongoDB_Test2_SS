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
            var session = _dbProvider.GetSession(_workingCollection);
            
            session.Create(property);
        }

        public async Task CreatePropertyAsync(Properties property)
        {
            var session = _dbProvider.GetSession(_workingCollection);

            await session.CreateAsync(property);
        }

        public void CreateProperties(List<Properties> properties)
        {
            var session = _dbProvider.GetSession(_workingCollection);
            
            session.CreateMany(properties);
        }

        public async Task CreatePropertiesAsync(List<Properties> properties)
        {
            var session = _dbProvider.GetSession(_workingCollection);

            await session.CreateManyAsync(properties);
        }
        
        #endregion

        #region Read 
        
        public Properties ReadProperty(long id)
        {
            var session = _dbProvider.GetSession(_workingCollection);

            var property = session.Read<Properties>(id);

            return property;
        }

        public async Task<Properties> ReadPropertyAsync(long id)
        {
            var session = _dbProvider.GetSession(_workingCollection);

            var property = await session.ReadAsync<Properties>(id);

            return property;
        }
        
        #endregion
        
    }
}