#region using directives

using System;
using DotnetApp.AseFramework.Core.TaskManagementComponent.Storage;

#endregion

namespace DotnetApp.AseFramework.Core
{
    #region using directives

    #endregion

    /// <summary>
    ///     The todo controller. component
    /// </summary>
    public class TaskManagementController
    {
        /// <summary>
        ///     Gets the task repository.
        /// </summary>
        public static ITaskRepository TaskRepository { get; set; } = new InMemoryTaskRepository();

        /// <summary>
        ///     The add task.
        /// </summary>
        /// <param name="title">
        ///     The title.
        /// </param>
        public static void AddTask(string title)
        {
            Console.Out.WriteLine(typeof(TaskManagementController) + ".AddTask");
            TaskManagementComponent.UseCases.AddTask.Execute(title);
        }
    }
}