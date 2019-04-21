using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Workie.DeployHelper.Models;

namespace Workie.DeployHelper.Base
{
    public static class Globals
    {
        #region --- Properties ---

        internal static ApplicationViewModel gApplicationViewModel;

        #endregion

        /// <summary>
        /// Gets the _InstallData folder.
        /// </summary>
        internal static string GetInstallDataDirectory
        {
            get
            {
                var prefixPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}";
                return Path.Combine(prefixPath, "_InstallData");
            }
        }

        /// <summary>
        /// Gets the module dependencies folder.
        /// </summary>
        internal static string GetModuleDependenciesDirectory
        {
            get
            {
                return Path.Combine(GetInstallDataDirectory, "ModuleDependencies");
            }
        }

        /// <summary>
        /// Gets the config filename that corresponds to the platform.
        /// </summary>
        internal static string GetConfigFilename
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly().GetName().Name;

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    return Path.Combine(GetInstallDataDirectory, $"{assembly}.Win32.json");
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    return Path.Combine(GetInstallDataDirectory, $"{assembly}.Linux.json");
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    return Path.Combine(GetInstallDataDirectory, $"{assembly}.MacOS.json");
                }

                return string.Empty;
            }
        }
    }
}
