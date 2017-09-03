#region

#endregion

namespace DotnetApp.TodoComponent.Storage
{
    using System.Collections.Generic;
    using System.Diagnostics;

    using DotnetApp.TodoComponent.Entities;

    public class InMemoryTaskRepository : ITaskRepository
    {
        public delegate void TaskAddedEventHandler(object sender, TaskEventArgs eventArgs);

        private readonly List<TodoTask> _tasks;
        private int _id;

        public InMemoryTaskRepository()
        {
            this._tasks = new List<TodoTask>();
            this._id = 0;
        }

        public int Count => this._tasks.Count;
        public event TaskAddedEventHandler EvTaskAdded;

        public void Persist(TodoTask t)
        {
            t.Id = this._id++;
            this._tasks.Add(t);
            this.OnEvTaskAdded(t);
        }

        public TodoTask FindTask(int taskId)
        {
            Debug.Assert(this._tasks != null, "_tasks != null");
            return this._tasks[taskId];
        }

        protected virtual void OnEvTaskAdded(TodoTask todoTask)
        {
            var eventArgs = new TaskEventArgs(todoTask);
            this.EvTaskAdded?.Invoke(this, eventArgs);
        }
    }
}