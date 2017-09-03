namespace DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup
{
    /// <summary>
    ///     The WriteLineSupport interface.
    /// </summary>
    public interface IWriteLineSupport
    {
        /// <summary>
        ///     The write line.
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        void WriteLine(object message);
    }
}