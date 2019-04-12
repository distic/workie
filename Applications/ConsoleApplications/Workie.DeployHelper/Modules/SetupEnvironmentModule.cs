using Workie.DeployHelper.Utilities;

namespace Workie.DeployHelper.Modules
{
    internal class SetupEnvironmentModule : ModuleBase
    {
        public override ModuleReport Run()
        {
            var result = base.Run();
            if (result != null) { return result; }

            return null;
        }

        #region --- Validation Functions ---

        public override ConflictReport GetConflictsReport()
        {
            var report = new ConflictReport();

            return report;
        }

        public override DependencyReport GetDependencyReport()
        {
            var report = new DependencyReport();

            return report;
        }

        #endregion
    }
}