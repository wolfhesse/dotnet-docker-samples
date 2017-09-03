namespace DotnetAppDev.Tests.Unittests
{
    #region using directives

    using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;
    using DotnetApp.AseFramework.Adapters.ElasticSearchAdapter;
    using DotnetApp.AseFramework.Controllers;
    using DotnetApp.AseFramework.Models;

    using Xunit;
    using Xunit.Abstractions;

    #endregion

    /// <summary>
    ///     The operation xunit tests.
    /// </summary>
    public class OperationXunitTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OperationXunitTests" /> class.
        /// </summary>
        /// <param name="outputHelper">
        ///     The outputHelper.
        /// </param>
        public OperationXunitTests(ITestOutputHelper outputHelper)
        {
            EnvManager.TestOutputHelper = outputHelper;
        }

        /// <summary>
        ///     The data d result txt f.
        /// </summary>
        public static string DataDResultTxtF { get; } = EnvManager.AseDataDWin + "/OperationXunitTests.res.txt";

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
            var sampleTweet = SampleDataProvider.GetSampleTweet();
            var tweets = EsOperationsEngine.EsWriteAndReadbackTweet(sampleTweet);
            Assert.Equal(tweets[0].User, tweets[1].User);
        }
    }
}