// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestDefinitionZulu.cs" company="">
//   
// </copyright>
// <summary>
//   The test definition zulu.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DnsLib.SysRes;

namespace DotnetApp.Tests
{
    #region using directives

  

    using NUnit.Framework;

    #endregion

    /// <summary>
    ///     The test definition zulu.
    /// </summary>
    [TestFixture]
    public class TestDefinitionZulu
    {
        /// <summary>
        ///     The theodor data d test.
        /// </summary>
        [Test]
        public void TheodorDataDTest()
        {
            Assert.AreEqual($@"C:\Users\rogera/data.d", DefinitionZulu.DataD);
        }
    }
}