namespace Workie.DeployHelper.Enums
{
    /// <summary>
    /// Used for identifying result from the Main Menu.
    /// </summary>
    enum MainMenuResult
    {
        SetupEnvironment = 0,
        InstallOrUpdatePackages = 1,
        DeployWorkieWebAdmin = 2,
        DeployWorkieWebAdminWithoutConfig = 3,
        UpdateKestrelForWorkieWebAdmin = 4
    }
}
