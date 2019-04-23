using System.Collections.Generic;
using Workie.Core.Entities.Apps.Todo;

namespace Workie.Core.DataAccess.Interfaces.Apps.Todo
{
    internal interface ITaskDB
    {
        /// <summary>
        /// Inserts a record in the Task table/collection.
        /// </summary>
        /// <param name="taskEntity"></param>
        /// <returns></returns>
        string Insert(TaskEntity taskEntity);

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
        TaskEntity Select(string id);

        /// <summary>
        /// Selects all tasks by TeamId.
        /// </summary>
        /// <returns></returns>
        List<TaskEntity> SelectAllByTeamId(string teamId);

    }
}
