#region using directives

using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;

#endregion

namespace DotnetApp.AseFramework.Controllers
{
    #region using directives

    #endregion

    /// <summary>
    ///     The general operations.
    /// </summary>
    public static class GeneralOperations
    {
        /// <summary>
        ///     The err_handling_bail_out.
        /// </summary>
        /// <param name="reason">
        ///     The reason.
        /// </param>
        public static void ErrHandlingBailOut(string reason = null)
        {
            EnvManager.WriteLine($"bailing out: rc .. {reason} // ");
        }
    }
}