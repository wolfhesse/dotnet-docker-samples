#region

#endregion

namespace DotnetApp.TodoComponent.Entities
{
    using System;

    public class TodoTask
    {
        public TodoTask()
        {
        }

        public TodoTask(string title)
        {
            this.CreatedAt = DateTimeOffset.Now;
            this.Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public bool IsValid()
        {
            return this.Title.Trim().Length > 0;
        }
    }
}