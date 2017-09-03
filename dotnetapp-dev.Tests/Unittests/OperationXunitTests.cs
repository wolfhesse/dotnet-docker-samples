﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationXunitTests.cs" company="">
//   
// </copyright>
// <summary>
//   The operation xunit tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetAppDev.Tests.Unittests
{
    #region

    using DotnetApp.AseFramework.Models;
    using DotnetApp.Controllers;
    using DotnetApp.ElasticSearchAdapter;
    using DotnetApp.EnvironmentSetup;

    using Xunit;
    using Xunit.Abstractions;

    #endregion

    /// <summary>
    ///     The operation xunit tests.
    /// </summary>
    public class OperationXunitTests
    {
        /// <summary>
        ///     The request uri string.
        /// </summary>
        private const string RequestUriString = "http://10.0.0.21:13000/";

        /// <summary>
        ///     The data d result txt f.
        /// </summary>
        private static readonly string DataDResultTxtF = EnvManager.AseDataDWin + "/OperationXunitTests.res.txt";

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationXunitTests"/> class.
        /// </summary>
        /// <param name="outputHelper">
        /// The outputHelper.
        /// </param>
        public OperationXunitTests(ITestOutputHelper outputHelper)
        {
            EnvManager.TestOutputHelper = outputHelper;
        }

     

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
        public void Get_stmt_test()
        {
            Assert.NotEmpty(S13000Operation.Get_statement_1());
        }

        /// <summary>
        ///     The mkidx_test.
        /// </summary>
        [Fact]
        public void Mkidx_test()
        {
            EnvManager.DefaultOut = new EnvironmentOutputAdapter(this.Oh);
            var pTweet = SampleDataProvider.GetSampleTweet();
            var tweets = EsOperationsEngine.EsWriteAndReadbackTweet(pTweet);
            Assert.Equal(tweets[0].User, tweets[1].User);
        }
    }
}