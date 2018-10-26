using DnsLib.ComponentLibrary.Lab.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DotnetApp.Tests.Instrumentation
{
    #region using directives

    #endregion

    /// <summary>
    ///     The test coders resource collection.
    /// </summary>
    [TestClass]
    public class TestCodersResourceCollection
    {
        /// <summary>
        ///     The test length.
        /// </summary>
        [TestMethod]
        public void TestLength()
        {
            Assert.AreEqual(6, CodersResourceCollection.GetProgrammerResourcesList().Count);
        }
    }
}