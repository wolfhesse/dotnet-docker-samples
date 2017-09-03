#region

#endregion

namespace DotnetApp.TodoComponent.UseCases
{
    using DotnetApp.TodoComponent.Entities;
    using DotnetApp.TodoComponent.Storage;
    using DotnetApp.TodoComponent.Utilities;

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