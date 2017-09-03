using ClassLibrary.TodoComponent.Entities;

namespace ClassLibrary.TodoComponent.Storage
{
    public interface ITaskRepository
    {
        int Count { get; }
        event InMemoryTaskRepository.TaskAddedEventHandler EvTaskAdded;
        void Persist(Task t);
        Task FindTask(int taskId);
    }
}