#region

using System.Collections.Generic;
using System.Diagnostics;
using ClassLibrary.TodoComponent.Entities;

#endregion

namespace ClassLibrary.TodoComponent.Storage
{
    public partial class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<Task> _tasks;
        private int _id;

        public InMemoryTaskRepository()
        {
            _tasks = new List<Task>();
            _id = 0;
        }

        public int Count => _tasks.Count;
        public event TaskAddedEventHandler EvTaskAdded;

        public delegate void TaskAddedEventHandler(object sender, TaskEventArgs eventArgs);
        public void Persist(Task t)
        {
            t.Id = _id++;
            _tasks.Add(t);
            OnEvTaskAdded(t);
        }

        public Task FindTask(int taskId)
        {
            Debug.Assert(_tasks != null, "_tasks != null");
            return _tasks[taskId];
        }

        protected virtual void OnEvTaskAdded(Task task)
        {
            var eventArgs = new TaskEventArgs(task);
            EvTaskAdded?.Invoke(this, eventArgs);
        }
    }
}