namespace DotnetAppDev.Tests.ClassLibrary.AseFramework
{
    #region using directives

    using DnsLib.AseFramework.AbstractArchitecture.Definitions;

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
            Assert.AreEqual($@"c:\data.d", DefinitionZulu.DataD);
        }
    }
}