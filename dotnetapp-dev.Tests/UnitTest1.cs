using System;
using Xunit;

namespace DotnetappDev.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
           Console.WriteLine(1);
            Assert.Equal(1,1);
//            Assert.Equal(1,2);
        }
        [Fact]
        public void TestMethod1()
        {
            Assert.False(bool.TrueString == "1");
//            Assert.False(1 == 1);
            Assert.False(1 == 2);
        }
    }
}
