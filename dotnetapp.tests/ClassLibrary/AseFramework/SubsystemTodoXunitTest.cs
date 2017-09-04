#region using directives

using System;
using DotnetApp;
using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;
using DotnetApp.AseFramework.Core;
using DotnetApp.AseFramework.Core.TodoComponent.Entities;
using DotnetApp.AseFramework.Core.TodoComponent.Storage;
using DotnetApp.ProgramSetup;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace DotnetAppDev.Tests.ClassLibrary.AseFramework
{
    #region using directives

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
        /// <summary>Initializes a new instance of the <see cref="T:DotnetAppDev.Tests.ClassLibrary.AseFramework.SubsystemTodoXunitTest" /> class.</summary>
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
            var inMemoryTaskRepository = new InMemoryTaskRepository();
            inMemoryTaskRepository.EvTaskAdded += (sender, args) =>
            {
                EnvManager.WriteLine(
                    $"oh: task created{Environment.NewLine} at {DateTimeOffset.Now}{Environment.NewLine} by {sender}{Environment.NewLine} with args {args}");
                Console.Out.WriteLine("con: task created");
            };
            TodoEngine.TaskRepository = inMemoryTaskRepository;

            TodoController.AddTask(new TodoTask("eins").Title);
            Assert.Empty(string.Empty);
        }

        /// <summary>
        ///     The test todo engine and component.
        /// </summary>
        [Fact]
        public void TestTodoEngineAndComponent()
        {
            Program.ConfgureTodoEngine();

            TodoEngine.AddTask(new TodoTask("1eins"));
            TodoEngine.AddTask(new TodoTask("2eins"));
            TodoEngine.AddTask(new TodoTask("3eins"));
            TodoEngine.AddTask(new TodoTask("4eins"));
            Assert.Empty(string.Empty);
        }
    }
}