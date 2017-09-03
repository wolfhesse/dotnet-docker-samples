namespace DotnetApp.AseFramework.Core.TodoComponent.Utilities
{
    #region using directives

    using DotnetApp.AseFramework.Core.TodoComponent.Entities;

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
        ///     The <see cref="TodoTask" />.
        /// </returns>
        public static TodoTask BuildTask(string title)
        {
            var t = new TodoTask(title);
            return t;
        }
    }
}