using Utilities.Console;
using Workie.Core.Entities.Users;
using Utilities.Console.Data.Enum;
using Workie.Core.BusinessLogic.Users;

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
            _id = _userManager.Insert(new UserEntity
            {
                FirstName = "Ahmad",
                LastName = "Chatila",
                EmailAddress = "sample@hotmail.com"
            });

            if (string.IsNullOrEmpty(_id))
            {
                return Outputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new user!");
            }

            return Outputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new user with _id({_id})");
        }

        internal TestResultType SelectById()
        {
            _userEntity = _userManager.Select(_id);

            if (_userEntity == null)
            {
                return Outputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Failed to retrieve the userEntity with _id({_id})");
            }
            return Outputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully retrieved the userEntity with _id({_id})");
        }

        internal TestResultType SelectByEmailAndPassword()
        {
            var email = _userEntity.EmailAddress;

            var obj = _userManager.SelectByEmailAndPassword(email, _mockPassword);

            if (obj == null)
            {
                return Outputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Either the user doesn't exist, or the password(\"{_mockPassword}\") didn't work. handle this!");
            }

            return Outputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully received user information.");
        }

        internal TestResultType Delete()
        {
            if (string.IsNullOrEmpty(_id))
            {
                return Outputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "_id parameter was not passed, possible failure occurred when inserting.");
            }

            _userManager.Delete(_id);

            if (_userManager.Select(_id) == null)
            {
                return Outputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully deleted the user.");
            }

            return Outputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), "Delete failed.");
        }
    }
}