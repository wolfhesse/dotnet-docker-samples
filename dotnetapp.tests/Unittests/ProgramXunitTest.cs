using DotnetApp;
using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;
using Newtonsoft.Json;

namespace DotnetAppDev.Tests
{
    #region using directives

    using DotnetAppDev.Tests.Unittests;

    using Xunit;
    using Xunit.Abstractions;

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
            Program.Main(new[] { "eins", "zwo", "drei" });

            this.SerializedEnvironment = JsonConvert.SerializeObject(Program.EnvironmentDict(), Formatting.Indented);
            EnvManager.WriteLine(this.SerializedEnvironment);

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
            var actual = Program.PreparedSerializedEnvironmentSingleLine();
            Assert.NotEmpty(actual);

            // Assert.False(true);
        }
    }
}