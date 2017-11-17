// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgramTest.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ProgramTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.Tests.Unittests
{
    #region using directives

    using System;

    using DnsLib.AseFramework.AbstractArchitecture.EnvironmentSetup;

    using DotnetApp.Tests.ClassLibrary;
    using DotnetApp.Tests.IntegrationTests;

    using Newtonsoft.Json;

    using Xunit;
    using Xunit.Abstractions;

    #endregion

    /// <inheritdoc />
    /// <summary>The program xunit test.</summary>
    public class ProgramTest : AseXunitTestBase
    {
        /// <summary>Initializes a new instance of the <see cref="ProgramTest"/> class.</summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        public ProgramTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        /// <summary>
        ///     The test program feature environment.
        /// </summary>
        [Fact]
        public void TestProgramFeatureEnvironment()
        {
            this.SerializedEnvironmentString = JsonConvert.SerializeObject(
                ProgramSample.EnvironmentDict(),
                Formatting.Indented);
            Console.Out.WriteLine("SerializedEnvironmentString = {0}", this.SerializedEnvironmentString);
            EnvManager.WriteLine(this.SerializedEnvironmentString);

            EnvManager_Future_WriteAseDebugMarker();
            EnvManager_Future_WriteTrraceMarker();
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

        /// <summary>The test program sample entrypoint.</summary>
        [Fact]
        public void TestProgramSampleEntrypoint()
        {
            ProgramSample.Entrypoint(null);
        }

        /// <summary>The env manager_ future_ write ase debug marker.</summary>
        private static void EnvManager_Future_WriteAseDebugMarker()
        {
            EnvManager.WriteLine("x-ase-debug-line");
        }

        /// <summary>The env manager_ future_ write trrace marker.</summary>
        private static void EnvManager_Future_WriteTrraceMarker()
        {
            EnvManager.WriteLine("x-ase-trace-line", "test");
        }
    }
}