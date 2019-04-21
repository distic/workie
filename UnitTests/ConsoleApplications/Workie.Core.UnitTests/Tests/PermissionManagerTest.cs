using Utilities.Logger;
using Utilities.Logger.Base;
using Utilities.Logger.Enums;
using Workie.Core.BusinessLogic.Group;
using Workie.Core.Entities.Group;

namespace Workie.Core.UnitTests.Tests
{
    internal class PermissionManagerTest
    {
        #region Properties

        private readonly PermissionManager _permissionManage;
        private string _id;

        #endregion

        #region Constructor

        internal PermissionManagerTest()
        {
            _id = string.Empty;
            _permissionManage = new PermissionManager();
        }

        #endregion


        internal TestResultType Insert()
        {
            _id = _permissionManage.Insert(new PermissionEntity
            {
                Name = "Workie"
            });

            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new Permission!");
            }

            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new Permission with _id({_id})");
        }

        internal TestResultType Delete()
        {
            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "_id parameter was not passed, possible failure occurred when inserting.");
            }

            _permissionManage.Delete(_id);

            if (_permissionManage.SelectById(_id) == null)
            {
                return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully deleted the Permission.");
            }

            return UnitTestOutputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), "Delete failed.");
        }
    }
}
