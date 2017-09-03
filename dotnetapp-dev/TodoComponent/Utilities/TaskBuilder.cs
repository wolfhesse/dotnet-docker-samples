#region

#endregion

namespace DotnetApp.TodoComponent.Utilities
{
    using DotnetApp.TodoComponent.Entities;

    public class TaskBuilder
    {
        public static TodoTask BuildTask(string title)
        {
            var t = new TodoTask(title);
            return t;
        }
    }
}