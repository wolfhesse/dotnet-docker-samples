// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AseXunitTestBase.cs" company="">
//   
// </copyright>
// <summary>
//   The xuit test base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetAppDev.Tests
{
    #region using directives

    using System;

    using DotnetApp;
    using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;

    using Newtonsoft.Json;

    using Xunit;
    using Xunit.Abstractions;

    #endregion

    /// <summary>The xuit test base.</summary>
    public class AseXunitTestBase
    {
        /// <summary>
        ///     The _serialized environment.
        /// </summary>
        private string serializedEnvironment;

        /// <summary>Initializes a new instance of the <see cref="AseXunitTestBase"/> class.</summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        public AseXunitTestBase(ITestOutputHelper testOutputHelper)
        {
            EnvManager.TestOutputHelper = testOutputHelper;
        }

        /// <summary>
        ///     The test 1.
        /// </summary>
        [Fact]
        public void Test1()
        {
            EnvManager.WriteLine(DateTimeOffset.Now.ToString());
            Assert.Equal(1, 1);
        }

        /// <summary>
        ///     The test 2.
        /// </summary>
        [Fact]
        public void Test2()
        {
            EnvManager.WriteLine(DateTimeOffset.Now.ToString());
            Assert.False(bool.TrueString == "1");
        }

        /// <summary>
        ///     The test program feature environment.
        /// </summary>
        [Fact]
        public void TestProgramFeatureEnvironment()
        {
            Program.Main(new[] { "eins", "zwo", "drei" });

            this.serializedEnvironment = JsonConvert.SerializeObject(Program.EnvironmentDict(), Formatting.Indented);
            EnvManager.WriteLine(this.serializedEnvironment);

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