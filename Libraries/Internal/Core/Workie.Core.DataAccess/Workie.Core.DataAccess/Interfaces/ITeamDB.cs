using Workie.Core.Entities.Group;

namespace Workie.Core.DataAccess.Interfaces
{
    internal interface ITeamDB
    {
        /// <summary>
        /// Inserts a record in the Team table/collection.
        /// </summary>
        /// <param name="teamEntity"></param>
        /// <returns></returns>
        string Insert(TeamEntity teamEntity);

        /// <summary>
        /// Deletes a record from the Team table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);

        /// <summary>
        /// Selects a record from the Team table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TeamEntity Select(string id);
    }
}
