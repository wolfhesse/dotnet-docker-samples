namespace DotnetAppDev.Tests.ClassLibrary.AseFramework
{
    #region using directives

    using System;

    using DnsLib.AseFramework.AbstractArchitecture.EnvironmentSetup;
    using DnsLib.AseFramework.Core.TaskManagementComponent.Entities;
    using DnsLib.AseFramework.Core.TodoComponent;
    using DnsLib.AseFramework.Core.TodoComponent.Storage;

    using DotnetAppDev.Tests.Unittests;

    using Xunit;
    using Xunit.Abstractions;

    #endregion

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
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="T:DotnetAppDev.Tests.ClassLibrary.AseFramework.SubsystemTaskManagementXunitTest" /> class.
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

            TaskManagementControllerVariant.AddTask(new TaskItem("1eins"));
            TaskManagementControllerVariant.AddTask(new TaskItem("2eins"));
            TaskManagementControllerVariant.AddTask(new TaskItem("3eins"));
            TaskManagementControllerVariant.AddTask(new TaskItem("4eins"));
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

            TaskManagementController.AddTask(new TaskItem("eins").Title);
            Assert.Empty(string.Empty);
        }
    }
}