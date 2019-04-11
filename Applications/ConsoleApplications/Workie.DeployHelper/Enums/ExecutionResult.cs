namespace Workie.DeployHelper.Enums
{
    /// <summary>
    /// Used for identifying the result of an operation.
    /// Mainly used for running Module.
    /// </summary>
    enum ExecutionResult
    {
        Unknown = -1,
        Success = 0,
        Warning = 1,
        Failure = 2,
        UserCancel = 3
    }
}
