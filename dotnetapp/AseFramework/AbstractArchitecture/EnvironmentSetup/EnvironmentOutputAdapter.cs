#region using directives

using System.IO;

#endregion

namespace DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup
{
    #region using directives

    #endregion

    /// <inheritdoc />
    /// <summary>
    ///     The environment output adapter.
    /// </summary>
    public class EnvironmentOutputAdapter : IWriteLineSupport
    {
        /// <summary>
        ///     The _text writer.
        /// </summary>
        private readonly TextWriter _textWriter;

        /// <summary>
        ///     The _write line support implementation.
        /// </summary>
        private readonly IWriteLineSupport _writeLineSupportImplementation;


        /// <summary>
        ///     Initializes a new instance of the <see cref="EnvironmentOutputAdapter" /> class.
        /// </summary>
        /// <param name="textWriter">
        ///     The text writer.
        /// </param>
        public EnvironmentOutputAdapter(TextWriter textWriter,
            IWriteLineSupport otherWriteLineSupportImplementation = null)
        {
            _textWriter = textWriter;
            _writeLineSupportImplementation = otherWriteLineSupportImplementation;
        }


        /// <inheritdoc />
        /// <summary>
        ///     The write line.
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        public void WriteLine(object message)
        {
            if (EnvManager.TestOutputHelper != null) EnvManager.TestOutputHelper.WriteLine(message.ToString());
            else if (null != _textWriter) _textWriter.WriteLine(message);
            else if (_writeLineSupportImplementation != null) _writeLineSupportImplementation?.WriteLine(message);
            else EnvManager.WriteLine(message.ToString());
        }
    }
}