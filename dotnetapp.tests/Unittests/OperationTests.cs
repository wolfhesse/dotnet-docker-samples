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
  using DnsLib.AseFramework.Core.Components.Operations;
  using DnsLib.AseFramework.Core.Engines;
  using DnsLib.AseFramework.Lib.Controllers;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  #endregion

  [TestClass]
  public class OperationTests
  {

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
    ///   The get_stmt_test.
    /// </summary>
    [TestMethod]
    public void GetStmtTest()
    {
      Assert.IsNotNull(S13000Operation.GetStatement1());
    }

    /// <summary>
    ///   The mkidx_test.
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
    ///   The test 1.
    /// </summary>
    [TestMethod]
    public void Test1()
    {
      EnvManager.WriteLine(DateTimeOffset.Now.ToString());
      Assert.AreEqual(11, 11);
    }

    /// <summary>
    ///   The test 2.
    /// </summary>
    [TestMethod]
    public void Test2()
    {
      EnvManager.WriteLine(DateTimeOffset.Now.ToString());
      Assert.AreEqual(bool.TrueString, "True");
    }
  }
}