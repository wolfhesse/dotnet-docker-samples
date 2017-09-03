using dotnetapp.TodoComponent;
using dotnetapp.TodoComponent.Storage;

namespace ClassLibrary.EnvironmentSetup
{
    public class InMemoryTestConfiguration
    {
        public static ITaskRepository TaskRepository = new InMemoryTaskRepository();
        public static TodoEngine TodoEngine = new TodoEngine();
    }
}