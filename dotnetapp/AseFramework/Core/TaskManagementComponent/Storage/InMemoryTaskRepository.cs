#region using directives

using System.Collections.Generic;
using System.Diagnostics;
using DotnetApp.AseFramework.Core.TaskManagementComponent.Entities;

#endregion

namespace DotnetApp.AseFramework.Core.TaskManagementComponent.Storage
{
    #region using directives

    #endregion

    /// <summary>
    ///     The in memory task repository.
    /// </summary>
    public class InMemoryTaskRepository : ITaskRepository
    {
        /// <summary>
        ///     The _tasks.
        /// </summary>
        private readonly List<TaskItem> _tasks;

        /// <summary>
        ///     The _id.
        /// </summary>
        private int _id;

        /// <summary>
        ///     Initializes a new instance of the <see cref="InMemoryTaskRepository" /> class.
        /// </summary>
        public InMemoryTaskRepository()
        {
            _tasks = new List<TaskItem>();
            _id = 0;
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
        public int Count => _tasks.Count;

        /// <summary>
        ///     The find task.
        /// </summary>
        /// <param name="taskId">
        ///     The task id.
        /// </param>
        /// <returns>
        ///     The <see cref="TaskItem" />.
        /// </returns>
        public TaskItem FindTask(int taskId)
        {
            Debug.Assert(_tasks != null, "_tasks != null");
            return _tasks[taskId];
        }

        /// <summary>
        ///     The persist.
        /// </summary>
        /// <param name="t">
        ///     The t.
        /// </param>
        public void Persist(TaskItem t)
        {
            t.Id = _id++;
            _tasks.Add(t);
            OnEvTaskAdded(t);
        }

        /// <summary>
        ///     The on ev task added.
        /// </summary>
        /// <param name="taskItem">
        ///     The todo task.
        /// </param>
        protected virtual void OnEvTaskAdded(TaskItem taskItem)
        {
            var eventArgs = new TaskEventArgs(taskItem);
            EvTaskAdded?.Invoke(this, eventArgs);
        }
    }
}