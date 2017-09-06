#region using directives

using DotnetApp.AseFramework.Core;
using DotnetApp.AseFramework.Core.TodoComponent.Entities;
using DotnetApp.AseFramework.Core.TodoComponent.Storage;

#endregion

namespace DotnetApp.ProgramSetup.EngineSetups
{
    #region using directives

    #endregion

    /// <summary>
    ///     The todo engine. (Todo Provider)
    /// </summary>
    public class TaskManagementEngineSetup
    {
        public static ITaskRepository TaskRepository
        {
            set => TaskManagementController.TaskRepository = value;
        }

        /// <summary>
        ///     The add task.
        /// </summary>
        /// <param>
        ///     The task repository.
        ///     <name>taskRepository</name>
        /// </param>
        /// <param name="taskItem">
        ///     The todo task.
        /// </param>
        public static void AddTask(TaskItem taskItem)
        {
            TaskManagementController.AddTask(taskItem.Title);
            //            UseCases.AddTask.Execute(TaskManagementController.TaskRepository, taskItem);
        }
    }
}