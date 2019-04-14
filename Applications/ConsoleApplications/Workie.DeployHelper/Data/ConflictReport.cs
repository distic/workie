using Workie.DeployHelper.Enums;

namespace Workie.DeployHelper.Data
{
    internal class ConflictReport
    {
        #region --- Private Properties ---

        private bool gIsCompleted { get; set; }

        private ExecutionResult gExecutionResult { get; set; }

        #endregion

        #region --- Public Properties ---

        public bool IsCompleted { get { return gIsCompleted; } }

        public ExecutionResult ExecutionResult { get { return gExecutionResult; } }

        #endregion

        internal ConflictReport(ExecutionResult executionResult = ExecutionResult.Unknown, bool isCompleted = true)
        {
            gExecutionResult = executionResult;
            gIsCompleted = isCompleted;
        }
    }
}