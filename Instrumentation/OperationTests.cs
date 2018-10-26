using System;
using System.Collections.Generic;
using DnsLib.FactoryFloor.MqComponent;
using DnsLib.OperatorApps.SysRes;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DotnetApp.Tests.Instrumentation
{
    #region using directives

    #endregion

    /// <summary>The operation tests.</summary>
    [TestClass]
    public class OperationTests
    {
        /// <summary>Gets the data d result txt f.</summary>
        public static string DataDResultTxtF { get; } = EnvironmentManager.AseDataDWin + "/OperationTests.res.txt";

        [TestMethod]
//        [Ignore]
        [Timeout(30000)]
        public void ExecuteMainLoopTest()
        {
            var mqOperationsEngine = new MqOperationsEngine();
            mqOperationsEngine.Configure(new List<string> {"s0.wolfslab.wolfspool.at", "30", "10", "hello"});
            mqOperationsEngine.ConfigureMqMessagesLoopMessageHandlers
            (
                Program.HandleProductCreationRequest,
                Program.HandleTweetCreationRequest
            ).Execute(mqOperationsEngine);
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
        ///     The mkidx_test.
        /// </summary>
        [TestMethod]
        public void MkidxTest()
        {
            // EnvManager.DefaultOut = new EnvironmentOutputAdapter(this.Oh);
            var tweets = EsOperationsEngine.EsWriteAndDupTweet(EnvironmentManager.GetSampleTweet());
            Console.WriteLine(tweets[1]);
            Assert.AreEqual(tweets[0].User, tweets[1].User);
        }

        /// <summary>
        ///     The test 1.
        /// </summary>
        [TestMethod]
        public void Test1()
        {
            Console.WriteLine(1);
            try
            {
                EnvironmentManager.WriteLine(DateTimeOffset.Now.ToString());
            }
            finally
            {
                Assert.AreEqual(11, 11);
            }

            Console.WriteLine(2);
            
        }

        /// <summary>
        ///     The test 2.
        /// </summary>
        [TestMethod]
        public void Test2()
        {
            EnvironmentManager.WriteLine(DateTimeOffset.Now.ToString());
            Assert.AreEqual(bool.TrueString, "True");
        }
    }
}