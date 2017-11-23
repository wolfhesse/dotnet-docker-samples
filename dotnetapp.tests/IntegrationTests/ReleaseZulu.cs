﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReleaseZulu.cs" company="">
//   
// </copyright>
// <summary>
//   The release zulu.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.Tests.IntegrationTests
{
    using DnsLib;

    using Xunit;

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