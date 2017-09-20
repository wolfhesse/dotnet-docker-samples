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
    #region using directives

    using DnsLib.AseFramework.Core.TodoComponent.Storage;
    using DnsLib.AseFramework.Lib.EngineSetups;

    #endregion

    /// <summary>
    ///     The in memory test configuration.
    /// </summary>
    public class InMemoryTestConfiguration
    {
        /// <summary>
        ///     The todo engine.
        /// </summary>
        public static TaskManagementEngineSetup TaskManagementEngineSetup = new TaskManagementEngineSetup();

        /// <summary>
        ///     The task repository.
        /// </summary>
        public static ITaskRepository TaskRepository = new InMemoryTaskRepository();
    }
}