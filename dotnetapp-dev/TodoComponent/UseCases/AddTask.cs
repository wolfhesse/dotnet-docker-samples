// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddTask.cs" company="">
//   
// </copyright>
// <summary>
//   The add task.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.TodoComponent.UseCases
{
    #region

    using DotnetApp.TodoComponent.Entities;
    using DotnetApp.TodoComponent.Storage;
    using DotnetApp.TodoComponent.Utilities;

    #endregion

    /// <summary>
    /// The add task.
    /// </summary>
    public class AddTask
    {
        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        public static void Execute(string title)
        {
            var task = TaskBuilder.BuildTask(title);
            TodoController.TaskRepository.Persist(task);
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="taskRepository">
        /// The task repository.
        /// </param>
        /// <param name="todoTask">
        /// The todo task.
        /// </param>
        internal static void Execute(ITaskRepository taskRepository, TodoTask todoTask)
        {
            taskRepository.Persist(todoTask);
        }
    }
}