// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AseXunitTestBase.cs" company="">
//   
// </copyright>
// <summary>
//   The xuit test base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.Tests.ClassLibrary
{
    #region using directives

    using Xunit.Abstractions;

    #endregion

    /// <summary>The xuit test base.</summary>
    public class AseXunitTestBase
    {
        /// <summary>
        ///     The _serialized environment.
        /// </summary>
        protected string SerializedEnvironmentString;

        /// <summary>Initializes a new instance of the <see cref="AseXunitTestBase"/> class.</summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        protected AseXunitTestBase(ITestOutputHelper testOutputHelper)
        {
            // EnvManager.TestOutputHelper = testOutputHelper;
        }

        /// <summary>Initializes a new instance of the <see cref="AseXunitTestBase"/> class.</summary>
        protected AseXunitTestBase()
        {
        }
    }
}