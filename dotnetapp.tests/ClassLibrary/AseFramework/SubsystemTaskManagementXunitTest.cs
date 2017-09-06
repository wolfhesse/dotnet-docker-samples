#region using directives

using System;
using DotnetApp;
using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;
using DotnetApp.AseFramework.Core;
using DotnetApp.AseFramework.Core.TodoComponent.Entities;
using DotnetApp.AseFramework.Core.TodoComponent.Storage;
using DotnetApp.ProgramSetup;
using DotnetApp.ProgramSetup.EngineSetups;
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
    public class SubsystemTaskManagementXunitTest : AseXunitTestBase
    {
        /// <inheritdoc />
        /// <summary>Initializes a new instance of the <see cref="T:DotnetAppDev.Tests.ClassLibrary.AseFramework.SubsystemTaskManagementXunitTest" /> class.</summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        public SubsystemTaskManagementXunitTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
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
            TaskManagementEngineSetup.TaskRepository = inMemoryTaskRepository;

            TaskManagementController.AddTask(new TaskItem("eins").Title);
            Assert.Empty(string.Empty);
        }

        /// <summary>
        ///     The test todo engine and component.
        /// </summary>
        [Fact]
        public void TestTaskManagementEngine()
        {
            ProgramSample.ConfgureTaskManagementEngine();

            TaskManagementEngineSetup.AddTask(new TaskItem("1eins"));
            TaskManagementEngineSetup.AddTask(new TaskItem("2eins"));
            TaskManagementEngineSetup.AddTask(new TaskItem("3eins"));
            TaskManagementEngineSetup.AddTask(new TaskItem("4eins"));
            Assert.Empty(string.Empty);
        }
    }
}