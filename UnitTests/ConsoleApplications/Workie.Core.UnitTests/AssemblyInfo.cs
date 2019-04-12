using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Workie.Core.UnitTests
{
    internal class AssemblyInfo
    {
        /// <summary>
        /// Gets the executing method name.
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
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
