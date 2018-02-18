// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WooStuffAuthAdapterTests.cs" company="">
//   
// </copyright>
// <summary>
//   The woo stuff auth adapter tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DnsLib.FactoryFloor.TestDriving.Trainer;

namespace DotnetApp.Tests
{
    using System;



    using NUnit.Framework;

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
        }
    }
}