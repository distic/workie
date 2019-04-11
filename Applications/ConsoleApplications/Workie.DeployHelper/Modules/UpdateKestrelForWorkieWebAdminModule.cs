using Workie.DeployHelper.Utilities;

namespace Workie.DeployHelper.Modules
{
    internal class UpdateKestrelForWorkieWebAdminModule : ModuleBase
    {
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

        public override ModuleReport Run()
        {
            var result = base.Run();
            if (result != null) { return result; }

            return null;
        }
    }
}
