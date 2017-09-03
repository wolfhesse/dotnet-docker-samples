#region

#endregion

namespace DotnetApp.AbstractArchitecture
{
    using System.IO;

    public class Helper
    {
        public static void FnOutSeparator72(TextWriter textWriter, char character = '_')
        {
            textWriter.WriteLine(new string(character, 72));
        }
    }
}