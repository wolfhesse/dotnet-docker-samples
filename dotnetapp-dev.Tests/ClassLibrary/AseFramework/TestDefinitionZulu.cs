#region

using dotnetapp.AseFramework.Definitions;
using NUnit.Framework;

#endregion

namespace dotnetapp.ClassLibrary.AseFramework
{
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