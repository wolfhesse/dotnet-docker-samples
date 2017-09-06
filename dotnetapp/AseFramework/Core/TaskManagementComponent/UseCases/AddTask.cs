#region using directives

using DotnetApp.AseFramework.Core.TaskManagementComponent.Entities;
using DotnetApp.AseFramework.Core.TaskManagementComponent.Storage;
using DotnetApp.AseFramework.Core.TaskManagementComponent.Utilities;

#endregion

namespace DotnetApp.AseFramework.Core.TaskManagementComponent.UseCases
{
    #region using directives

    #endregion

    /// <summary>
    ///     The add task.
    /// </summary>
    public class AddTask
    {
        /// <summary>
        ///     The execute.
        /// </summary>
        /// <param name="title">
        ///     The title.
        /// </param>
        public static void Execute(string title)
        {
            var task = TaskBuilder.BuildTask(title);
            TaskManagementController.TaskRepository.Persist(task);
        }

        /// <summary>
        ///     The execute.
        /// </summary>
        /// <param name="taskRepository">
        ///     The task repository.
        /// </param>
        /// <param name="taskItem">
        ///     The todo task.
        /// </param>
        internal static void Execute(ITaskRepository taskRepository, TaskItem taskItem)
        {
            taskRepository.Persist(taskItem);
        }
    }
}