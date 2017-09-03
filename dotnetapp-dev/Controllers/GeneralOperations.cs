#region

#endregion

namespace DotnetApp.Controllers
{
    using System.IO;

    using DotnetApp.EnvironmentSetup;

    public static class GeneralOperations
    {
        public static void err_handling_bail_out(TextWriter textWriter, string reason = null)
        {
            EnvManager.WriteLine($"bailing out: rc .. {reason} // ");
        }
    }
}