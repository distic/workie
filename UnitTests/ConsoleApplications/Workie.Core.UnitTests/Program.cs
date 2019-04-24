using Utilities.Logger;
using Utilities.Logger.Base;
using Utilities.Logger.Data;
using Utilities.Logger.Enums;
using Workie.Core.UnitTests.Tests;

namespace Workie.Core.UnitTests
{
    class Program
    {
        //
        // Test Result Counter
        //
        // Index 0 = Success Counter
        // Index 1 = Warning Counter
        // Index 2 = Error Counter
        //
        private static int[] _resultCounter;

        #region --- Tests ---

        static TestResultInfo UserTest()
        {
            var userManagerTest = new UserManagerTest();

            _resultCounter[(int)userManagerTest.Insert()] += 1;
            _resultCounter[(int)userManagerTest.SelectById()] += 1;
            _resultCounter[(int)userManagerTest.SelectByEmailAndPassword()] += 1;
            _resultCounter[(int)userManagerTest.SelectByEmail()] += 1;
            _resultCounter[(int)userManagerTest.RaiseAttentionForResetPassword()] += 1;
            _resultCounter[(int)userManagerTest.RaiseAttentionForChangePassword()] += 1;
            _resultCounter[(int)userManagerTest.Delete()] += 1;

            //
            // Wrap up the results and return...
            //
            return new TestResultInfo
            {
                ErrorCount = _resultCounter[(int)TestResultType.Error],
                WarningCount = _resultCounter[(int)TestResultType.Warning],
                SuccessCount = _resultCounter[(int)TestResultType.Success]
            };
        }

        static TestResultInfo OSPlatformTest()
        {
            var osPlatformManagerTest = new OSPlatformManagerTest();

            _resultCounter[(int)osPlatformManagerTest.Insert()] += 1;
            _resultCounter[(int)osPlatformManagerTest.SelectById()] += 1;
            _resultCounter[(int)osPlatformManagerTest.Delete()] += 1;

            //
            // Wrap up the results and return...
            //
            return new TestResultInfo
            {
                ErrorCount = _resultCounter[(int)TestResultType.Error],
                WarningCount = _resultCounter[(int)TestResultType.Warning],
                SuccessCount = _resultCounter[(int)TestResultType.Success]
            };
        }

        static TestResultInfo WebBrowserPlatformTest()
        {
            var webBrowserPlatformManagerTest = new WebBrowserPlatformManagerTest();

            _resultCounter[(int)webBrowserPlatformManagerTest.Insert()] += 1;
            _resultCounter[(int)webBrowserPlatformManagerTest.SelectById()] += 1;
            _resultCounter[(int)webBrowserPlatformManagerTest.Delete()] += 1;

            //
            // Wrap up the results and return...
            //
            return new TestResultInfo
            {
                ErrorCount = _resultCounter[(int)TestResultType.Error],
                WarningCount = _resultCounter[(int)TestResultType.Warning],
                SuccessCount = _resultCounter[(int)TestResultType.Success]
            };
        }

        static TestResultInfo CompanyTest()
        {
            var companyManagerTest = new CompanyManagerTest();

            _resultCounter[(int)companyManagerTest.Insert()] += 1;
            _resultCounter[(int)companyManagerTest.SelectById()] += 1;
            _resultCounter[(int)companyManagerTest.Delete()] += 1;

            //
            // Wrap up the results and return...
            //
            return new TestResultInfo
            {
                ErrorCount = _resultCounter[(int)TestResultType.Error],
                WarningCount = _resultCounter[(int)TestResultType.Warning],
                SuccessCount = _resultCounter[(int)TestResultType.Success]
            };
        }

        static TestResultInfo CountryTest()
        {
            var countryManagerTest = new CountryManagerTest();

            _resultCounter[(int)countryManagerTest.Insert()] += 1;
            _resultCounter[(int)countryManagerTest.SelectById()] += 1;
            _resultCounter[(int)countryManagerTest.Delete()] += 1;

            //
            // Wrap up the results and return...
            //
            return new TestResultInfo
            {
                ErrorCount = _resultCounter[(int)TestResultType.Error],
                WarningCount = _resultCounter[(int)TestResultType.Warning],
                SuccessCount = _resultCounter[(int)TestResultType.Success]
            };
        }

