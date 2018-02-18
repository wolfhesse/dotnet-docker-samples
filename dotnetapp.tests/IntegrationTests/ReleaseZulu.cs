// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReleaseZulu.cs" company="">
//   
// </copyright>
// <summary>
//   The release zulu.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DnsLib;
using Xunit;

namespace DotnetApp.Tests.IntegrationTests
{
    /// <summary>The release zulu.</summary>
    
    public class ReleaseZulu
    {
        /// <summary>The t c 1.</summary>
        [Fact]
        public void Tc1()
        {
            var version = VersionInfo.Version;
            Assert.NotNull(version);
        }

        /// <summary>The test program.</summary>
        [Fact]
        public void TestProgram()
        {
            Program.Main(null);
        }
    }
}