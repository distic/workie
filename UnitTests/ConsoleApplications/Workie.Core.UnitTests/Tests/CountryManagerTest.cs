using Utilities.Logger;
using Utilities.Logger.Base;
using Utilities.Logger.Enums;
using Workie.Core.BusinessLogic.Setup;
using Workie.Core.Entities.Setup;

namespace Workie.Core.UnitTests.Tests
{
    internal class CountryManagerTest
    {
        #region Properties

        private readonly CountryManager _countryManager;
        private CountryEntity _countryEntity;
        private int _id;

        #endregion

        #region Constructor

        internal CountryManagerTest()
        {
            _id = 0;
            _countryManager = new CountryManager();
        }

        #endregion

        internal TestResultType Insert()
        {
            _id = _countryManager.Insert(new CountryEntity
            {
                Name = "Lebanon",
                Abbreviation = "LB",
                _defaultLanguageId = 1
            });

            if (_id == 0)
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new Country!");
            }

            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new country with _id({_id})");
        }

        internal TestResultType Delete()
        {
            if (_id == 0)
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "_id parameter was not passed, possible failure occurred when inserting.");
            }

            _countryManager.Delete(_id);

            if (_countryManager.SelectById(_id) == null)
            {
                return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully deleted the company.");
            }

            return UnitTestOutputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), "Delete failed.");
        }

        internal TestResultType SelectById()
        {
            _countryEntity = _countryManager.SelectById(_id);

            if (_countryEntity == null)
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Failed to retrieve the countryEntity with _id({_id})");
            }
            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully retrieved the countryEntity with _id({_id})");
        }
    }
}
