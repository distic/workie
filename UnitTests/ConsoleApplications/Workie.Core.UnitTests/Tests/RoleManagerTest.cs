using Utilities.Logger;
using Utilities.Logger.Base;
using Utilities.Logger.Enums;
using Workie.Core.BusinessLogic.Group;
using Workie.Core.Entities.Group;

namespace Workie.Core.UnitTests.Tests
{
    internal class RoleManagerTest
    {
        #region Properties

        private readonly RoleManager _roleManage;
        private string _id;

        #endregion

        #region Constructor

        internal RoleManagerTest()
        {
            _id = string.Empty;
            _roleManage = new RoleManager();
        }

        #endregion


        internal TestResultType Insert()
        {
            _id = _roleManage.Insert(new RoleEntity
            {
                Name = "Workie"
            });

            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new Role!");
            }

            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new Role with _id({_id})");
        }

        internal TestResultType Delete()
        {
            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "_id parameter was not passed, possible failure occurred when inserting.");
            }

            _roleManage.Delete(_id);

            if (_roleManage.SelectById(_id) == null)
            {
                return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully deleted the Role.");
            }

            return UnitTestOutputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), "Delete failed.");
        }
    }
}
