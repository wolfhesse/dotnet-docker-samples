using System.IO;

namespace ClassLibrary.AbstractArchitecture
{
    public class Helper
    {
        public static void FnOutSeparator72(TextWriter textWriter, char character = '_')
        {
            textWriter.WriteLine(new string(character, 72));
        }
    }
}