#region

using System;

#endregion

namespace dotnetapp.TodoComponent.Entities
{
    public class TodoTask
    {
        public TodoTask()
        {
        }

        public TodoTask(string title)
        {
            CreatedAt = DateTimeOffset.Now;
            Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public bool IsValid()
        {
            return Title.Trim().Length > 0;
        }
    }
}