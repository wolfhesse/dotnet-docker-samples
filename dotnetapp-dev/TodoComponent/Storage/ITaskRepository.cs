using dotnetapp.TodoComponent.Entities;

namespace dotnetapp.TodoComponent.Storage
{
    public interface ITaskRepository
    {
        int Count { get; }
        event InMemoryTaskRepository.TaskAddedEventHandler EvTaskAdded;
        void Persist(TodoTask t);
        TodoTask FindTask(int taskId);
    }
}