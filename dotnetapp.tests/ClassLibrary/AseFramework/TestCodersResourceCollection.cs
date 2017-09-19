namespace DotnetAppDev.Tests.ClassLibrary.AseFramework
{
    #region using directives

    using NUnit.Framework;

    #endregion

    /// <summary>
    ///     The test coders resource collection.
    /// </summary>
    public class TestCodersResourceCollection
    {
        /// <summary>
        ///     The test length.
        /// </summary>
        [Test]
        public void TestLength()
        {
            Assert.AreEqual(1, new CodersResourceCollection().ResourceList.Count);
        }
    }
}