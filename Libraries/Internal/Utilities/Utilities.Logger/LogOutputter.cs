using System;
using Utilities.Logger.Base;
using Utilities.Logger.Enums;

namespace Utilities.Logger
{
    public static class LogOutputter
    {
        public static void Print(string description)
        {
            Console.WriteLine(description);
        }

        public static void PrintSuccess(string description)
        {
            CommonFunctions.PrintOutputterType(OutputterPrintType.Success);
            Console.WriteLine(description);
        }

        public static void PrintWarning(string description)
        {
            CommonFunctions.PrintOutputterType(OutputterPrintType.Warning);
            Console.WriteLine(description);
        }

        public static void PrintError(string description)
        {
            CommonFunctions.PrintOutputterType(OutputterPrintType.Error);
            Console.WriteLine(description);
        }

        public static void PrintFatal(string description)
        {
            Console.WriteLine();
            CommonFunctions.PrintOutputterType(OutputterPrintType.Fatal);
            ConsoleEx.WriteLine(description, foregroundColor: ConsoleExColor.White, newLineAfter: 2);
        }

        public static void PrintInfo(string description, int newLineAfter = 0)
        {
            CommonFunctions.PrintOutputterType(OutputterPrintType.Information);
            ConsoleEx.WriteLine(description, newLineAfter: newLineAfter);
        }
    }
}