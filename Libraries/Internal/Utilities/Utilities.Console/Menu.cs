using System;

namespace Utilities.Console
{
    public class Menu
    {
        public static int MultipleChoice(bool withNumbering, bool canCancel, string description, params string[] options)
        {
            if (!string.IsNullOrEmpty(description))
            {
                System.Console.WriteLine("\n-> {0}\n", description);
            }

            int startX = System.Console.CursorLeft;
            int startY = System.Console.CursorTop;
            const int optionsPerLine = 1;
            const int spacingPerLine = 14;

            int currentSelection = 0;

            ConsoleKey key;

            System.Console.CursorVisible = false;

            do
            {
                for (int i = 0; i < options.Length; i++)
                {
                    System.Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                    {
                        System.Console.BackgroundColor = ConsoleColor.White;
                        System.Console.ForegroundColor = ConsoleColor.Black;
                    }

                    if (withNumbering)
                    {
                        System.Console.Write("{0}) {1}...", i+1, options[i]);
                    }
                    else
                    {
                        System.Console.Write(options[i]);
                    }

                    System.Console.ResetColor();
                }

                key = System.Console.ReadKey(true).Key;

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

            System.Console.CursorVisible = true;

            System.Console.WriteLine("\n");

            return currentSelection;
        }
    }
}
