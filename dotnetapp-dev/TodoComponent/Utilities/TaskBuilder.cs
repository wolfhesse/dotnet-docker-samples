#region

using dotnetapp.TodoComponent.Entities;

#endregion

namespace dotnetapp.TodoComponent.Utilities
{
    public class TaskBuilder
    {
        public static TodoTask BuildTask(string title)
        {
            var t = new TodoTask(title);
            return t;
        }
    }
}