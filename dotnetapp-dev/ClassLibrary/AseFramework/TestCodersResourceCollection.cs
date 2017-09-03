#region

using dotnetapp.AseFramework.Models;
using NUnit.Framework;

#endregion

namespace dotnetapp.ClassLibrary.AseFramework
{
    public class TestCodersResourceCollection
    {
        [Test]
        public void TestLength()
        {
            Assert.AreEqual(1, new CodersResourceCollection().ResourceList.Count);
        }
    }
}