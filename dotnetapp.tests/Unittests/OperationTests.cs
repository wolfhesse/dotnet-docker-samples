// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationTests.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the OperationTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.Tests.Unittests
{
    #region using directives

    using System;

    using DnsLib.AseFramework.AbstractArchitecture.EnvironmentSetup;
    using DnsLib.AseFramework.Core.Components;
    using DnsLib.AseFramework.Core.Engines;
    using DnsLib.AseFramework.Lib.Controllers;

    using DotnetApp.Tests.ClassLibrary;

    using Xunit;
    using Xunit.Abstractions;

    #endregion

    /// <inheritdoc />
    /// <summary>
    ///     The operation xunit tests.
    /// </summary>
    public class OperationTests : AseXunitTestBase
    {
        /// <summary>Initializes a new instance of the <see cref="OperationTests"/> class.</summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        public OperationTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        /// <summary>
        ///     The data d result txt f.
        /// </summary>
        public static string DataDResultTxtF { get; } = EnvManager.AseDataDWin + "/OperationTests.res.txt";

        // [Fact]
        // public void ApiTestS13K()
        // {
        // var options = new Dictionary<string, string>
        // {
        // {S13000Operation.Api.ResultFilePathKey, DataDResultTxtF},
        // {S13000Operation.Api.UriKey, RequestUriString},
        // {S13000Operation.Api.CallParamsKey, "?apitest"}
        // };
        // S13000Operation.Api.Fetch(options);
        // }

        // [Fact]
        // public void fetch_s13000_test()
        // {
        // S13000Operation.fetch_s13000(RequestUriString, DataDResultTxtF);
        // }

        /// <summary>
        ///     The get_stmt_test.
        /// </summary>
        [Fact]
        public void GetStmtTest()
        {
            Assert.NotEmpty(S13000Operation.GetStatement1());
        }

        /// <summary>
        ///     The mkidx_test.
        /// </summary>
        [Fact]
        public void MkidxTest()
        {
            // EnvManager.DefaultOut = new EnvironmentOutputAdapter(this.Oh);
            var tweets = EsOperationsEngine.EsWriteAndDupTweet(EnvironmentManager.GetSampleTweet());
            Assert.Equal(tweets[0].User, tweets[1].User);
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
    }
}