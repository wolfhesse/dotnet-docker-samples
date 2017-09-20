﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskManagementEngineSetup.cs" company="">
//   
// </copyright>
// <summary>
//   The todo engine. (Todo Provider)
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DnsLib.ProgramSetupHere.EngineSetups
{
    #region using directives

    using DnsLib.AseFramework.Core.TaskManagementComponent.Entities;
    using DnsLib.AseFramework.Core.TodoComponent;
    using DnsLib.AseFramework.Core.TodoComponent.Storage;

    #endregion

    /// <summary>
    ///     The todo engine. (Todo Provider)
    /// </summary>
    public class TaskManagementEngineSetup
    {
        /// <summary>Sets the task repository.</summary>
        public static ITaskRepository TaskRepository
        {
            set => TaskManagementController.TaskRepository = value;
        }

        /// <summary>The add task.</summary>
        /// <param>The task repository.<name>taskRepository</name></param>
        /// <param name="taskItem">The todo task.</param>
        public static void AddTask(TaskItem taskItem)
        {
            TaskManagementController.AddTask(taskItem.Title);

            // UseCases.AddTask.Execute(TaskManagementController.TaskRepository, taskItem);
        }
    }
}