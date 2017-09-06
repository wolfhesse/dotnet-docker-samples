using DotnetApp.AseFramework.Core.TaskManagementComponent.Utilities;

namespace DotnetAppDev.Tests.ClassLibrary.AseFramework
{
    #region using directives

    using System;

    using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;
    using NUnit.Framework;

    #endregion

    /// <summary>
    ///     The task creation.
    /// </summary>
    [TestFixture]
    public class TaskCreationNUnitTest
    {
        /// <summary>
        ///     The test task created at.
        /// </summary>
        [Test]
        public void TestTaskCreatedAt()
        {
            var task = TaskBuilder.BuildTask("sample");
            EnvManager.DefaultOut = new EnvironmentOutputAdapter(Console.Out);
            EnvManager.WriteLine(task);
            Assert.IsNotNull(task.CreatedAt);
        }
    }
}