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
    using DnsLib.Operations;

    /// <inheritdoc />
    /// <summary>
    ///     The todo engine. (Todo Provider)
    /// </summary>
    public class TaskManagementControllerVariant : InMemoryTodoEngine
    {
        /// <summary>The inception date.</summary>
        private static readonly string InceptionDate = DateTimeOffset.Now.ToString();

        /// <summary>The add task.</summary>
        /// <param>The task repository.<name>taskRepository</name></param>
        /// <param name="todoItem">The todo task.</param>
        public static void AddTodo(TodoItem todoItem)
        {
            // add inception date info
            var extendedTitle = $"[TaskVariantInception: {InceptionDate}] // " + todoItem.Title;
            AddTodo(extendedTitle);
        }
    }
}