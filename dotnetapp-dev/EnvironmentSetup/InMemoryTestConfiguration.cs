namespace DotnetApp.EnvironmentSetup
{
    using DotnetApp.TodoComponent;
    using DotnetApp.TodoComponent.Storage;

    public class InMemoryTestConfiguration
    {
        public static ITaskRepository TaskRepository = new InMemoryTaskRepository();
        public static TodoEngine TodoEngine = new TodoEngine();
    }
}