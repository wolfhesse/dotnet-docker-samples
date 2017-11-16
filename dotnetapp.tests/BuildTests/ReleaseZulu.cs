// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReleaseZulu.cs" company="">
//   
// </copyright>
// <summary>
//   The release zulu.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.Tests.BuildTests
{
    using DnsLib;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>The release zulu.</summary>
    [TestClass]
    public class ReleaseZulu
    {
        /// <summary>The t c 1.</summary>
        [TestMethod]
        public void Tc1()
        {
            var version = VersionInfo.Version;
            Assert.IsNotNull(version);
        }
    }
}