#region using directives

using DotnetApp.AseFramework.Core.TodoComponent.Entities;

#endregion

namespace DotnetApp.AseFramework.Core.TodoComponent.Utilities
{
    #region using directives

    #endregion

    /// <summary>
    ///     The task builder.
    /// </summary>
    public class TaskBuilder
    {
        /// <summary>
        ///     The build task.
        /// </summary>
        /// <param name="title">
        ///     The title.
        /// </param>
        /// <returns>
        ///     The <see cref="TaskItem" />.
        /// </returns>
        public static TaskItem BuildTask(string title)
        {
            var t = new TaskItem(title);
            return t;
        }
    }
}