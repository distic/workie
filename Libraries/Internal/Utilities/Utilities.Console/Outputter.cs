using System;
using System.Threading;
using Utilities.Console.Data.Enum;

namespace Utilities.Console
{
    public class Outputter
    {
        #region --- Private Methods ---

        private static void PrintOutputterType(OutputterPrintType outputterPrintType)
        {
            switch (outputterPrintType)
            {
                case OutputterPrintType.Error:
                    System.Console.BackgroundColor = ConsoleColor.Red;
                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.Write("[ ERR ]");
                    break;

                case OutputterPrintType.Success:
                    System.Console.BackgroundColor = ConsoleColor.Green;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                    System.Console.Write("[ OKI ]");
                    break;

                case OutputterPrintType.Warning:
                    System.Console.BackgroundColor = ConsoleColor.Yellow;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                    System.Console.Write("[ WRN ]");
                    break;
            }

            System.Console.ResetColor();
        }

        private static void PrintFunctionName(string functionName)
        {
            System.Console.ForegroundColor = ConsoleColor.Magenta;
            System.Console.Write(" FUNCTION: ");
            System.Console.ResetColor();

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("{0}\n", functionName);

            System.Console.ResetColor();
        }

        private static void PrintMessage(string description)
        {
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Write("MESSAGE : ");
            System.Console.ResetColor();

            System.Console.WriteLine("{0}", description);
            System.Console.WriteLine();
        }

        #endregion

        #region --- Public Methods ---

        #region Notices

        /// <summary>
        /// Prints the title on the console window.
        /// </summary>
        /// <param name="withUnderline">If set to true, the title will be underlined.</param>
        public static void PrintTitle(string titleName = "", bool withUnderline = false, char underlineChar = '=')
        {
            System.Console.WriteLine("");

            var title = string.IsNullOrEmpty(titleName) ? AssemblyInfo.GetApplicationName : titleName;

            System.Console.WriteLine(title);

            foreach (var ch in title)
            {
                System.Console.Write(underlineChar);
            }

            System.Console.WriteLine("\n");
        }

        /// <summary>
        /// Prints the message prior to starting the process.
        /// </summary>
        /// <param name="withTimer"></param>
        public static void PrintNoInterruptionNotice(string preDescription = "", bool preDescriptionNewLineAfter = false, bool withTimer = true)
        {
            System.Console.ForegroundColor = ConsoleColor.Yellow;

            if (!string.IsNullOrEmpty(preDescription))
            {
                System.Console.WriteLine(preDescription);

                if (preDescriptionNewLineAfter)
                {
                    System.Console.WriteLine();
                }
            }

            System.Console.WriteLine("It is strongly recommended that you do not interrupt this operation until its finished.");
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.ResetColor();

            // OPTIONAL, give the user some time to read...
            if (withTimer)
                Thread.Sleep(1000);
        }

        /// <summary>
        /// Prints the final result of the test.
        /// </summary>
        /// <param name="faultCount"></param>
        public static void PrintFaultResult(ref int[] resultCounter)
        {
            var errors = resultCounter[(int)TestResultType.Error];
            var warnings = resultCounter[(int)TestResultType.Warning];

            PrintTitle(titleName: "TEST REPORT", withUnderline: true, underlineChar: '-');

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

        /// <summary>
        /// Prints the exit message before closing
        /// </summary>
        public static void PrintExitMessageAndHold()
        {
            System.Console.WriteLine("-> Press ENTER to bail out.");
            System.Console.ReadLine();
        }

        #endregion

        #region Log Methods

        /// <summary>
        /// Prints an error output to the console in a proper format.
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="description"></param>
        public static TestResultType LogError(string functionName, string description)
        {
            PrintOutputterType(OutputterPrintType.Error);
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
            PrintOutputterType(OutputterPrintType.Warning);
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
            PrintOutputterType(OutputterPrintType.Success);
            PrintFunctionName(functionName);
            PrintMessage(description);
            return TestResultType.Success;
        }

        #endregion

        #endregion
    }
}