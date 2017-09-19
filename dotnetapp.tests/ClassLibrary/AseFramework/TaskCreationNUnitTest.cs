﻿namespace DotnetAppDev.Tests.ClassLibrary.AseFramework
{
    #region using directives

    using System;

    using DnsLib.AseFramework.AbstractArchitecture.EnvironmentSetup;
    using DnsLib.AseFramework.Core.TodoComponent.Utilities;

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