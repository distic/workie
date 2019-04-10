using Utilities.Console;
using Utilities.Console.Data.Enum;
using Workie.Core.BusinessLogic.Environment;
using Workie.Core.Entities.Environment;

namespace Workie.Core.UnitTests.Tests
{
    internal class OSPlatformManagerTest
    {
        #region Properties

        private readonly OSPlatformManager _osPlatformManager;
        private OSPlatformEntity _osPlatformEntity;
        private int _id;

        #endregion

        #region Constructor

        internal OSPlatformManagerTest()
        {
            _id = 0;
            _osPlatformManager = new OSPlatformManager();
        }

        #endregion

        internal TestResultType Insert()
        {
            _id = _osPlatformManager.Insert(new OSPlatformEntity
            {
                Name = "Windows 10"
            });

            if (_id == 0)
            {
                return Outputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new OS Platform!");
            }

            return Outputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new platform with _id({_id})");
        }

        internal TestResultType Delete()
        {
            if (_id == 0)
            {
                return Outputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "_id parameter was not passed, possible failure occurred when inserting.");
            }

            _osPlatformManager.Delete(_id);

            if (_osPlatformManager.Select(_id) == null)
            {
                return Outputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully deleted the OS Platform.");
            }

            return Outputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), "Delete failed.");
        }

        internal TestResultType SelectById()
        {
            _osPlatformEntity = _osPlatformManager.Select(_id);

            if (_osPlatformEntity == null)
            {
                return Outputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Failed to retrieve the osPlatformEntity with _id({_id})");
            }

            return Outputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully retrieved the osPlatformEntity with _id({_id})");
        }
    }
}
