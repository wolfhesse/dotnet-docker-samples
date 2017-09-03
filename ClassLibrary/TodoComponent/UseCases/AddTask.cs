﻿using System;
using ClassLibrary.TodoComponent.Entities;
using ClassLibrary.TodoComponent.Storage;
 using ClassLibrary.TodoComponent.Utilities;

namespace ClassLibrary.TodoComponent.UseCases
{
    public class AddTask
    {
        public static void Execute(string title)
        {
            var task = TaskBuilder.BuildTask(title);
            TodoController.TaskRepository.Persist(task);
        }

        internal static void Execute(ITaskRepository taskRepository, Task task)
        {
            taskRepository.Persist(task);
        }
    }
}