#region using directives

using System;
using DotnetApp.AseFramework.Core;
using DotnetApp.AseFramework.Core.TodoComponent.Entities;
using DotnetApp.AseFramework.Core.TodoComponent.Storage;

#endregion

namespace DotnetAppDev.Tests.ClassLibrary.AseFramework
{
    #region using directives

    #endregion

    /// <inheritdoc />
    /// <summary>
    ///     The todo engine. (Todo Provider)
    /// </summary>
    public class TaskManagementControllerVariant : TaskManagementController
    {
        private static string InceptionDate = DateTimeOffset.Now.ToString();

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
            // add inception date info
            var extendetTitle = $"[TaskVariantInception: {InceptionDate}] // " +
                        taskItem.Title;
            AddTask(extendetTitle);
        }
    }
}