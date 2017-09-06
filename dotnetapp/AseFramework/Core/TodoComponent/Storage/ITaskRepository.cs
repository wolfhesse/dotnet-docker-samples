#region using directives

using DotnetApp.AseFramework.Core.TodoComponent.Entities;

#endregion

namespace DotnetApp.AseFramework.Core.TodoComponent.Storage
{
    #region using directives

    #endregion

    /// <summary>
    ///     The TaskRepository interface.
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        ///     The ev task added.
        /// </summary>
        event InMemoryTaskRepository.TaskAddedEventHandler EvTaskAdded;

        /// <summary>
        ///     Gets the count.
        /// </summary>
        int Count { get; }

        /// <summary>
        ///     The find task.
        /// </summary>
        /// <param name="taskId">
        ///     The task id.
        /// </param>
        /// <returns>
        ///     The <see cref="TaskItem" />.
        /// </returns>
        TaskItem FindTask(int taskId);

        /// <summary>
        ///     The persist.
        /// </summary>
        /// <param name="t">
        ///     The t.
        /// </param>
        void Persist(TaskItem t);
    }
}