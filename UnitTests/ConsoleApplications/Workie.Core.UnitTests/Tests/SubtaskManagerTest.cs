using Utilities.Logger;
using Utilities.Logger.Base;
using Utilities.Logger.Enums;
using Workie.Core.BusinessLogic.SubTask;
using Workie.Core.Entities.SubTask;

namespace Workie.Core.UnitTests.Tests
{
    internal class SubtaskManagerTest
    {
        #region Properties

        private readonly SubtaskManager _subTaskManager;
        private string _id;

        #endregion

        #region Constructor

        internal SubtaskManagerTest()
        {
            _id = string.Empty;
            _subTaskManager = new SubtaskManager();
        }

        #endregion

        internal TestResultType Insert()
        {
            _id = _subTaskManager.Insert(new SubtaskEntity
            {
                Name = "Workie",
                Description = "Db"
            });

            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new SubTask!");
            }

            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new SubTask with _id({_id})");
        }

        internal TestResultType Delete()
        {
            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "_id parameter was not passed, possible failure occurred when inserting.");
            }

            _subTaskManager.Delete(_id);

            if (_subTaskManager.SelectById(_id) == null)
            {
                return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully deleted the SubTask.");
            }

            return UnitTestOutputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), "Delete failed.");
        }
    }
}
