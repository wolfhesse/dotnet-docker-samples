// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestDefinitionZulu.cs" company="">
//   
// </copyright>
// <summary>
//   The test definition zulu.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DnsLib.SysRes;
using NUnit.Framework;

namespace DotnetApp.Tests
{
    #region using directives

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