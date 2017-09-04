#region using directives

using DotnetApp.AseFramework.Core;
using DotnetApp.AseFramework.Core.TodoComponent.Entities;
using DotnetApp.AseFramework.Core.TodoComponent.Storage;

#endregion

namespace DotnetApp.ProgramSetup
{
    #region using directives

    #endregion

    /// <summary>
    ///     The todo engine. (Todo Provider)
    /// </summary>
    public class TodoEngine
    {
        public static ITaskRepository TaskRepository
        {
            set => TodoController.TaskRepository = value;
        }

        /// <summary>
        ///     The add task.
        /// </summary>
        /// <param name="taskRepository">
        ///     The task repository.
        /// </param>
        /// <param name="todoTask">
        ///     The todo task.
        /// </param>
        public static void AddTask(TodoTask todoTask)
        {
            TodoController.AddTask(todoTask.Title);
            //            UseCases.AddTask.Execute(TodoController.TaskRepository, todoTask);
        }
    }
}