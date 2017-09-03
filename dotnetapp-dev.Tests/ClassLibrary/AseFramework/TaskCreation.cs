#region

#endregion

namespace DotnetAppDev.Tests.ClassLibrary.AseFramework
{
    using System;

    using DotnetApp.EnvironmentSetup;
    using DotnetApp.TodoComponent.Utilities;

    using NUnit.Framework;

    [TestFixture]
    public class TaskCreation
    {
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