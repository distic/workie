using System.IO;
using Workie.DeployHelper.Utilities;

namespace Workie.DeployHelper.Extensions
{
    public static class StringExtensions
    {
        public static string TryParseModuleDependencyVariable(this string str)
        {
            var variable = string.Empty;

            int indexOfAmp1 = str.IndexOf('%') + 1;
            int indexOfAmp2;

            for (indexOfAmp2 = indexOfAmp1; str[indexOfAmp2] != '%'; indexOfAmp2++)
            {
                variable += str[indexOfAmp2];
            }

            if (indexOfAmp2 == indexOfAmp1)
            {
                return string.Empty;
            }

            return variable;
        }

        public static string TryParseModuleDependencyVariableAndAfter(this string str)
        {
            var variable = string.Empty;

            int indexOfAmp1 = str.IndexOf('%') + 1;
            int indexOfAmp2 = -1;

            for (var i = indexOfAmp1; i < str.Length; i++)
            {
                if (str[i] == '%')
                {
                    indexOfAmp2 = i;
                    break;
                }

                variable += str[i];
            }

            if (indexOfAmp2 == -1)
            {
                return string.Empty;
            }

            if (indexOfAmp2 == indexOfAmp1)
            {
                return string.Empty;
            }

            indexOfAmp2 += 1;

            var startGet = str.IndexOf('\\', indexOfAmp2) + 1;

            if (startGet != 0)
            {
                return Path.Combine(variable, str.Substring(startGet, str.Length - startGet));
            }

            startGet = str.IndexOf('/', indexOfAmp2) + 1;

            if (startGet != 0)
            {
                return Path.Combine(variable, str.Substring(startGet, str.Length - startGet));
            }

            return variable;
        }

        public static string ModuleDependencyAbsolutePath(this string str)
        {
            var variable = TryParseModuleDependencyVariableAndAfter(str);

            if (string.IsNullOrEmpty(variable))
            {
                return string.Empty;
            }

            return Path.Combine(Globals.GetModuleDependenciesDirectory, variable);
        }

        public static string Filename(this string str)
        {
            var indexOfEither = str.LastIndexOf('\\') + 1;

            if (indexOfEither != 0)
            {
                return str.Substring(indexOfEither, str.Length - indexOfEither);
            }

            indexOfEither = str.LastIndexOf('/') + 1;

            if (indexOfEither != 0)
            {
                return str.Substring(indexOfEither, str.Length - indexOfEither);
            }

            return string.Empty;
        }
    }
}
