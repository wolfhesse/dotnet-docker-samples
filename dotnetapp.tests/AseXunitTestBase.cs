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
        protected string SerializedEnvironment;

        /// <summary>Initializes a new instance of the <see cref="AseXunitTestBase"/> class.</summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        public AseXunitTestBase(ITestOutputHelper testOutputHelper)
        {
            EnvManager.TestOutputHelper = testOutputHelper;
        }
    }
}