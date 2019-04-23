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
        string Insert(SubtaskEntity subTaskEntity);

        /// <summary>
        /// Deletes a record from the SubTask table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);

        /// <summary>
        /// Selects a record from the SubTask table/collection by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SubtaskEntity Select(string id);
    }
}
