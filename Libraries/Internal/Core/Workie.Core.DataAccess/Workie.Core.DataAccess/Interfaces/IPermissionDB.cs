using Workie.Core.Entities.Group;

namespace Workie.Core.DataAccess.Interfaces
{
    internal interface IPermissionDB
    {
        /// <summary>
        /// Inserts a record in the Permission table/collection.
        /// </summary>
        /// <param name="permissionEntity"></param>
        /// <returns></returns>
        string Insert(PermissionEntity permissionEntity);

        /// <summary>
        /// Deletes a record from the Permission table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);

        /// <summary>
        /// Selects a record from the Permission table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PermissionEntity Select(string id);
    }
}
