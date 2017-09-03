#region

using System;
using dotnetapp.TodoComponent.Entities;
using Newtonsoft.Json;

#endregion

namespace dotnetapp.TodoComponent.Storage
{
    public class TaskEventArgs : EventArgs
    {
        private readonly TodoTask _todoTask;

        public TaskEventArgs(TodoTask todoTask)
        {
            _todoTask = todoTask;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                   JsonConvert.SerializeObject(_todoTask, Formatting.Indented);
        }
    }
}