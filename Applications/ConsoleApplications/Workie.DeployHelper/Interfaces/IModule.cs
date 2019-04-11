using System.Collections.Generic;
using Workie.DeployHelper.Utilities;

namespace Workie.DeployHelper.Interfaces
{
    internal interface IModule
    {
        /// <summary>
        /// Runs the routine.
        /// </summary>
        /// <returns>The reported result of the operation.</returns>
        ModuleReport Run();

        /// <summary>
        /// Checks for any occurring conflicts.
        /// </summary>
        /// <returns>The reported result of the operation.</returns>
        ConflictReport GetConflictsReport();

        /// <summary>
        /// Identify what's missing and save it.
        /// </summary>
        /// <returns>The reported result of the operation.</returns>
        DependencyReport GetDependencyReport();
    }
}
