using System.Collections.Generic;
using Workie.Core.Entities.Apps.Todo;

namespace Workie.Core.DataAccess.Interfaces.Apps.Todo
{
    internal interface ISubtask
    {
        /// <summary>
        /// Inserts a record in the SubTask table/collection.
        /// </summary>
        /// <param name="subTaskEntity"></param>
        /// <returns></returns>
        string InsertSubtask(string taskId, SubtaskEntity subTaskEntity);

        /// <summary>
        /// Updates a Subtask in the Task table/collection.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="subtaskEntity"></param>
        void UpdateSubtask(string taskId, SubtaskEntity subtaskEntity);

        /// <summary>
        /// Deletes a record from the SubTask table/collection by Id.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="subtaskId"></param>
        void DeleteSubtask(string taskId, string subtaskId);
    }
}
