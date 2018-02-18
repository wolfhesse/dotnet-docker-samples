// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AseXunitTestBase.cs" company="">
//   
// </copyright>
// <summary>
//   The xuit test base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DnsLib.EnvironmentSetup;
using Xunit.Abstractions;

namespace DotnetApp.Tests
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

        public bool OutputHelperComparison { get; }

        /// <summary>Initializes a new instance of the <see cref="AseXunitTestBase"/> class.</summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        protected AseXunitTestBase(ITestOutputHelper testOutputHelper)
        {
            var envManagerTestOutputHelper = EnvManager.TestOutputHelper;
            OutputHelperComparison = testOutputHelper == envManagerTestOutputHelper;
        }

        /// <summary>Initializes a new instance of the <see cref="AseXunitTestBase"/> class.</summary>
        protected AseXunitTestBase()
        {
        }
    }
}