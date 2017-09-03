#region

using System.Diagnostics;
using System.IO;
using Xunit.Abstractions;

#endregion

namespace dotnetapp.EnvironmentSetup
{
    public class IWriteLineAdapter : IWriteLineSupport
    {
        private readonly TextWriter _textWriter;
        private readonly IWriteLineSupport _writeLineSupportImplementation;

        public IWriteLineAdapter(IWriteLineSupport writeLineSupportImplementation)
        {
            _writeLineSupportImplementation = writeLineSupportImplementation;
        }

        public IWriteLineAdapter(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public IWriteLineAdapter(ITestOutputHelper testOutputHelper)
        {
            EnvManager.TestOutputHelper = testOutputHelper;
        }

        public void WriteLine(object message)
        {
            if (EnvManager.TestOutputHelper != null)
                EnvManager.TestOutputHelper.WriteLine(message.ToString());
            else if (null != _textWriter)
                _textWriter.WriteLine(message);
            else
            {
                _writeLineSupportImplementation?.WriteLine(message);
            }

            Debug.WriteLine(message);
        }
    }
}