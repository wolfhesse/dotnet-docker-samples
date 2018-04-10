using DnsLib.SysRes;
using Xunit.Abstractions;

namespace DotnetApp.Tests.ClassLibrary
{
    #region using directives

    #endregion

    /// <summary>The xuit test base.</summary>
    public class AseXunitTestBase
    {
        /// <summary>
        ///     The _serialized environment.
        /// </summary>
        protected string SerializedEnvironmentString;

        /// <summary>Initializes a new instance of the <see cref="AseXunitTestBase" /> class.</summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        protected AseXunitTestBase(ITestOutputHelper testOutputHelper)
        {
            var envManagerTestOutputHelper = PlatformSysGen.EnvironmentManager.TestOutputHelper;
            OutputHelperComparison = testOutputHelper == envManagerTestOutputHelper;
        }

        /// <summary>Initializes a new instance of the <see cref="AseXunitTestBase" /> class.</summary>
        protected AseXunitTestBase()
        {
        }

        public bool OutputHelperComparison { get; }
    }
}