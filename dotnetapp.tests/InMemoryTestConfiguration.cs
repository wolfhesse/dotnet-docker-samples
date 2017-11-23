// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryTestConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The in memory test configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.Tests.Unittests
{
    using DnsLib.AseFramework.Core.TodoComponent;
    using DnsLib.FactoryFloor;
    using DnsLib.Operations;

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