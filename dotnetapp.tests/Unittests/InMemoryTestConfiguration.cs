#region using directives

using DotnetApp.AseFramework.Core.TaskManagementComponent.Storage;
using DotnetApp.ProgramSetup.EngineSetups;

#endregion

namespace DotnetAppDev.Tests.Unittests
{
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