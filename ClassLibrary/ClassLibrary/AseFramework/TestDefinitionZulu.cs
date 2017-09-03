using NUnit.Framework;

namespace ClassLibrary.AseFramework
{
    public class TestDefinitionZulu
    {
        [Test]
        public void TheodorDataDTest()
        {
            Assert.AreEqual($@"c:\data.d", DefinitionZulu.DataD);
        }
    }
}