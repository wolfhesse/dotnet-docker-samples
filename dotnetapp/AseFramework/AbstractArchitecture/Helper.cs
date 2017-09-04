namespace DotnetApp.AseFramework.AbstractArchitecture
{
    #region using directives

    using System.IO;

    #endregion

    /// <summary>
    ///     The helper.
    /// </summary>
    public class Helper
    {
        /// <summary>
        ///     The fn out separator 72.
        /// </summary>
        /// <param name="textWriter">
        ///     The text writer.
        /// </param>
        /// <param name="character">
        ///     The character.
        /// </param>
        public static void FnOutSeparator72(TextWriter textWriter, char character = '_')
        {
            textWriter.WriteLine(new string(character, 72));
        }
    }
}