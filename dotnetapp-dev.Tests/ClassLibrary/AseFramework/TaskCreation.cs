#region

using System;
using dotnetapp.EnvironmentSetup;
using dotnetapp.TodoComponent.Utilities;
using NUnit.Framework;

#endregion

namespace dotnetapp
{
    [TestFixture]
    public class TaskCreation
    {
        [Test]
        public void TestTaskCreatedAt()
        {
            var task = TaskBuilder.BuildTask("sample");
            EnvManager.DefaultOut = new IWriteLineAdapter(Console.Out);
            EnvManager.DefaultOut.WriteLine(task);
            Assert.IsNotNull(task.CreatedAt);
        }
    }
}