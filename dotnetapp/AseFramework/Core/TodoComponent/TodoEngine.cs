namespace DotnetApp.AseFramework.Core.TodoComponent
{
    #region using directives

    using DotnetApp.AseFramework.Core.TodoComponent.Entities;
    using DotnetApp.AseFramework.Core.TodoComponent.Storage;

    #endregion

    /// <summary>
    ///     The todo engine.
    /// </summary>
    public class TodoEngine
    {
        /// <summary>
        ///     The add task.
        /// </summary>
        /// <param name="taskRepository">
        ///     The task repository.
        /// </param>
        /// <param name="todoTask">
        ///     The todo task.
        /// </param>
        public void AddTask(ITaskRepository taskRepository, TodoTask todoTask)
        {
            UseCases.AddTask.Execute(taskRepository, todoTask);
        }
    }
}