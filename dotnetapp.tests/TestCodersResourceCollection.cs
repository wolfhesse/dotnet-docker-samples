// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCodersResourceCollection.cs" company="">
//   
// </copyright>
// <summary>
//   The test coders resource collection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.Tests
{
    #region using directives

    using DnsLib.Lab.Components;

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