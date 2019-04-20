
using Utilities.Logger;
using Utilities.Logger.Base;
using Utilities.Logger.Enums;
using Workie.Core.BusinessLogic.Group;
using Workie.Core.Entities.Group;

namespace Workie.Core.UnitTests.Tests
{
    internal class TeamManagerTest
    {
        #region Properties

        private readonly TeamManager _teamManager;
        private string _id;

        #endregion

        #region Constructor

        internal TeamManagerTest()
        {
            _id = string.Empty;
            _teamManager = new TeamManager();
        }

        #endregion


        internal TestResultType Insert()
        {
            _id = _teamManager.Insert(new TeamEntity
            {
                Name = "Workie" ,
                Description = "DB"
            });

            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new Team!");
            }

            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new Team with _id({_id})");
        }

        internal TestResultType Delete()
        {
            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "_id parameter was not passed, possible failure occurred when inserting.");
            }

            _teamManager.Delete(_id);

            if (_teamManager.SelectById(_id) == null)
            {
                return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully deleted the Team.");
            }

            return UnitTestOutputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), "Delete failed.");
        }
    }
}
