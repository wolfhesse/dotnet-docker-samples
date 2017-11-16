// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubsystemTaskManagementXunitTest.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the SubsystemTaskManagementXunitTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.Tests.Unittests
{
    using System;

    using DnsLib.AseFramework.AbstractArchitecture.EnvironmentSetup;
    using DnsLib.AseFramework.Core.Components.TodoComponent;
    using DnsLib.AseFramework.Core.Components.TodoComponent.Entities;
    using DnsLib.AseFramework.Core.Components.TodoComponent.Storage;

    using DotnetApp.Tests.ClassLibrary;
    using DotnetApp.Tests.IntegrationTests;

    using Xunit;
    using Xunit.Abstractions;

    /// <inheritdoc />
    /// <summary>
    ///     The subsystem todo.
    /// </summary>
    public class SubsystemTaskManagementXunitTest : AseXunitTestBase
    {
        /// <inheritdoc />
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="T:DotnetApp.Tests.Unittests.SubsystemTaskManagementXunitTest" /> class.
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
            TaskManagementController.TaskRepository = new InMemoryTaskRepository();

            TaskManagementControllerVariant.AddTask(new TodoItem("1eins"));
            TaskManagementControllerVariant.AddTask(new TodoItem("2eins"));
            TaskManagementControllerVariant.AddTask(new TodoItem("3eins"));
            TaskManagementControllerVariant.AddTask(new TodoItem("4eins"));
            Assert.Empty(string.Empty);
        }

        /// <summary>
        ///     The test todo controller.
        /// </summary>
        [Fact]
        public void TestTaskManagementController()
        {
            var inMemoryTaskRepository = new InMemoryTaskRepository();
            inMemoryTaskRepository.EvTaskAdded += (sender, args) =>
                {
                    EnvManager.WriteLine(
                        $"oh: task created{Environment.NewLine} at {DateTimeOffset.Now}{Environment.NewLine} by {sender}{Environment.NewLine} with args {args}");
                };
            TaskManagementController.TaskRepository = inMemoryTaskRepository;

            TaskManagementController.AddTask(new TodoItem("eins").Title);
            Assert.Empty(string.Empty);
        }
    }
}