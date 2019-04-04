using System;
using Utilities.Console;

namespace Workie.DeployHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Outputter.PrintTitle(Properties.Resources.AppTitle, withUnderline: true);

            Outputter.PrintNoInterruptionNotice(
                preDescription: Properties.Resources.PreDescription, 
                withTimer: true,
                preDescriptionNewLineAfter: true);

            throw new NotImplementedException();
        }
    }
}