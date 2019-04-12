using Utilities.Logger;
using Utilities.Logger.Enums;
using Workie.Core.BusinessLogic.Legal;
using Workie.Core.Entities.Legal;

namespace Workie.Core.UnitTests.Tests
{
    internal class TermsAndConditionsTest
    {
        #region Properties

        private readonly TermsAndConditionsManager _termsAndConditionsManager;
        private TermsAndConditionsEntity _termsAndConditionsEntity;
        private string _id;

        #endregion

        #region Constructor

        internal TermsAndConditionsTest()
        {
            _id = string.Empty;
            _termsAndConditionsManager = new TermsAndConditionsManager();
        }

        #endregion

        internal TestResultType Insert()
        {
            _id = _termsAndConditionsManager.Insert(new TermsAndConditionsEntity
            {
                Name = "GPL 2.0",
                Description = "This is the GPL 2.0",
                Version = 1.01,
                _languageId = 1
            });

            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "Failed to insert a new TermsAndConditions!");
            }

            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully added new terms and conditions with _id({_id})");
        }

        internal TestResultType Delete()
        {
            if (string.IsNullOrEmpty(_id))
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), "_id parameter was not passed, possible failure occurred when inserting.");
            }

            _termsAndConditionsManager.Delete(_id);

            if (_termsAndConditionsManager.Select(_id) == null)
            {
                return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), "Successfully deleted the company.");
            }

            return UnitTestOutputter.LogWarning(AssemblyInfo.GetCurrentMethod(GetType().Name), "Delete failed.");
        }

        internal TestResultType SelectById()
        {
            _termsAndConditionsEntity = _termsAndConditionsManager.Select(_id);

            if (_termsAndConditionsEntity == null)
            {
                return UnitTestOutputter.LogError(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Failed to retrieve the termsAndConditionsEntity with _id({_id})");
            }
            return UnitTestOutputter.LogSuccess(AssemblyInfo.GetCurrentMethod(GetType().Name), $"Successfully retrieved the termsAndConditionsEntity with _id({_id})");
        }
    }
}
