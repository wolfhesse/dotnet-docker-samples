using NUnit.Framework;

namespace ClassLibrary.AseFramework
{
    public class TestCodersResourceCollection
    {
        [Test]
        public void TestLength()
        {
            Assert.AreEqual(1,new CodersResourceCollection().ResourceList.Count);
        }
    }
}