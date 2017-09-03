#region

using dotnetapp.AseFramework.Controllers;
using dotnetapp.AseFramework.Models;
using dotnetapp.ElasticSearchAdapter;
using dotnetapp.EnvironmentSetup;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace dotnetapp.ClassLibrary
{
    public class OperationXunitTests

    {
        public OperationXunitTests(ITestOutputHelper oh)
        {
            _oh = oh;
            EnvManager.TestOutputHelper = _oh;
        }

        private static readonly string DataDResultTxtF = EnvManager.AseDataDWin + "/OperationXunitTests.res.txt";
        private readonly ITestOutputHelper _oh;
        private const string RequestUriString = "http://10.0.0.21:13000/";

//        [Fact]
//        public void ApiTestS13K()
//        {
//            var options = new Dictionary<string, string>
//            {
//                {S13000Operation.Api.ResultFilePathKey, DataDResultTxtF},
//                {S13000Operation.Api.UriKey, RequestUriString},
//                {S13000Operation.Api.CallParamsKey, "?apitest"}
//            };
//            S13000Operation.Api.Fetch(options);
//        }

//        [Fact]
//        public void fetch_s13000_test()
//        {
//            S13000Operation.fetch_s13000(RequestUriString, DataDResultTxtF);
//        }

        [Fact]
        public void get_stmt_test()
        {
            Assert.NotEmpty(S13000Operation.get_statement_1());
        }

        [Fact]
        public void mkidx_test()
        {
            EnvManager.DefaultOut = new IWriteLineAdapter(_oh);
            var pTweet = SampleDataProvider.GetSampleTweet();
            var tweets = EsOperationsEngine.EsWriteAndReadbackTweet(pTweet);
            Assert.Equal(tweets[0].User, tweets[1].User);
        }
    }
}