// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TodoController.cs" company="">
//   
// </copyright>
// <summary>
//   The todo controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.TodoComponent
{
    #region

    using System;

    using DotnetApp.TodoComponent.Storage;

    #endregion

    /// <summary>
    /// The todo controller.
    /// </summary>
    public class TodoController
    {
        /// <summary>
        /// Gets the task repository.
        /// </summary>
        public static ITaskRepository TaskRepository { get; } = new InMemoryTaskRepository();

        /// <summary>
        /// The add task.
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        public static void AddTask(string title)
        {
            Console.Out.WriteLine(typeof(TodoController) + ".AddTask");
            UseCases.AddTask.Execute(title);
        }
    }
}