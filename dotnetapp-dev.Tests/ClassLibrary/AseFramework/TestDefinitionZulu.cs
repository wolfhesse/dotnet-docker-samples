#region

#endregion

namespace DotnetAppDev.Tests.ClassLibrary.AseFramework
{
    using DotnetApp.AseFramework.Definitions;

    using NUnit.Framework;

    [TestFixture]
    public class TestDefinitionZulu
    {
        [Test]
        public void TheodorDataDTest()
        {
            Assert.AreEqual($@"c:\data.d", DefinitionZulu.DataD);
        }
    }
}