// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubsystemTodo.cs" company="">
//   
// </copyright>
// <summary>
//   The subsystem todo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetAppDev.Tests.Unittests
{
    #region

    using System;
    using System.Diagnostics;

    using DotnetApp;
    using DotnetApp.TodoComponent;
    using DotnetApp.TodoComponent.Entities;
    using DotnetApp.TodoComponent.Storage;

    using Newtonsoft.Json;

    using Xunit;
    using Xunit.Abstractions;

    #endregion

    /// <summary>
    /// The subsystem todo.
    /// </summary>
    public class SubsystemTodo
    {
        /// <summary>
        /// The _oh.
        /// </summary>
        private readonly ITestOutputHelper _oh;

        /// <summary>
        /// The _serialized environment.
        /// </summary>
        private string _serializedEnvironment;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubsystemTodo"/> class.
        /// </summary>
        /// <param name="oh">
        /// The oh.
        /// </param>
        public SubsystemTodo(ITestOutputHelper oh)
        {
            this._oh = oh;
        }

        /// <summary>
        /// The test 1.
        /// </summary>
        [Fact]
        public void Test1()
        {
            this._oh.WriteLine(1.ToString());
            this._oh.WriteLine(DateTimeOffset.Now.ToString());
            Assert.Equal(1, 1);

            // Assert.Equal(1,2);
        }

        /// <summary>
        /// The test 2.
        /// </summary>
        [Fact]
        public void Test2()
        {
            this._oh.WriteLine(DateTimeOffset.Now.ToString());
            Assert.False(bool.TrueString == "1");
        }

        /// <summary>
        ///     The test program feature environment.
        /// </summary>
        [Fact]
        public void TestProgramFeatureEnvironment()
        {
            Program.Main(new[] { "eins", "zwo", "drei" });

            this._serializedEnvironment = JsonConvert.SerializeObject(Program.EnvironmentDict(), Formatting.Indented);
            this._oh.WriteLine(this._serializedEnvironment);

            this._oh.WriteLine("x-ase-debug-line");
            this._oh.WriteLine("x-ase-trace-line", "test");
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

        /// <summary>
        /// The test todo controller.
        /// </summary>
        [Fact]
        public void TestTodoController()
        {
            var inMemoryTaskRepository = TodoController.TaskRepository;
            inMemoryTaskRepository.EvTaskAdded += (sender, args) =>
                {
                    this._oh.WriteLine(
                        $"oh: task created" + Environment.NewLine + $" at {DateTimeOffset.Now}" + Environment.NewLine
                        + $" by {sender}" + Environment.NewLine + $" with args {args}");
                    Console.Out.WriteLine("con: task created");
                    Debug.WriteLine("dbg: task created");
                };

            TodoController.AddTask(new TodoTask("eins").Title);
            Assert.Empty(string.Empty);
        }

        /// <summary>
        /// The test todo engine and component.
        /// </summary>
        [Fact]
        public void TestTodoEngineAndComponent()
        {
            var testTodoEngine = new TodoEngine();
            var inMemoryTaskRepository = new InMemoryTaskRepository();
            inMemoryTaskRepository.EvTaskAdded += (sender, args) =>
                {
                    this._oh.WriteLine(
                        $"oh: task created" + Environment.NewLine + $" at {DateTimeOffset.Now}" + Environment.NewLine
                        + $" by {sender}" + Environment.NewLine + $" with args {args}");
                    Console.Out.WriteLine("con: task created");
                    Debug.WriteLine("dbg: task created");
                };

            testTodoEngine.AddTask(inMemoryTaskRepository, new TodoTask("eins"));
            Assert.Empty(string.Empty);
        }
    }
}