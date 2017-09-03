// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskCreation.cs" company="">
//   
// </copyright>
// <summary>
//   The task creation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetAppDev.Tests.ClassLibrary.AseFramework
{
    #region

    using System;

    using DotnetApp.EnvironmentSetup;
    using DotnetApp.TodoComponent.Utilities;

    using NUnit.Framework;

    #endregion

    /// <summary>
    /// The task creation.
    /// </summary>
    [TestFixture]
    public class TaskCreation
    {
        /// <summary>
        /// The test task created at.
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