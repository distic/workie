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

        public static void PrintSuccess(string description, int newLineAfter = 0, bool greyScale = false)
        {
            CommonFunctions.PrintOutputterType(OutputterPrintType.Success);
            ConsoleEx.WriteLine(description, newLineAfter: newLineAfter, greyScale: greyScale);
        }

        public static void PrintWarning(string description, int newLineAfter = 0, bool greyScale = false)
        {
            CommonFunctions.PrintOutputterType(OutputterPrintType.Warning);
            ConsoleEx.WriteLine(description, newLineAfter: newLineAfter, greyScale: greyScale);
        }

        public static void PrintError(string description, int newLineAfter = 0, bool greyScale = false)
        {
            CommonFunctions.PrintOutputterType(OutputterPrintType.Error);
            ConsoleEx.WriteLine(description, newLineAfter: newLineAfter, greyScale: greyScale);
        }

        public static void PrintFatal(string description)
        {
            Console.WriteLine();
            CommonFunctions.PrintOutputterType(OutputterPrintType.Fatal);
            ConsoleEx.WriteLine(description, foregroundColor: ConsoleExColor.White, newLineAfter: 2);
        }

        public static void PrintInfo(string description, int newLineAfter = 0, bool greyScale = false)
        {
            CommonFunctions.PrintOutputterType(OutputterPrintType.Information, greyScale: greyScale);
            ConsoleEx.WriteLine(description, newLineAfter: newLineAfter);
        }
    }
}