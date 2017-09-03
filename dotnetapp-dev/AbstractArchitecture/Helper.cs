#region

using System.IO;

#endregion

namespace dotnetapp.AbstractArchitecture
{
    public class Helper
    {
        public static void FnOutSeparator72(TextWriter textWriter, char character = '_')
        {
            textWriter.WriteLine(new string(character, 72));
        }
    }
}