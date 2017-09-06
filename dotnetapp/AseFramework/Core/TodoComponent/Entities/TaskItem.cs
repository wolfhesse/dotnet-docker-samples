#region using directives

using System;

#endregion

namespace DotnetApp.AseFramework.Core.TodoComponent.Entities
{
    #region using directives

    #endregion

    /// <summary>
    ///     The todo task.
    /// </summary>
    public class TaskItem
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TaskItem" /> class.
        /// </summary>
        public TaskItem()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TaskItem" /> class.
        /// </summary>
        /// <param name="title">
        ///     The title.
        /// </param>
        public TaskItem(string title)
        {
            CreatedAt = DateTimeOffset.Now;
            Title = title;
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
            return Title.Trim().Length > 0;
        }
    }
}