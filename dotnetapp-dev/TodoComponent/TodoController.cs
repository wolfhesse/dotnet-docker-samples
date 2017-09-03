#region

#endregion

namespace DotnetApp.TodoComponent
{
    using System;

    using DotnetApp.TodoComponent.Storage;

    public class TodoController
    {
        public static ITaskRepository TaskRepository { get; } = new InMemoryTaskRepository();

        public static void AddTask(string title)
        {
            Console.Out.WriteLine(typeof(TodoController) + ".AddTask");
            UseCases.AddTask.Execute(title);
        }
    }
}