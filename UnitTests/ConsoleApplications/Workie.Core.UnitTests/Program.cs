using Utilities.Console;
using Utilities.Console.Data.Enum;
using Utilities.Console.Data.Struct;
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

        static TestResultInfo UserTest()
        {
            var userManagerTest = new UserManagerTest();

            _resultCounter[(int)userManagerTest.Insert()] += 1;
            _resultCounter[(int)userManagerTest.SelectById()] += 1;
            _resultCounter[(int)userManagerTest.SelectByEmailAndPassword()] += 1;
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

        static void Main(string[] args)
        {
            _resultCounter = new int[3];

            Outputter.PrintTitle(titleName: Properties.Resources.AppTitle, withUnderline: true);
            Outputter.PrintNoInterruptionNotice(preDescription: Properties.Resources.PreDescription, withTimer: true);

            // Start testing the User module..
            var userTestResult = UserTest();

            #region --- Result ---

            Outputter.PrintFaultResult(ref _resultCounter);

            #endregion

            Outputter.PrintExitMessageAndHold();
        }
    }
}