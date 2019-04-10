using Utilities.Console;
using Utilities.Console.Data.Enum;
using Workie.Core.BusinessLogic.Environment;
using Workie.Core.Entities.Environment;

namespace Workie.Core.UnitTests.Tests
{
    internal class WebBrowserPlatformManagerTest
    {
        #region Properties

        private readonly WebBrowserPlatformManager _webBrowserPlatformManager;
        private WebBrowserPlatformEntity _webBrowserPlatformEntity;
        private int _id;

        #endregion

        #region Constructor

        internal WebBrowserPlatformManagerTest()
        {
            _id = 0;
            _webBrowserPlatformManager = new WebBrowserPlatformManager();
        }

        #endregion

        internal TestResultType Insert()
        {
            _id = _webBrowserPlatformManager.Insert(new WebBrowserPlatformEntity
            {
                Name = "Internet Explorer"
            });

            if (_id == 0)
            {
                return Outputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new Web Browser Platform!");
            }

            return Outputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new web browser platform with _id({_id})");
        }

        internal TestResultType Delete()
        {
            if (_id == 0)
            {
                return Outputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "_id parameter was not passed, possible failure occurred when inserting.");
            }

            _webBrowserPlatformManager.Delete(_id);

            if (_webBrowserPlatformManager.Select(_id) == null)
            {
                return Outputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully deleted the Web Browser Platform.");
            }

            return Outputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), "Delete failed.");
        }

        internal TestResultType SelectById()
        {
            _webBrowserPlatformEntity = _webBrowserPlatformManager.Select(_id);

            if (_webBrowserPlatformEntity == null)
            {
                return Outputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Failed to retrieve the webBrowserPlatformEntity with _id({_id})");
            }

            return Outputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully retrieved the webBrowserPlatformEntity with _id({_id})");
        }
    }
}
