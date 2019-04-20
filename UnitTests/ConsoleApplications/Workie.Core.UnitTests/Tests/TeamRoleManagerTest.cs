using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Logger;
using Utilities.Logger.Base;
using Utilities.Logger.Enums;
using Workie.Core.BusinessLogic.Group;
using Workie.Core.Entities.Group;

namespace Workie.Core.UnitTests.Tests
{
    internal class TeamRoleManagerTest
    {
        #region Properties

        private readonly TeamRoleManager _teamRoleManager;
        private string _id;

        #endregion

        #region Constructor

        internal TeamRoleManagerTest()
        {
            _id = string.Empty;
            _teamRoleManager = new TeamRoleManager();
        }

        #endregion


        internal TestResultType Insert()
        {
            _id = _teamRoleManager.Insert(new TeamRoleEntity
            {
                _teamId = "1123",
                _userId = "123",
                _roleId = "4352"
            });

            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new TeamRole!");
            }

            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new TeamRole with _id({_id})");
        }

        internal TestResultType Delete()
        {
            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "_id parameter was not passed, possible failure occurred when inserting.");
            }

            _teamRoleManager.Delete(_id);

            if (_teamRoleManager.SelectById(_id) == null)
            {
                return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully deleted the TeamRole.");
            }

            return UnitTestOutputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), "Delete failed.");
        }
    }
}
