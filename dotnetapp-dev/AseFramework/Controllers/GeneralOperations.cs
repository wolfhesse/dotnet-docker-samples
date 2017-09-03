#region

using System.IO;

#endregion

namespace dotnetapp.AseFramework.Controllers
{
    public static class GeneralOperations
    {
        public static void err_handling_bail_out(TextWriter textWriter, string reason = null)
        {
            textWriter.WriteLine($"bailing out: rc .. {reason} // ");
////            throw new NotImplementedException();
        }
    }
}