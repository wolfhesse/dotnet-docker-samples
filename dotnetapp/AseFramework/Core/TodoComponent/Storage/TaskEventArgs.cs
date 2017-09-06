#region using directives

using System;
using DotnetApp.AseFramework.Core.TodoComponent.Entities;
using Newtonsoft.Json;

#endregion

namespace DotnetApp.AseFramework.Core.TodoComponent.Storage
{
    #region using directives

    #endregion

    /// <summary>
    ///     The task event args.
    /// </summary>
    public class TaskEventArgs : EventArgs
    {
        /// <summary>
        ///     The _todo task.
        /// </summary>
        private readonly TaskItem _taskItem;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TaskEventArgs" /> class.
        /// </summary>
        /// <param name="taskItem">
        ///     The todo task.
        /// </param>
        public TaskEventArgs(TaskItem taskItem)
        {
            _taskItem = taskItem;
        }

        /// <summary>
        ///     The to string.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine
                   + JsonConvert.SerializeObject(_taskItem, Formatting.Indented);
        }
    }
}