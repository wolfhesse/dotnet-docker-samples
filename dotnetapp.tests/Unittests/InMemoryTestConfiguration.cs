#region using directives

#endregion

namespace DotnetAppDev.Tests.Unittests
{
    using DnsLib.AseFramework.Core.TodoComponent.Storage;
    using DnsLib.ProgramSetup.EngineSetups;

    #region using directives

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