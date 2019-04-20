using Workie.Core.Entities.Group;

namespace Workie.Core.DataAccess.Interfaces
{
    internal interface ITeamRoleDB
    {
        /// <summary>
        /// Inserts a record in the Task table/collection.
        /// </summary>
        /// <param name="teamRoleEntity"></param>
        /// <returns></returns>
        string Insert(TeamRoleEntity teamRoleEntity);

        /// <summary>
        /// Deletes a record from the Task table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);

        /// <summary>
        /// Selects a record from the Task table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TeamRoleEntity Select(string id);
    }
}
