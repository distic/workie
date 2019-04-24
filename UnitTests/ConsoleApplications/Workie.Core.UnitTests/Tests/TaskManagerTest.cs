using Utilities.Logger;
using Utilities.Logger.Base;
using Utilities.Logger.Enums;
using Workie.Core.BusinessLogic.Apps.Todo;
using Workie.Core.Entities.Apps.Todo;

namespace Workie.Core.UnitTests.Tests
{
    internal class TaskManagerTest
    {
        #region Properties

        private readonly TaskManager _taskManager;
        private string _id;
        private string _subtaskId;

        #endregion

        #region Constructor

        internal TaskManagerTest()
        {
            _id = string.Empty;
            _taskManager = new TaskManager();
        }

        #endregion

        internal TestResultType Insert()
        {
            _id = _taskManager.Insert(new TaskEntity
            {
                Title = "Workie"
            });

            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new Task!");
            }

            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new Task with _id({_id})");
        }

        internal TestResultType Delete()
        {
            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "_id parameter was not passed, possible failure occurred when inserting.");
            }

            _taskManager.Delete(_id);

            if (_taskManager.SelectById(_id) == null)
            {
                return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully deleted the company.");
            }

            return UnitTestOutputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), "Delete failed.");
        }

        internal TestResultType InsertSubtask()
        {
            _subtaskId = _taskManager.InsertSubtask(_id, new SubtaskEntity
            {
                Description = "This is a random description",
                Owner_userIdsList = null
            });

            if (string.IsNullOrEmpty(_subtaskId))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new Subtask!");
            }

            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new Subtask with _id({_subtaskId}) in Task_id({_id})");
        }

        internal TestResultType UpdateSubtask()
        {
            _taskManager.UpdateSubtask(_id, new SubtaskEntity
            {
                _id = _subtaskId,
                Description = "This is a random modified description",
                Owner_userIdsList = null
            });

            return UnitTestOutputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Modified subtask with _id({_subtaskId}) in Task_id({_id})");
        }
    }
}
