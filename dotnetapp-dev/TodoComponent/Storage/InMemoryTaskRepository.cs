#region

using System.Collections.Generic;
using System.Diagnostics;
using dotnetapp.TodoComponent.Entities;

#endregion

namespace dotnetapp.TodoComponent.Storage
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        public delegate void TaskAddedEventHandler(object sender, TaskEventArgs eventArgs);

        private readonly List<TodoTask> _tasks;
        private int _id;

        public InMemoryTaskRepository()
        {
            _tasks = new List<TodoTask>();
            _id = 0;
        }

        public int Count => _tasks.Count;
        public event TaskAddedEventHandler EvTaskAdded;

        public void Persist(TodoTask t)
        {
            t.Id = _id++;
            _tasks.Add(t);
            OnEvTaskAdded(t);
        }

        public TodoTask FindTask(int taskId)
        {
            Debug.Assert(_tasks != null, "_tasks != null");
            return _tasks[taskId];
        }

        protected virtual void OnEvTaskAdded(TodoTask todoTask)
        {
            var eventArgs = new TaskEventArgs(todoTask);
            EvTaskAdded?.Invoke(this, eventArgs);
        }
    }
}