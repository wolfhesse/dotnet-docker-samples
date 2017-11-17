// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskManagementControllerVariant.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the TaskManagementControllerVariant type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.Tests.ClassLibrary
{
    using System;

    using DnsLib.AseFramework.Core.Components.TodoComponent;
    using DnsLib.AseFramework.Core.Components.TodoComponent.Entities;

    /// <inheritdoc />
    /// <summary>
    ///     The todo engine. (Todo Provider)
    /// </summary>
    public class TaskManagementControllerVariant : TaskManagementController
    {
        /// <summary>The inception date.</summary>
        private static readonly string InceptionDate = DateTimeOffset.Now.ToString();

        /// <summary>The add task.</summary>
        /// <param>The task repository.<name>taskRepository</name></param>
        /// <param name="todoItem">The todo task.</param>
        public static void AddTask(TodoItem todoItem)
        {
            // add inception date info
            var extendedTitle = $"[TaskVariantInception: {InceptionDate}] // " + todoItem.Title;
            AddTask(extendedTitle);
        }
    }
}