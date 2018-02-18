// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryTestConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The in memory test configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DnsLib.FactoryFloor.Lab;
using DnsLib.FactoryFloor.Lab.Components;
using DnsLib.TodoComponent;

namespace DotnetApp.Tests
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