namespace DotnetAppDev.Tests.ClassLibrary.AseFramework
{
    #region using directives

    using System;

    using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;
    using DotnetApp.AseFramework.Core.TodoComponent.Utilities;

    using NUnit.Framework;

    #endregion

    /// <summary>
    ///     The task creation.
    /// </summary>
    [TestFixture]
    public class TaskCreation
    {
        /// <summary>
        ///     The test task created at.
        /// </summary>
        [Test]
        public void TestTaskCreatedAt()
        {
            var task = TaskBuilder.BuildTask("sample");
            EnvManager.DefaultOut = new EnvironmentOutputAdapter(Console.Out);
            EnvManager.DefaultOut.WriteLine(task);
            Assert.IsNotNull(task.CreatedAt);
        }
    }
}