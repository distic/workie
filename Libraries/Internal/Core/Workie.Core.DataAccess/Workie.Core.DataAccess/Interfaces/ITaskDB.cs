using Workie.Core.Entities.Tasks;

namespace Workie.Core.DataAccess.Interfaces
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

    }
}
