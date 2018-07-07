using System.Threading.Tasks;
using Models;

namespace DbLayer
{
    /// <summary>
    /// Provide interface to interact with Db via sessions
    /// </summary>
    public interface IDbProvider
    {
        /// <summary>
        /// Get session to interact with one of the
        /// db collections
        /// </summary>
        /// <param name="context">collection name</param>
        /// <returns></returns>
        IDbSession GetSession(string context);
    }
}