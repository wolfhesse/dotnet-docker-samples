using System;
using DnsLib.ComponentLibrary.Lab;
using DnsLib.FactoryFloor.TodoComponent;

namespace DotnetApp.Tests.ClassLibrary
{
    /// <inheritdoc />
    /// <summary>
    ///     The todo engine. (Todo Provider)
    /// </summary>
    public class TodoManagementControllerVariant : InMemoryTodoEngine
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