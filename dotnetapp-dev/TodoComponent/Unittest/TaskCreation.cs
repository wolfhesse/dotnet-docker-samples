#region

using dotnetapp.TodoComponent.Utilities;
using NUnit.Framework;

#endregion

namespace dotnetapp.TodoComponent.Unittest
{
    public class TaskCreation
    {
        [Test]
        public void TestTaskCreatedAt()
        {
            var task = TaskBuilder.BuildTask("sample");
            Assert.IsNotNull(task.CreatedAt);
        }
    }
}