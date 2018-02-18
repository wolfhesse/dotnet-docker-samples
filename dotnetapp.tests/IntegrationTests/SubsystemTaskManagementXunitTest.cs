using System;
using DnsLib.EnvironmentSetup;
using DnsLib.FactoryFloor.Lab;
using DnsLib.TodoComponent;
using DotnetApp.Tests.ClassLibrary;
using Xunit;
using Xunit.Abstractions;

namespace DotnetApp.Tests.IntegrationTests
{
    /// <inheritdoc />
    /// <summary>
    ///     The subsystem todo.
    /// </summary>
    public class SubsystemTaskManagementXunitTest : AseXunitTestBase
    {
        /// <inheritdoc />
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="T:DotnetApp.Tests.IntegrationTests.SubsystemTaskManagementXunitTest" /> class.
        /// </summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        public SubsystemTaskManagementXunitTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        /// <summary>
        ///     The test todo engine and component.
        /// </summary>
        [Fact]
        public void TestModifiedTaskManagementController()
        {
            ProgramSample.ConfigureTaskRepositoryEventHandler(
                (sender, args) =>
                {
                    EnvManager.WriteLine(
                        $"oh: task created{Environment.NewLine} at {DateTimeOffset.Now}{Environment.NewLine} by {sender}{Environment.NewLine} with args {args}");
                    Console.Out.WriteLine("con: task created");
                });

            // todo wechsel gegen EfPlugin
            InMemoryTodoEngine.Init();

            TodoManagementControllerVariant.AddTodo(new TodoItem("1eins"));
            TodoManagementControllerVariant.AddTodo(new TodoItem("2eins"));
            TodoManagementControllerVariant.AddTodo(new TodoItem("3eins"));
            TodoManagementControllerVariant.AddTodo(new TodoItem("4eins"));
            Assert.Empty(string.Empty);
        }

        /// <summary>
        ///     The test todo controller.
        /// </summary>
        [Fact]
        public void TestTaskManagementController()
        {
            InMemoryTodoEngine.Init();
            TodoController.TodoRepository.EvTodoAdded += (sender, args) =>
            {
                EnvManager.WriteLine(
                    $"oh: task created{Environment.NewLine} at {DateTimeOffset.Now}{Environment.NewLine} by {sender}{Environment.NewLine} with args {args}");
            };

            TodoController.AddTodo(new TodoItem("eins").Title);
            Assert.Empty(string.Empty);
        }
    }
}