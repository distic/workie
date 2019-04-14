using Workie.Core.Entities.Environment;

namespace Workie.Core.DataAccess.Interfaces
{
    internal interface IOSPlatformDB
    {
        /// <summary>
        /// Inserts an OSPlatform record.
        /// </summary>
        /// <param name="osPlatform"></param>
        /// <returns>Returns the index of the inserted entry.</returns>
        int Insert(OSPlatformEntity osPlatform);
        
        /// <summary>
        /// Selects an OSPlatform record by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the OSPlatform object.</returns>
        OSPlatformEntity Select(int id);

        /// <summary>
        /// Deletes a record from the OSPlatform table/collection.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
