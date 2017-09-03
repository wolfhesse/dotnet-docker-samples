#region

#endregion

namespace DotnetApp.TodoComponent
{
    using DotnetApp.TodoComponent.Entities;
    using DotnetApp.TodoComponent.Storage;

    public class TodoEngine
    {
        public void AddTask(ITaskRepository taskRepository,
            TodoTask todoTask)
        {
            UseCases.AddTask.Execute(taskRepository, todoTask);
        }
    }
}