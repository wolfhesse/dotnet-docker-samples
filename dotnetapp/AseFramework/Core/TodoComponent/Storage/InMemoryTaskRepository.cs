namespace DotnetApp.AseFramework.Core.TodoComponent.Storage
{
    #region using directives

    using System.Collections.Generic;
    using System.Diagnostics;

    using DotnetApp.AseFramework.Core.TodoComponent.Entities;

    #endregion

    /// <summary>
    ///     The in memory task repository.
    /// </summary>
    public class InMemoryTaskRepository : ITaskRepository
    {
        /// <summary>
        ///     The _tasks.
        /// </summary>
        private readonly List<TodoTask> _tasks;

        /// <summary>
        ///     The _id.
        /// </summary>
        private int _id;

        /// <summary>
        ///     Initializes a new instance of the <see cref="InMemoryTaskRepository" /> class.
        /// </summary>
        public InMemoryTaskRepository()
        {
            this._tasks = new List<TodoTask>();
            this._id = 0;
        }

        /// <summary>
        ///     The task added event handler.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="eventArgs">
        ///     The event args.
        /// </param>
        public delegate void TaskAddedEventHandler(object sender, TaskEventArgs eventArgs);

        /// <summary>
        ///     The ev task added.
        /// </summary>
        public event TaskAddedEventHandler EvTaskAdded;

        /// <summary>
        ///     The count.
        /// </summary>
        public int Count => this._tasks.Count;

        /// <summary>
        ///     The find task.
        /// </summary>
        /// <param name="taskId">
        ///     The task id.
        /// </param>
        /// <returns>
        ///     The <see cref="TodoTask" />.
        /// </returns>
        public TodoTask FindTask(int taskId)
        {
            Debug.Assert(this._tasks != null, "_tasks != null");
            return this._tasks[taskId];
        }

        /// <summary>
        ///     The persist.
        /// </summary>
        /// <param name="t">
        ///     The t.
        /// </param>
        public void Persist(TodoTask t)
        {
            t.Id = this._id++;
            this._tasks.Add(t);
            this.OnEvTaskAdded(t);
        }

        /// <summary>
        ///     The on ev task added.
        /// </summary>
        /// <param name="todoTask">
        ///     The todo task.
        /// </param>
        protected virtual void OnEvTaskAdded(TodoTask todoTask)
        {
            var eventArgs = new TaskEventArgs(todoTask);
            this.EvTaskAdded?.Invoke(this, eventArgs);
        }
    }
}