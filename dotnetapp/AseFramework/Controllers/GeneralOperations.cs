namespace DotnetApp.AseFramework.Controllers
{
    #region using directives

    using System.IO;

    using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;

    #endregion

    /// <summary>
    ///     The general operations.
    /// </summary>
    public static class GeneralOperations
    {
        /// <summary>
        ///     The err_handling_bail_out.
        /// </summary>
        /// <param name="textWriter">
        ///     The text writer.
        /// </param>
        /// <param name="reason">
        ///     The reason.
        /// </param>
        public static void err_handling_bail_out(TextWriter textWriter, string reason = null)
        {
            EnvManager.WriteLine($"bailing out: rc .. {reason} // ");
        }
    }
}