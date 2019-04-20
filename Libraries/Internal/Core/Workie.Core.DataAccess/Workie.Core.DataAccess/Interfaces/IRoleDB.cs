using Workie.Core.Entities.Group;

namespace Workie.Core.DataAccess.Interfaces
{
    internal interface IRoleDB
    {
        /// <summary>
        /// Inserts a record in the Role table/collection.
        /// </summary>
        /// <param name="roleEntity"></param>
        /// <returns></returns>
        string Insert(RoleEntity roleEntity);

        /// <summary>
        /// Deletes a record from the Role table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);

        /// <summary>
        /// Selects a record from the Role table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RoleEntity Select(string id);
    }
}
