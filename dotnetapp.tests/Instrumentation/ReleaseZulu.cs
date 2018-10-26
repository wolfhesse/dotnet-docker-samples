using DnsLib;
using Xunit;

namespace DotnetApp.Tests.Instrumentation
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
        [Fact(Timeout = 3500,Skip = "interactive only")]
        public void TestProgram()
        {
                        Program.Main(null);
        }
    }
}