#region

#endregion

namespace DotnetAppDev.Tests.ClassLibrary.AseFramework
{
    using DotnetApp.AseFramework.Models;

    using NUnit.Framework;

    public class TestCodersResourceCollection
    {
        [Test]
        public void TestLength()
        {
            Assert.AreEqual(1, new CodersResourceCollection().ResourceList.Count);
        }
    }
}