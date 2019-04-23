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
    }
}
