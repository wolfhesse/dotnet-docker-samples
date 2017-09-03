#region

using System;
using ClassLibrary.TodoComponent.Entities;
using Newtonsoft.Json;

#endregion

namespace ClassLibrary.TodoComponent.Storage
{
    public partial class InMemoryTaskRepository
    {
    }

    public class TaskEventArgs : EventArgs
    {
        private readonly Task _task;

        public TaskEventArgs(Task task)
        {
            _task = task;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                   JsonConvert.SerializeObject(_task,Formatting.Indented);
        }
    }
}