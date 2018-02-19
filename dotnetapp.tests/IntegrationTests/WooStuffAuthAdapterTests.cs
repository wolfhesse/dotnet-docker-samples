using System;
using DnsLib.ShopComponent;
using NUnit.Framework;

namespace DotnetApp.Tests.IntegrationTests
{
    /// <summary>The woo stuff auth adapter tests.</summary>
    [TestFixture]
    public class WooStuffAuthAdapterTests
    {
        /// <summary>The sample application.</summary>
        [Test]
        public void SampleApplication()
        {
            var dumpString = WooStuffAuthAdapter.FnAuthForRcs2().ToDumpString();
            Console.Out.WriteLine("dumpString = {0}", dumpString);

            Assert.True(true);
        }
    }
}