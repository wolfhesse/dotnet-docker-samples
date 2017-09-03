namespace DotnetAppDev.Tests
{
    #region using directives

    using System;

    using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;
    using DotnetApp.AseFramework.Core.TodoComponent;
    using DotnetApp.AseFramework.Core.TodoComponent.Entities;
    using DotnetApp.AseFramework.Core.TodoComponent.Storage;

    using Xunit;
    using Xunit.Abstractions;

    #endregion

    #region using directives

    #endregion

    /// <inheritdoc />
    /// <summary>
    ///     The subsystem todo.
    /// </summary>
    public class SubsystemTodoXunitTest : AseXunitTestBase
    {
        /// <inheritdoc />
        /// <summary>Initializes a new instance of the <see cref="T:DotnetAppDev.Tests.SubsystemTodoXunitTest" /> class.</summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        public SubsystemTodoXunitTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        /// <summary>
        ///     The test todo controller.
        /// </summary>
        [Fact]
        public void TestTodoController()
        {
            var inMemoryTaskRepository = TodoController.TaskRepository;
            inMemoryTaskRepository.EvTaskAdded += (sender, args) =>
                {
                    EnvManager.WriteLine(
                        $"oh: task created{Environment.NewLine} at {DateTimeOffset.Now}{Environment.NewLine} by {sender}{Environment.NewLine} with args {args}");
                    Console.Out.WriteLine("con: task created");
                    EnvManager.WriteLine("dbg: task created");
                };

            TodoController.AddTask(new TodoTask("eins").Title);
            Assert.Empty(string.Empty);
        }

        /// <summary>
        ///     The test todo engine and component.
        /// </summary>
        [Fact]
        public void TestTodoEngineAndComponent()
        {
            var testTodoEngine = new TodoEngine();

            // todo move EvTaskAdded to Engine
            var inMemoryTaskRepository = new InMemoryTaskRepository();
            inMemoryTaskRepository.EvTaskAdded += (sender, args) =>
                {
                    EnvManager.WriteLine(
                        $"oh: task created{Environment.NewLine} at {DateTimeOffset.Now}{Environment.NewLine} by {sender}{Environment.NewLine} with args {args}");
                    Console.Out.WriteLine("con: task created");
                    EnvManager.WriteLine("dbg: task created");
                };

            testTodoEngine.AddTask(inMemoryTaskRepository, new TodoTask("eins"));
            Assert.Empty(string.Empty);
        }
    }
}