        static TestResultInfo LanguageTest()
        {
            var languageManagerTest = new LanguageManagerTest();

            _resultCounter[(int)languageManagerTest.Insert()] += 1;
            _resultCounter[(int)languageManagerTest.SelectById()] += 1;
            _resultCounter[(int)languageManagerTest.Delete()] += 1;

            //
            // Wrap up the results and return...
            //
            return new TestResultInfo
            {
                ErrorCount = _resultCounter[(int)TestResultType.Error],
                WarningCount = _resultCounter[(int)TestResultType.Warning],
                SuccessCount = _resultCounter[(int)TestResultType.Success]
            };
        }

        static TestResultInfo TermsAndConditionsTest()
        {
            var termsAndConditionsTest = new TermsAndConditionsTest();

            _resultCounter[(int)termsAndConditionsTest.Insert()] += 1;
            _resultCounter[(int)termsAndConditionsTest.SelectById()] += 1;
            _resultCounter[(int)termsAndConditionsTest.Delete()] += 1;

            //
            // Wrap up the results and return...
            //
            return new TestResultInfo
            {
                ErrorCount = _resultCounter[(int)TestResultType.Error],
                WarningCount = _resultCounter[(int)TestResultType.Warning],
                SuccessCount = _resultCounter[(int)TestResultType.Success]
            };
        }

        static TestResultInfo TaskTest()
        {
            var taskManagerTest = new TaskManagerTest();

            _resultCounter[(int)taskManagerTest.Insert()] += 1;
            _resultCounter[(int)taskManagerTest.InsertSubtask()] += 1;
            _resultCounter[(int)taskManagerTest.UpdateSubtask()] += 1;
            _resultCounter[(int)taskManagerTest.Delete()] += 1;

            //
            // Wrap up the results and return...
            //
            return new TestResultInfo
            {
                ErrorCount = _resultCounter[(int)TestResultType.Error],
                WarningCount = _resultCounter[(int)TestResultType.Warning],
                SuccessCount = _resultCounter[(int)TestResultType.Success]
            };
        }

        static TestResultInfo TeamRoleTest()
        {
            var teamRoleManagerTest = new TeamRoleManagerTest();

            _resultCounter[(int)teamRoleManagerTest.Insert()] += 1;
            _resultCounter[(int)teamRoleManagerTest.Delete()] += 1;

            //
            // Wrap up the results and return...
            //
            return new TestResultInfo
            {
                ErrorCount = _resultCounter[(int)TestResultType.Error],
                WarningCount = _resultCounter[(int)TestResultType.Warning],
                SuccessCount = _resultCounter[(int)TestResultType.Success]
            };
        }
        static TestResultInfo TeamTest()
        {
            var teamManagerTest = new TeamManagerTest();

            _resultCounter[(int)teamManagerTest.Insert()] += 1;
            _resultCounter[(int)teamManagerTest.Delete()] += 1;

            //
            // Wrap up the results and return...
            //
            return new TestResultInfo
            {
                ErrorCount = _resultCounter[(int)TestResultType.Error],
                WarningCount = _resultCounter[(int)TestResultType.Warning],
                SuccessCount = _resultCounter[(int)TestResultType.Success]
            };
        }

        static TestResultInfo RoleTest()
        {
            var roleManagerTest = new RoleManagerTest();

            _resultCounter[(int)roleManagerTest.Insert()] += 1;
            _resultCounter[(int)roleManagerTest.Delete()] += 1;

            //
            // Wrap up the results and return...
            //
            return new TestResultInfo
            {
                ErrorCount = _resultCounter[(int)TestResultType.Error],
                WarningCount = _resultCounter[(int)TestResultType.Warning],
                SuccessCount = _resultCounter[(int)TestResultType.Success]
            };
        }

        #endregion

        static void Main(string[] args)
        {
            _resultCounter = new int[3];

            ConsoleEx.PrintTitle(titleName: Properties.Resources.AppTitle, withUnderline: true);
            ConsoleEx.PrintNoInterruptionNotice();

            //
            // Comment out the unnecessary ones...
            //

            //var userTestResult = UserTest();
            //var osPlatformTestResult = OSPlatformTest();
            //var webBrowserPlatformTestResult = WebBrowserPlatformTest();
            //var companyTestResult = CompanyTest();
            //var countryTestResult = CountryTest();
            //var languageTestResult = LanguageTest();
            //var termsAndConditionsTest = TermsAndConditionsTest();
            var taskTest = TaskTest();
            //var roleTest = RoleTest();
            //var teamTest = TeamTest();
            //var teamRoleTest = TeamRoleTest();

            #region --- Result ---

            UnitTestOutputter.PrintFaultResult(ref _resultCounter);

            #endregion

            ConsoleEx.PrintExitMessageAndHold();
        }
    }
}