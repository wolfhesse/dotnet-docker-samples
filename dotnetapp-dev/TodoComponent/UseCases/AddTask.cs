#region

using dotnetapp.TodoComponent.Entities;
using dotnetapp.TodoComponent.Storage;
using dotnetapp.TodoComponent.Utilities;

#endregion

namespace dotnetapp.TodoComponent.UseCases
{
    public class AddTask
    {
        public static void Execute(string title)
        {
            var task = TaskBuilder.BuildTask(title);
            TodoController.TaskRepository.Persist(task);
        }

        internal static void Execute(ITaskRepository taskRepository, TodoTask todoTask)
        {
            taskRepository.Persist(todoTask);
        }
    }
}