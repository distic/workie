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
        public static void WriteLine(string text, ConsoleExColor foregroundColor = ConsoleExColor.Default, ConsoleExColor backgroundColor = ConsoleExColor.Default, int newLineAfter = 0, bool greyScale = false)
        {
            if (!greyScale)
            {
                Console.BackgroundColor = (backgroundColor.Equals(ConsoleExColor.Default)) ? Console.BackgroundColor : (ConsoleColor)backgroundColor;
                Console.ForegroundColor = (foregroundColor.Equals(ConsoleExColor.Default)) ? Console.ForegroundColor : (ConsoleColor)foregroundColor;
            }
            else
            {
                Console.BackgroundColor = (ConsoleColor)ConsoleExColor.White;
                Console.ForegroundColor = (ConsoleColor)ConsoleExColor.Black;
            }

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
        public static void Write(string text, ConsoleExColor foregroundColor = ConsoleExColor.Default, ConsoleExColor backgroundColor = ConsoleExColor.Default, int spaceAfter = 0, bool greyScale = false)
        {
            if (!greyScale)
            {
                Console.BackgroundColor = (backgroundColor.Equals(ConsoleExColor.Default)) ? Console.BackgroundColor : (ConsoleColor)backgroundColor;
                Console.ForegroundColor = (foregroundColor.Equals(ConsoleExColor.Default)) ? Console.ForegroundColor : (ConsoleColor)foregroundColor;
            }
            else
            {
                Console.BackgroundColor = (ConsoleColor)ConsoleExColor.White;
                Console.ForegroundColor = (ConsoleColor)ConsoleExColor.Black;
            }

            Console.Write(text);
            Console.ResetColor();

            for (var i = 0; i < spaceAfter; i++)
            {
                Console.Write(" ");
            }
        }

        /// <summary>
        /// Prints a multiple choice menu.
        /// </summary>
        /// <param name="withNumbering"></param>
        /// <param name="canCancel"></param>
        /// <param name="description"></param>
        /// <param name="options"></param>
        /// <returns>The index of the selection.</returns>
        public static int MultipleChoice(bool withNumbering, bool canCancel, string description, params string[] options)
        {
            if (!string.IsNullOrEmpty(description))
            {
                Console.WriteLine("\n-> {0}\n", description);
            }

            int startX = Console.CursorLeft;
            int startY = Console.CursorTop;
            const int optionsPerLine = 1;
            const int spacingPerLine = 0;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (withNumbering)
                    {
                        Console.Write("{0}) {1}...", i + 1, options[i]);
                    }
                    else
                    {
                        Console.Write(options[i]);
                    }

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                currentSelection++;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Length)
                                currentSelection += optionsPerLine;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            Console.WriteLine("\n");

            return currentSelection;
        }
    }
}
