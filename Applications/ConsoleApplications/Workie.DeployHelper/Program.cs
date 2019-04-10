using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Utilities.Console;
using Workie.DeployHelper.Models;

namespace Workie.DeployHelper
{
    class Program
    {
        private static ApplicationViewModel gApplicationViewModel;

        #region --- Output ---

        private static List<int> PrintMenu()
        {
            var choiceList = new List<int>();

            Console.WriteLine("Is SSL Enabled: {0}\n", gApplicationViewModel.Security.UseSsl ? "YES" : "NO");

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("");

            // Print choice
            Console.WriteLine("\t1) Setup environment...");
            Console.WriteLine("\t2) Install or update packages...");
            Console.WriteLine("\t3) Deploy Workie.Web.Admin...");
            Console.WriteLine("\t4) Deploy Workie.Web.Admin without config...");
            Console.WriteLine("\t5) Update Kestrel for Workie.Web.Admin...");

            choiceList.Add(1);
            choiceList.Add(2);
            choiceList.Add(3);
            choiceList.Add(4);
            choiceList.Add(5);

            Console.WriteLine("");

            return choiceList;
        }

        #endregion

        static void Main(string[] args)
        {
            const string jsonFile = "C:\\Users\\ahmad\\source\\repos\\workie-core\\Applications\\ConsoleApplications\\Workie.DeployHelper\\Workie.DeployHelper.Linux.json";

            Outputter.PrintTitle(Properties.Resources.AppTitle, withUnderline: true);

            Outputter.PrintNoInterruptionNotice(
                preDescription: Properties.Resources.PreDescription,
                withTimer: true,
                preDescriptionNewLineAfter: true);

            using (StreamReader streamReader = new StreamReader(jsonFile))
            {
                var fileContent = streamReader.ReadToEnd();
                gApplicationViewModel = JsonConvert.DeserializeObject<ApplicationViewModel>(fileContent);
            }

            var choice = 0;
            var choiceList = PrintMenu();

            while (true)
            {
                choice = Convert.ToInt32(Console.ReadLine().Trim());

                if (!choiceList.Contains(choice))
                {
                    choice = 0;
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;
                }
            }

            throw new NotImplementedException();
        }
    }
}