using DotnetApp;
using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace DotnetAppDev.Tests.Unittests
{
    #region using directives

    #endregion

    /// <summary>The program xunit test.</summary>
    public class ProgramXunitTest : AseXunitTestBase
    {
        public ProgramXunitTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public void TestMethod1()
        {
        }

        /// <summary>
        ///     The test program feature environment.
        /// </summary>
        [Fact]
        public void TestProgramFeatureEnvironment()
        {
            ProgramSample.Main(new[] { "eins", "zwo", "drei" });

            SerializedEnvironment = JsonConvert.SerializeObject(ProgramSample.EnvironmentDict(), Formatting.Indented);
            EnvManager.WriteLine(SerializedEnvironment);

            EnvManager.WriteLine("x-ase-debug-line");
            EnvManager.WriteLine("x-ase-trace-line", "test");
        }

        /// <summary>
        ///     The test program feature write serialized environment.
        /// </summary>
        [Fact]
        public void TestProgramFeatureWriteSerializedEnvironment()
        {
            // it does it and it returns the result
            var actual = ProgramSample.PreparedSerializedEnvironmentSingleLine();
            Assert.NotEmpty(actual);

            // Assert.False(true);
        }
    }
}