#region

#endregion

namespace DotnetApp.TodoComponent.Storage
{
    using System;

    using DotnetApp.TodoComponent.Entities;

    using Newtonsoft.Json;

    public class TaskEventArgs : EventArgs
    {
        private readonly TodoTask _todoTask;

        public TaskEventArgs(TodoTask todoTask)
        {
            this._todoTask = todoTask;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                   JsonConvert.SerializeObject(this._todoTask, Formatting.Indented);
        }
    }
}