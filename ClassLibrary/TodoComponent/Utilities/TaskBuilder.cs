#region

using ClassLibrary.TodoComponent.Entities;

#endregion

namespace ClassLibrary.TodoComponent.Utilities
{
    public class TaskBuilder
    {
        public static Task BuildTask(string title)
        {
            var t = new Task(title)
            {
                ExtraCreatorInfo = typeof(TaskBuilder)
            };
            return t;
        }
    }
}