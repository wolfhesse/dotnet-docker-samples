using DnsLib.ComponentLibrary.Lab;
using DnsLib.FactoryFloor.TodoComponent;

namespace DotnetApp.Tests.ClassLibrary
{
    /// <summary>
    ///     The in memory test configuration.
    /// </summary>
    public class InMemoryTestConfiguration
    {
        /// <summary>
        ///     The todo engine.
        /// </summary>
        public static InMemoryTodoEngine TaskManagementEngineSetup = new InMemoryTodoEngine();

        /// <summary>
        ///     The task repository.
        /// </summary>
        public static AbstractTodoRepository TaskRepository = new InMemoryTodoRepository();
    }
}