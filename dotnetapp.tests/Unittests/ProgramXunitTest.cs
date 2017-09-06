using System;
using DotnetApp;
using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace DotnetAppDev.Tests.Unittests
{
    #region using directives

    #endregion

    /// <inheritdoc />
    /// <summary>The program xunit test.</summary>
    public class ProgramXunitTest : AseXunitTestBase
    {
        public ProgramXunitTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public void TestProgramSampleEntrypoint() => ProgramSample.Entrypoint(null);

        /// <summary>
        ///     The test program feature environment.
        /// </summary>
        [Fact]
        public void TestProgramFeatureEnvironment()
        {
        
            SerializedEnvironmentString = JsonConvert.SerializeObject(ProgramSample.EnvironmentDict(), Formatting.Indented);
            Console.Out.WriteLine("SerializedEnvironmentString = {0}", SerializedEnvironmentString);
            EnvManager.WriteLine(SerializedEnvironmentString);

            EnvManager_Future_WriteAseDebugMarker();
            EnvManager_Future_WriteTrraceMarker();
        }

        private static void EnvManager_Future_WriteTrraceMarker()
        {
            EnvManager.WriteLine("x-ase-trace-line", "test");
        }

        private static void EnvManager_Future_WriteAseDebugMarker()
        {
            EnvManager.WriteLine("x-ase-debug-line");
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