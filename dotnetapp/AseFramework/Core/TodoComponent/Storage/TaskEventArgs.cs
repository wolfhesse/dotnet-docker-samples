namespace DotnetApp.AseFramework.Core.TodoComponent.Storage
{
    #region using directives

    using System;

    using DotnetApp.AseFramework.Core.TodoComponent.Entities;

    using Newtonsoft.Json;

    #endregion

    /// <summary>
    ///     The task event args.
    /// </summary>
    public class TaskEventArgs : EventArgs
    {
        /// <summary>
        ///     The _todo task.
        /// </summary>
        private readonly TodoTask _todoTask;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TaskEventArgs" /> class.
        /// </summary>
        /// <param name="todoTask">
        ///     The todo task.
        /// </param>
        public TaskEventArgs(TodoTask todoTask)
        {
            this._todoTask = todoTask;
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
                   + JsonConvert.SerializeObject(this._todoTask, Formatting.Indented);
        }
    }
}