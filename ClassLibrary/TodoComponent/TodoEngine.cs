﻿using ClassLibrary.TodoComponent.Entities;
using ClassLibrary.TodoComponent.Storage;

namespace ClassLibrary.TodoComponent
{
    public class TodoEngine
    {
        public void AddTask(ITaskRepository taskRepository,
            Task task)
        {
            UseCases.AddTask.Execute(taskRepository, task);
        }
    }
}