namespace DotnetApp.AseFramework.Core.TodoComponent
{
    #region using directives

    using System;

    using DotnetApp.AseFramework.Core.TodoComponent.Storage;

    #endregion

    /// <summary>
    ///     The todo controller. component
    /// </summary>
    public class TodoController
    {
        /// <summary>
        ///     Gets the task repository.
        /// </summary>
        internal static ITaskRepository TaskRepository { get; set; } = new InMemoryTaskRepository();

        /// <summary>
        ///     The add task.
        /// </summary>
        /// <param name="title">
        ///     The title.
        /// </param>
        public static void AddTask(string title)
        {
            Console.Out.WriteLine(typeof(TodoController) + ".AddTask");
            UseCases.AddTask.Execute(title);
        }
    }
}