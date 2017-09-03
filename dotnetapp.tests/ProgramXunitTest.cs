namespace DotnetAppDev.Tests
{
    #region using directives

    using DotnetAppDev.Tests.Unittests;

    using Xunit;
    using Xunit.Abstractions;

    #endregion

    /// <summary>The program xunit test.</summary>
    public class ProgramXunitTest : AseXunitTestBase
    {
        public ProgramXunitTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public void TestMethod1()
        {
        }
    }
}