using System;

namespace ClassLibrary.TodoComponent.Entities
{
    public class Task
    {
        internal Task()
        {
        }

        public Task(string title)
        {
            CreatedAt = DateTimeOffset.Now;
            Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public Type ExtraCreatorInfo { get; set; }

        public bool IsValid()
        {
            return Title.Trim().Length > 0;
        }
    }
}