﻿using System;
using AseFrameworkApp.CustomSetup;
using AseFrameworkApp.Tests.ClassLibrary;
using DnsLib.SysRes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace AseFrameworkApp.Tests.Instrumentation
{
    #region using directives

    #endregion

    /// <inheritdoc />
    /// <summary>The program xunit test.</summary>
    [TestClass]
    public class ProgramTest : AseXunitTestBase
    {
        /// <summary>Initializes a new instance of the <see cref="ProgramTest" /> class.</summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        public ProgramTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ProgramTest" /> class.</summary>
        public ProgramTest()
        {
        }

        /// <summary>
        ///     The test program feature environment.
        /// </summary>
        [TestMethod]
        public void TestProgramFeatureEnvironment()
        {
            SerializedEnvironmentString = JsonConvert.SerializeObject(
                ProgramSample.EnvironmentDict(),
                Formatting.Indented);
            Console.Out.WriteLine("SerializedEnvironmentString = {0}", SerializedEnvironmentString);
            DnsLib.SysRes.EnvironmentManager.WriteLine(SerializedEnvironmentString);

            EnvManagerFutureWriteAseDebugMarker();
            EnvManagerFutureWriteTrraceMarker();

            Assert.IsTrue(true);
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
            Assert.IsTrue(true);
        }

        /// <summary>The env manager_ future_ write ase debug marker.</summary>
        private static void EnvManagerFutureWriteAseDebugMarker()
        {
            EnvironmentManager.WriteLine("x-ase-debug-line");
        }

        /// <summary>The env manager_ future_ write trrace marker.</summary>
        private static void EnvManagerFutureWriteTrraceMarker()
        {
            EnvironmentManager.WriteLine("x-ase-trace-line", "test");
        }
    }
}