// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCodersResourceCollection.cs" company="">
//   
// </copyright>
// <summary>
//   The test coders resource collection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DnsLib.FactoryFloor.Lab.Components;
using NUnit.Framework;

namespace DotnetApp.Tests
{
    #region using directives

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
            Assert.AreEqual(6, CodersResourceCollection.GetProgrammerResourcesList().Count);
        }
    }
}