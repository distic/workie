using System;
using System.Reflection;
using System.Threading;
using Utilities.Logger.Enums;

namespace Utilities.Logger.Base
{
    public static class ConsoleEx
    {
        /// <summary>
        /// Prints the message prior to starting the process.
        /// </summary>
        /// <param name="secondsWait">Time in seconds to show the message.</param>
        public static void PrintNoInterruptionNotice(int secondsWait = 1)
        {
            WriteLine("It is strongly recommended that you do not interrupt this operation until its finished.", foregroundColor: ConsoleExColor.Yellow, newLineAfter: 1);

            // OPTIONAL, give the user some time to read...
            Thread.Sleep(secondsWait * 1000);
        }

        /// <summary>
        /// Prints the license notice.
        /// </summary>
        /// <param name="secondsWait"></param>
        public static void PrintLicenseNotice(int secondsWait = 2)
        {
            Console.WriteLine("\nCopyright (C) 2019 Distic. All rights reserved.\n");

            Console.WriteLine("Copyright (C) 1989, 1991 Free Software Foundation, Inc.,\n" +
                "\t51 Franklin Street, Fifth Floor, Boston, MA 02110 - 1301 USA\n" +
                "\tEveryone is permitted to copy and distribute verbatim copies\n" +
                "\tof this license document, but changing it is not allowed.\n");

            // OPTIONAL, give the user some time to read...
            Thread.Sleep(secondsWait * 1000);
        }

        /// <summary>
        /// Prints the exit message before closing
        /// </summary>
        public static void PrintExitMessageAndHold()
        {
            Console.WriteLine("-> Press ENTER to bail out.");
            Console.ReadLine();
        }

        /// <summary>
        /// Prints the title to the console window.
        /// </summary>
        /// <param name="titleName"></param>
        /// <param name="withUnderline"></param>
        /// <param name="underlineChar"></param>
        public static void PrintTitle(string titleName = "", bool withUnderline = false, char underlineChar = '=')
        {
            Console.WriteLine("");

            var title = string.IsNullOrEmpty(titleName) ? Assembly.GetExecutingAssembly().GetName().Name : titleName;

            Console.WriteLine(title);

            foreach (var ch in title)
            {
                Console.Write(underlineChar);
            }

            Console.WriteLine("\n");
        }

        /// <summary>
        /// Prints a line with custom text and background colors.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="foregroundColor"></param>
        /// <param name="backgroundColor"></param>
        public static void WriteLine(string text, ConsoleExColor foregroundColor = ConsoleExColor.Default, ConsoleExColor backgroundColor = ConsoleExColor.Default, int newLineAfter = 0)
        {
            Console.BackgroundColor = (backgroundColor.Equals(ConsoleExColor.Default)) ? Console.BackgroundColor : (ConsoleColor)backgroundColor;
            Console.ForegroundColor = (foregroundColor.Equals(ConsoleExColor.Default)) ? Console.ForegroundColor : (ConsoleColor)foregroundColor;
            Console.WriteLine(text);
            Console.ResetColor();

            for (var i = 0; i < newLineAfter; i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints on the same line with custom text and background colors.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="foregroundColor"></param>
        /// <param name="backgroundColor"></param>
        public static void Write(string text, ConsoleExColor foregroundColor = ConsoleExColor.Default, ConsoleExColor backgroundColor = ConsoleExColor.Default, int spaceAfter = 0)
        {
            Console.BackgroundColor = (backgroundColor.Equals(ConsoleExColor.Default)) ? Console.BackgroundColor : (ConsoleColor)backgroundColor;
            Console.ForegroundColor = (foregroundColor.Equals(ConsoleExColor.Default)) ? Console.ForegroundColor : (ConsoleColor)foregroundColor;
            Console.Write(text);
            Console.ResetColor();

            for (var i = 0; i < spaceAfter; i++)
            {
                Console.Write(" ");
            }
        }
    }
}
