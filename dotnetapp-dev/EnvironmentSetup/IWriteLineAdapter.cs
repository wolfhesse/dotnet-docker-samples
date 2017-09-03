#region

#endregion

namespace DotnetApp.EnvironmentSetup
{
    using System.Diagnostics;
    using System.IO;

    using Xunit.Abstractions;

    public class EnvironmentOutputAdapter : IWriteLineSupport
    {
        private readonly TextWriter _textWriter;
        private readonly IWriteLineSupport _writeLineSupportImplementation;

        public EnvironmentOutputAdapter(IWriteLineSupport writeLineSupportImplementation)
        {
            this._writeLineSupportImplementation = writeLineSupportImplementation;
        }

        public EnvironmentOutputAdapter(TextWriter textWriter)
        {
            this._textWriter = textWriter;
        }

        public EnvironmentOutputAdapter(ITestOutputHelper testOutputHelper)
        {
            EnvManager.TestOutputHelper = testOutputHelper;
        }

        public void WriteLine(object message)
        {
            if (EnvManager.TestOutputHelper != null)
                EnvManager.TestOutputHelper.WriteLine(message.ToString());
            else if (null != this._textWriter)
                this._textWriter.WriteLine(message);
            else
            {
                this._writeLineSupportImplementation?.WriteLine(message);
            }

            Debug.WriteLine(message);
        }
    }
}