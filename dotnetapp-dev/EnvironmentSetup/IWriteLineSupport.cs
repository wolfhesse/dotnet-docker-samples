// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWriteLineSupport.cs" company="">
//   
// </copyright>
// <summary>
//   The WriteLineSupport interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.EnvironmentSetup
{
    /// <summary>
    /// The WriteLineSupport interface.
    /// </summary>
    public interface IWriteLineSupport
    {
        /// <summary>
        /// The write line.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void WriteLine(object message);
    }
}