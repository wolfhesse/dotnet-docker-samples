﻿using System;
using DnsLib.FactoryFloor.ShopComponent;
using NUnit.Framework;

namespace DotnetApp.Tests.Instrumentation
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