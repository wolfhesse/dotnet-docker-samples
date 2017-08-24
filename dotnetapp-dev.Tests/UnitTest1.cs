namespace DotnetappDev.Tests
{
    using System;
    using System.Diagnostics;

    using DotNetApp;

    using Newtonsoft.Json;

    using Xunit;

    public class UnitTest1
    {
        private string serializedEnvironment;

        [Fact]
        public void Test1()
        {
            Console.WriteLine(1);
            Assert.Equal(1, 1);

            // Assert.Equal(1,2);
        }

        [Fact]
        public void TestMethod1()
        {
            Assert.False(bool.TrueString == "1");

            // Assert.False(1 == 1);
            Assert.False(1 == 2);
        }

        [Fact]
        public void TestProgramFeatureEnvironment()
        {
            var p = new Program();
            Program.Main(new[] { "eins", "zwo", "drei" });

            this.serializedEnvironment = JsonConvert.SerializeObject(Program.EnvironmentDict());
            Debug.WriteLine(this.serializedEnvironment);

            Debug.WriteLine("x-ase-debug-line");
            Trace.WriteLine("x-ase-trace-line", "test");
        }
    }
}