using ClassLibrary.TodoComponent.Utilities;
using NUnit.Framework;

namespace ClassLibrary.TodoComponent.Unittest
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
