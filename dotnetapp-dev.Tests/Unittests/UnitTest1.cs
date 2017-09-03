#region

using System;
using System.Diagnostics;
using dotnetapp;
using dotnetapp.TodoComponent;
using dotnetapp.TodoComponent.Entities;
using dotnetapp.TodoComponent.Storage;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace DotnetappDev.Tests
{
    public class SubsystemTodo
    {
        public SubsystemTodo(ITestOutputHelper oh)
        {
            this._oh = oh;
        }

        private string _serializedEnvironment;
        private readonly ITestOutputHelper _oh;

        [Fact]
        public void Test1()
        {
            _oh.WriteLine(1.ToString());
            _oh.WriteLine(DateTimeOffset.Now.ToString());
            Assert.Equal(1, 1);

            // Assert.Equal(1,2);
        }

        [Fact]
        public void Test2()
        {
            _oh.WriteLine(DateTimeOffset.Now.ToString());
            Assert.False(bool.TrueString == "1");
        }



        /// <summary>
        ///     The test program feature environment.
        /// </summary>
        [Fact]
        public void TestProgramFeatureEnvironment()
        {
        
            Program.Main(new[] {"eins", "zwo", "drei"});

            _serializedEnvironment = JsonConvert.SerializeObject(Program.EnvironmentDict(), Formatting.Indented);
            _oh.WriteLine(_serializedEnvironment);

            _oh.WriteLine("x-ase-debug-line");
            _oh.WriteLine("x-ase-trace-line", "test");
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
                _oh.WriteLine($"oh: task created" +
                             Environment.NewLine +
                             $" at {DateTimeOffset.Now}" +
                             Environment.NewLine +
                             $" by {sender}" +
                             Environment.NewLine +
                             $" with args {args}");
                Console.Out.WriteLine("con: task created");
                Debug.WriteLine("dbg: task created");
            };

            testTodoEngine.AddTask(inMemoryTaskRepository, new TodoTask("eins"));
            Assert.Empty(string.Empty);
        }

        [Fact]
        public void TestTodoController()
        {
            
            var inMemoryTaskRepository = TodoController.TaskRepository;
            inMemoryTaskRepository.EvTaskAdded += (sender, args) =>
            {
                _oh.WriteLine($"oh: task created" +
                             Environment.NewLine +
                             $" at {DateTimeOffset.Now}" +
                             Environment.NewLine +
                             $" by {sender}" +
                             Environment.NewLine +
                             $" with args {args}");
                Console.Out.WriteLine("con: task created");
                Debug.WriteLine("dbg: task created");
            };

            TodoController.AddTask( new TodoTask("eins").Title);
            Assert.Empty(string.Empty);
        }
    }
}