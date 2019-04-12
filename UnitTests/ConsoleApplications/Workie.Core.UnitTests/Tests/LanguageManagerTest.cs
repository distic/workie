using Utilities.Logger;
using Utilities.Logger.Enums;
using Workie.Core.BusinessLogic.Setup;
using Workie.Core.Entities.Setup;

namespace Workie.Core.UnitTests.Tests
{
    internal class LanguageManagerTest
    {
        #region Properties

        private readonly LanguageManager _languageManager;
        private LanguageEntity _languageEntity;
        private int _id;

        #endregion

        #region Constructor

        internal LanguageManagerTest()
        {
            _id = 0;
            _languageManager = new LanguageManager();
        }

        #endregion

        internal TestResultType Insert()
        {
            _id = _languageManager.Insert(new LanguageEntity
            {
                Name = "English (United States)",
                Reference = "en-US"
            });

            if (_id == 0)
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new Language!");
            }

            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new language with _id({_id})");
        }

        internal TestResultType Delete()
        {
            if (_id == 0)
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "_id parameter was not passed, possible failure occurred when inserting.");
            }

            _languageManager.Delete(_id);

            if (_languageManager.SelectById(_id) == null)
            {
                return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully deleted the language.");
            }

            return UnitTestOutputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), "Delete failed.");
        }

        internal TestResultType SelectById()
        {
            _languageEntity = _languageManager.SelectById(_id);

            if (_languageEntity == null)
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Failed to retrieve the languageEntity with _id({_id})");
            }
            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully retrieved the languageEntity with _id({_id})");
        }
    }
}
