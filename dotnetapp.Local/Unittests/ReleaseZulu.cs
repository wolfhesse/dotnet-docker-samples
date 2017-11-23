// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReleaseZulu.cs" company="">
//   
// </copyright>
// <summary>
//   The release zulu.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.Local.Unittests
{
    using DnsLib;

    using NUnit.Framework;

    /// <summary>The release zulu.</summary>
    [TestFixture]
    public class ReleaseZulu
    {
        /// <summary>The t c 1.</summary>
        [Test]
        public void Tc1()
        {
            var version = VersionInfo.Version;
            Assert.IsNotNull(version);
        }

        /// <summary>The test program.</summary>
        [Test]
        public void TestProgram()
        {
            Program.Main(null);
            Assert.IsTrue(true);
        }
    }
}