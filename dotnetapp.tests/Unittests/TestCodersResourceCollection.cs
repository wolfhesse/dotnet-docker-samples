// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCodersResourceCollection.cs" company="">
//   
// </copyright>
// <summary>
//   The test coders resource collection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.Tests.Unittests
{
    #region using directives

    using DnsLib.AseFramework.Lib.Core;

    using NUnit.Framework;

    #endregion

    /// <summary>
    ///     The test coders resource collection.
    /// </summary>
    public class TestCodersResourceCollection
    {
        /// <summary>
        ///     The test length.
        /// </summary>
        [Test]
        public void TestLength()
        {
            Assert.AreEqual(1, CodersResourceCollection.GetProgrammerResourcesList().Count);
        }
    }
}