// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationTests.cs" company="">
//   
// </copyright>
// <summary>
//   The operation tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using DnsLib.EnvironmentSetup;
using DnsLib.SysRes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotnetApp.Tests
{
    #region using directives

    #endregion

  /// <summary>The operation tests.</summary>
  [TestClass]
    public class OperationTests
    {
      /// <summary>Gets the data d result txt f.</summary>
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
            EnvManager.WriteLine(DateTimeOffset.Now.ToString());
            Assert.AreEqual(11, 11);
        }

      /// <summary>
      ///     The test 2.
      /// </summary>
      [TestMethod]
        public void Test2()
        {
            EnvManager.WriteLine(DateTimeOffset.Now.ToString());
            Assert.AreEqual(bool.TrueString, "True");
        }
    }
}