// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgramTest.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ProgramTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.Tests
{
    #region using directives

    using System;

    using DnsLib.AbstractArchitecture.EnvironmentSetup;

    using DotnetApp.Tests.ClassLibrary;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Newtonsoft.Json;

    using Xunit.Abstractions;

    #endregion

    /// <inheritdoc />
    /// <summary>The program xunit test.</summary>
    [TestClass]
    public class ProgramTest : AseXunitTestBase
    {
        /// <summary>Initializes a new instance of the <see cref="ProgramTest"/> class.</summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        public ProgramTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ProgramTest"/> class.</summary>
        public ProgramTest()
        {
        }

        /// <summary>
        ///     The test program feature environment.
        /// </summary>
        [TestMethod]
        public void TestProgramFeatureEnvironment()
        {
            this.SerializedEnvironmentString = JsonConvert.SerializeObject(
                ProgramSample.EnvironmentDict(),
                Formatting.Indented);
            Console.Out.WriteLine("SerializedEnvironmentString = {0}", this.SerializedEnvironmentString);
            EnvManager.WriteLine(this.SerializedEnvironmentString);

            EnvManagerFutureWriteAseDebugMarker();
            EnvManagerFutureWriteTrraceMarker();
        }

        /// <summary>
        ///     The test program feature write serialized environment.
        /// </summary>
        [TestMethod]
        public void TestProgramFeatureWriteSerializedEnvironment()
        {
            // it does it and it returns the result
            var actual = ProgramSample.PreparedSerializedEnvironmentSingleLine();
            Assert.IsNotNull(actual);

            // Assert.False(true);
        }

        /// <summary>The test program sample entrypoint.</summary>
        [TestMethod]
        public void TestProgramSampleEntrypoint()
        {
            ProgramSample.Entrypoint(null);
        }

        /// <summary>The env manager_ future_ write ase debug marker.</summary>
        private static void EnvManagerFutureWriteAseDebugMarker()
        {
            EnvManager.WriteLine("x-ase-debug-line");
        }

        /// <summary>The env manager_ future_ write trrace marker.</summary>
        private static void EnvManagerFutureWriteTrraceMarker()
        {
            EnvManager.WriteLine("x-ase-trace-line", "test");
        }
    }
}