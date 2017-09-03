using System;
using ClassLibrary.TodoComponent.Storage;

namespace ClassLibrary.TodoComponent
{
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