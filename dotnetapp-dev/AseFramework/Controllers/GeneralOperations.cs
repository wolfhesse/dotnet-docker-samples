#region

using System.IO;
using dotnetapp.EnvironmentSetup;

#endregion

namespace dotnetapp.AseFramework.Controllers
{
    public static class GeneralOperations
    {
        public static void err_handling_bail_out(TextWriter textWriter, string reason = null)
        {
            EnvManager.WriteLine($"bailing out: rc .. {reason} // ");
        }
    }
}