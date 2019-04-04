using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Utilities.Console
{
    public class AssemblyInfo
    {
        /// <summary>
        /// Gets the Application Name
        /// </summary>
        public static string GetApplicationName
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Name;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod(string className = "")
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            if (string.IsNullOrEmpty(className))
            {
                return sf.GetMethod().Name;
            }

            return $"{className}::{sf.GetMethod().Name}";
        }
    }
}
