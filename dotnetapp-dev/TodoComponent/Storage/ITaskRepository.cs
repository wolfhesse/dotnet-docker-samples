namespace DotnetApp.TodoComponent.Storage
{
    using DotnetApp.TodoComponent.Entities;

    public interface ITaskRepository
    {
        int Count { get; }
        event InMemoryTaskRepository.TaskAddedEventHandler EvTaskAdded;
        void Persist(TodoTask t);
        TodoTask FindTask(int taskId);
    }
}