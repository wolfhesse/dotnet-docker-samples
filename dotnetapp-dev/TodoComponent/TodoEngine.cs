#region

using dotnetapp.TodoComponent.Entities;
using dotnetapp.TodoComponent.Storage;

#endregion

namespace dotnetapp.TodoComponent
{
    public class TodoEngine
    {
        public void AddTask(ITaskRepository taskRepository,
            TodoTask todoTask)
        {
            UseCases.AddTask.Execute(taskRepository, todoTask);
        }
    }
}