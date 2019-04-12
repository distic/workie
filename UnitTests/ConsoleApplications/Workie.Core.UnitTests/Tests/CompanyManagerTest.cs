using Utilities.Logger;
using Utilities.Logger.Enums;
using Workie.Core.BusinessLogic.Setup;
using Workie.Core.Entities.Setup;

namespace Workie.Core.UnitTests.Tests
{
    internal class CompanyManagerTest
    {
        #region Properties

        private readonly CompanyManager _companyManager;
        private CompanyEntity _companyEntity;
        private string _id;

        #endregion

        #region Constructor

        internal CompanyManagerTest()
        {
            _id = string.Empty;
            _companyManager = new CompanyManager();
        }

        #endregion

        internal TestResultType Insert()
        {
            _id = _companyManager.Insert(new CompanyEntity
            {
                Name = "Microsoft"
            });

            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new Company!");
            }

            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new company with _id({_id})");
        }

        internal TestResultType Delete()
        {
            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "_id parameter was not passed, possible failure occurred when inserting.");
            }

            _companyManager.Delete(_id);

            if (_companyManager.SelectById(_id) == null)
            {
                return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully deleted the company.");
            }

            return UnitTestOutputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), "Delete failed.");
        }

        internal TestResultType SelectById()
        {
            _companyEntity = _companyManager.SelectById(_id);

            if (_companyEntity == null)
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Failed to retrieve the companyEntity with _id({_id})");
            }
            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully retrieved the companyEntity with _id({_id})");
        }
    }
}
