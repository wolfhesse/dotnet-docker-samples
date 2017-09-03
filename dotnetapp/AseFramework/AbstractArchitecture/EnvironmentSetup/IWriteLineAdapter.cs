namespace DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup
{
    #region using directives

    using System.Diagnostics;
    using System.IO;

    using Xunit.Abstractions;

    #endregion

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
        /// <param name="writeLineSupportImplementation">
        ///     The write line support implementation.
        /// </param>
        public EnvironmentOutputAdapter(IWriteLineSupport writeLineSupportImplementation)
        {
            this._writeLineSupportImplementation = writeLineSupportImplementation;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EnvironmentOutputAdapter" /> class.
        /// </summary>
        /// <param name="textWriter">
        ///     The text writer.
        /// </param>
        public EnvironmentOutputAdapter(TextWriter textWriter)
        {
            this._textWriter = textWriter;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EnvironmentOutputAdapter" /> class.
        /// </summary>
        /// <param name="testOutputHelper">
        ///     The test output helper.
        /// </param>
        public EnvironmentOutputAdapter(ITestOutputHelper testOutputHelper)
        {
            EnvManager.TestOutputHelper = testOutputHelper;
        }

        /// <summary>
        ///     The write line.
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        public void WriteLine(object message)
        {
            if (EnvManager.TestOutputHelper != null) EnvManager.TestOutputHelper.WriteLine(message.ToString());
            else if (null != this._textWriter) this._textWriter.WriteLine(message);
            else this._writeLineSupportImplementation?.WriteLine(message);

            Debug.WriteLine(message);
        }
    }
}