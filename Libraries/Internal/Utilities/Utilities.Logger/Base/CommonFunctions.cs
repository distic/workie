using Utilities.Logger.Enums;

namespace Utilities.Logger.Base
{
    internal static class CommonFunctions
    {
        /// <summary>
        /// Prints the prefix of the message only.
        /// </summary>
        /// <param name="outputterPrintType"></param>
        public static void PrintOutputterType(OutputterPrintType outputterPrintType, bool greyScale = false)
        {
            switch (outputterPrintType)
            {
                case OutputterPrintType.Error:
                    ConsoleEx.Write(Properties.Resources.ErrorPrefix, backgroundColor: ConsoleExColor.DarkRed, foregroundColor: ConsoleExColor.White, spaceAfter: 1, greyScale: greyScale);
                    break;

                case OutputterPrintType.Fatal:
                    ConsoleEx.WriteLine(Properties.Resources.FatalErrorPrefix, backgroundColor: ConsoleExColor.Red, foregroundColor: ConsoleExColor.White, greyScale: greyScale);
                    break;

                case OutputterPrintType.Success:
                    ConsoleEx.Write(Properties.Resources.OkPrefix, backgroundColor: ConsoleExColor.Green, foregroundColor: ConsoleExColor.Black, spaceAfter: 1, greyScale: greyScale);
                    break;

                case OutputterPrintType.Warning:
                    ConsoleEx.Write(Properties.Resources.WarningPrefix, backgroundColor: ConsoleExColor.Yellow, foregroundColor: ConsoleExColor.Black, spaceAfter: 1, greyScale: greyScale);
                    break;

                case OutputterPrintType.Information:
                    ConsoleEx.Write(Properties.Resources.InformationPrefix, backgroundColor: ConsoleExColor.DarkBlue, foregroundColor: ConsoleExColor.White, spaceAfter: 1, greyScale: greyScale);
                    break;

                case OutputterPrintType.Busy:
                    ConsoleEx.Write(Properties.Resources.BusyPrefix, spaceAfter: 1, greyScale: greyScale);
                    break;
            }
        }

    }
}