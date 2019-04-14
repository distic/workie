using Utilities.Logger;
using Utilities.Logger.Base;
using Utilities.Logger.Enums;
using Workie.Core.BusinessLogic.Users;
using Workie.Core.Entities.Users;

namespace Workie.Core.UnitTests.Tests
{
    internal class UserManagerTest
    {
        #region Properties

        private readonly UserManager _userManager;
        private UserEntity _userEntity;
        private const string _mockPassword = "YouWillNeverGetThis";
        private string _id;

        #endregion

        #region Constructor

        internal UserManagerTest()
        {
            _id = string.Empty;
            _userManager = new UserManager();
        }

        #endregion

        internal TestResultType Insert()
        {
            //TODO: Add real values here!
            _id = _userManager.Insert(new UserEntity
            {
                FirstName = "Ahmad",
                LastName = "Chatila",
                EmailAddress = "sample@hotmail.com",
                _countryId = 1,
                _companyId = 1,
                _termsAndConditionId = "fawokfwifej"
            });

            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new user!");
            }

            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new user with _id({_id})");
        }

        internal TestResultType SelectById()
        {
            _userEntity = _userManager.Select(_id);

            if (_userEntity == null)
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Failed to retrieve the userEntity with _id({_id})");
            }
            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully retrieved the userEntity with _id({_id})");
        }

        internal TestResultType SelectByEmailAndPassword()
        {
            var email = _userEntity.EmailAddress;

            var obj = _userManager.SelectByEmailAndPassword(email, _mockPassword);

            if (obj == null)
            {
                return UnitTestOutputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Either the user doesn't exist, or the password(\"{_mockPassword}\") didn't work. handle this!");
            }

            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully received user information.");
        }

        internal TestResultType Delete()
        {
            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "_id parameter was not passed, possible failure occurred when inserting.");
            }

            _userManager.Delete(_id);

            if (_userManager.Select(_id) == null)
            {
                return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully deleted the user.");
            }

            return UnitTestOutputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), "Delete failed.");
        }
    }
}