using System;
using Utilities.Logger.Base;
using Utilities.Logger.Enums;

namespace Utilities.Logger
{
    public static class LogOutputter
    {
        public static void Print(string description, int newLineAfter = 0, bool greyScale = false, bool isSub = false)
        {
            if (isSub)
            {
                ConsoleEx.WriteLine($"\t* {description}", foregroundColor: ConsoleExColor.White, greyScale: greyScale, newLineAfter: newLineAfter);
            }
            else
            {
                ConsoleEx.WriteLine(description);
            }
        }

        public static void PrintSuccess(string description, int newLineAfter = 0, bool greyScale = false, bool isSub = false)
        {
            if (isSub)
            {
                ConsoleEx.WriteLine($"\t* {description}", foregroundColor: ConsoleExColor.Green, greyScale: greyScale, newLineAfter: newLineAfter);
            }
            else
            {
                CommonFunctions.PrintOutputterType(OutputterPrintType.Success);
                ConsoleEx.WriteLine(description, newLineAfter: newLineAfter, greyScale: greyScale);
            }
        }

        public static void PrintWarning(string description, int newLineAfter = 0, bool greyScale = false, bool isSub = false)
        {
            if (isSub)
            {
                ConsoleEx.WriteLine($"\t* {description}", foregroundColor: ConsoleExColor.Yellow, greyScale: greyScale, newLineAfter: newLineAfter);
            }
            else
            {
                CommonFunctions.PrintOutputterType(OutputterPrintType.Warning);
                ConsoleEx.WriteLine(description, newLineAfter: newLineAfter, greyScale: greyScale);
            }
        }

        public static void PrintError(string description, int newLineAfter = 0, bool greyScale = false, bool isSub = false)
        {
            if (isSub)
            {
                ConsoleEx.WriteLine($"\t* {description}", foregroundColor: ConsoleExColor.Red, greyScale: greyScale, newLineAfter: newLineAfter);
            }
            else
            {
                CommonFunctions.PrintOutputterType(OutputterPrintType.Error);
                ConsoleEx.WriteLine(description, newLineAfter: newLineAfter, greyScale: greyScale);
            }
        }

        public static void PrintFatal(string description)
        {
            Console.WriteLine();
            CommonFunctions.PrintOutputterType(OutputterPrintType.Fatal);
            ConsoleEx.WriteLine(description, foregroundColor: ConsoleExColor.White, newLineAfter: 2);
        }

        public static void PrintInfo(string description, int newLineAfter = 0, bool greyScale = false, bool isSub = false)
        {
            CommonFunctions.PrintOutputterType(OutputterPrintType.Information, greyScale: greyScale);
            ConsoleEx.WriteLine(description, newLineAfter: newLineAfter);
        }

        public static void PrintBusy(string description, int newLineAfter = 0, bool greyScale = false, bool isSub = false)
        {
            CommonFunctions.PrintOutputterType(OutputterPrintType.Busy, greyScale: greyScale);
            ConsoleEx.WriteLine(description, newLineAfter: newLineAfter);
        }
    }
}