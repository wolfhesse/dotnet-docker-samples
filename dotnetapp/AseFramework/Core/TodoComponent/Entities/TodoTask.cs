namespace DotnetApp.AseFramework.Core.TodoComponent.Entities
{
    #region using directives

    using System;

    #endregion

    /// <summary>
    ///     The todo task.
    /// </summary>
    public class TodoTask
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TodoTask" /> class.
        /// </summary>
        public TodoTask()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TodoTask" /> class.
        /// </summary>
        /// <param name="title">
        ///     The title.
        /// </param>
        public TodoTask(string title)
        {
            this.CreatedAt = DateTimeOffset.Now;
            this.Title = title;
        }

        /// <summary>
        ///     Gets or sets the created at.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     The is valid.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool IsValid()
        {
            return this.Title.Trim().Length > 0;
        }
    }
}