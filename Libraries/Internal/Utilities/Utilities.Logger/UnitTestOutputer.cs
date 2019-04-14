using System;
using System.Threading;
using Utilities.Logger.Base;
using Utilities.Logger.Enums;

namespace Utilities.Logger
{
    public static class UnitTestOutputter
    {
        #region --- Private Methods ---

        private static void PrintFunctionName(string functionName)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" FUNCTION: ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0}\n", functionName);

            Console.ResetColor();
        }

        private static void PrintMessage(string description, bool withLabel = true, bool withNewLine = true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (withLabel)
            {
                Console.Write("MESSAGE : ");
            }
            else
            {
                Console.Write(" ");
            }

            Console.ResetColor();

            if (withNewLine)
                Console.WriteLine("{0}", description);
            else
                Console.Write("{0}", description);

            if (withLabel)
                Console.WriteLine();
        }

        #endregion

        #region Notices

        /// <summary>
        /// Prints the final result of the test.
        /// </summary>
        /// <param name="faultCount"></param>
        public static void PrintFaultResult(ref int[] resultCounter)
        {
            var errors = resultCounter[(int)TestResultType.Error];
            var warnings = resultCounter[(int)TestResultType.Warning];

            ConsoleEx.PrintTitle(titleName: "TEST REPORT", withUnderline: true, underlineChar: '-');

            if (errors < 1 && warnings < 1)
            {
                System.Console.WriteLine("No errors occurred.");
            }
            else if (errors > 0 && warnings > 0)
            {
                System.Console.WriteLine("You have {0} error(s) and {1} warning(s). Please fix them and try running the tests again.", errors, warnings);
            }
            else if (errors > 0)
            {
                System.Console.WriteLine("You have {0} error(s). Please fix them and try running the tests again.", errors);
            }
            else if (warnings > 0)
            {
                System.Console.WriteLine("You have {0} warnings(s).", warnings);
            }

            System.Console.WriteLine();
        }

        #endregion

        /// <summary>
        /// Prints an error output to the console in a proper format.
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="description"></param>
        public static TestResultType LogError(string functionName, string description)
        {
            CommonFunctions.PrintOutputterType(OutputterPrintType.Error);
            PrintFunctionName(functionName);
            PrintMessage(description);
            return TestResultType.Error;
        }

        /// <summary>
        /// Prints a warning output to the console in a proper format.
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="description"></param>
        public static TestResultType LogWarning(string functionName, string description)
        {
            CommonFunctions.PrintOutputterType(OutputterPrintType.Warning);
            PrintFunctionName(functionName);
            PrintMessage(description);
            return TestResultType.Warning;
        }

        /// <summary>
        /// Prints a success output to the console in a proper format.
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="description"></param>
        public static TestResultType LogSuccess(string functionName, string description)
        {
            CommonFunctions.PrintOutputterType(OutputterPrintType.Success);
            PrintFunctionName(functionName);
            PrintMessage(description);
            return TestResultType.Success;
        }


    }
}