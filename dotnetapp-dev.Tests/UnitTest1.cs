#region

using System;
using System.Diagnostics;
using ClassLibrary.TodoComponent;
using ClassLibrary.TodoComponent.Entities;
using ClassLibrary.TodoComponent.Storage;
using DotNetApp;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace DotnetappDev.Tests
{
    public class UnitTest1
    {
        public UnitTest1(ITestOutputHelper oh)
        {
            this.oh = oh;
        }

        private string _serializedEnvironment;
        private readonly ITestOutputHelper oh;

        [Fact]
        public void Test1()
        {
            oh.WriteLine(1.ToString());
            oh.WriteLine(DateTimeOffset.Now.ToString());
            Assert.Equal(1, 1);

            // Assert.Equal(1,2);
        }

        [Fact]
        public void Test2()
        {
            oh.WriteLine(DateTimeOffset.Now.ToString());
            Assert.False(bool.TrueString == "1");
        }


        /// <summary>
        ///     The test program feature environment.
        /// </summary>
        [Fact]
        public void TestProgramFeatureEnvironment()
        {
            var p = new Program();
            Program.Main(new[] {"eins", "zwo", "drei"});

            _serializedEnvironment = JsonConvert.SerializeObject(Program.EnvironmentDict(), Formatting.Indented);
            oh.WriteLine(_serializedEnvironment);

            oh.WriteLine("x-ase-debug-line");
            oh.WriteLine("x-ase-trace-line", "test");
        }

        /// <summary>
        ///     The test program feature write serialized environment.
        /// </summary>
        [Fact]
        public void TestProgramFeatureWriteSerializedEnvironment()
        {
            // it does it and it returns the result
            var actual = Program.RWriteSerializedEnv();
            Assert.NotEmpty(actual);

            // Assert.False(true);
        }

        [Fact]
        public void TestTodoEngineAndComponent()
        {
            var testTodoEngine = new TodoEngine();
            var inMemoryTaskRepository = new InMemoryTaskRepository();
            inMemoryTaskRepository.EvTaskAdded += (sender, args) =>
            {
                oh.WriteLine($"oh: task created" +
                             Environment.NewLine +
                             $" at {DateTimeOffset.Now}" +
                             Environment.NewLine +
                             $" by {sender}" +
                             Environment.NewLine +
                             $" with args {args}");
                Console.Out.WriteLine("con: task created");
                Debug.WriteLine("dbg: task created");
            };

            testTodoEngine.AddTask(inMemoryTaskRepository, new Task("eins"));
            Assert.Empty(string.Empty);
        }

        [Fact]
        public void TestTodoController()
        {
            
            var inMemoryTaskRepository = TodoController.TaskRepository;
            inMemoryTaskRepository.EvTaskAdded += (sender, args) =>
            {
                oh.WriteLine($"oh: task created" +
                             Environment.NewLine +
                             $" at {DateTimeOffset.Now}" +
                             Environment.NewLine +
                             $" by {sender}" +
                             Environment.NewLine +
                             $" with args {args}");
                Console.Out.WriteLine("con: task created");
                Debug.WriteLine("dbg: task created");
            };

            TodoController.AddTask( new Task("eins").Title);
            Assert.Empty(string.Empty);
        }
    }
}