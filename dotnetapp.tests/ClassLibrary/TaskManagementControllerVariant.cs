﻿// --------------------------------------------------------------------------------------------------------------------
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

    using DnsLib.AseFramework.Core.TodoComponent;
    using DnsLib.AseFramework.Core.TodoComponent.Entities;

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
        /// <param name="TodoItem">The todo task.</param>
        public static void AddTask(TodoItem TodoItem)
        {
            // add inception date info
            var extendetTitle = $"[TaskVariantInception: {InceptionDate}] // " + TodoItem.Title;
            AddTask(extendetTitle);
        }
    }
}