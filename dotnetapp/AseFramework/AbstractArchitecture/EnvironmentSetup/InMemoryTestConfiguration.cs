#region using directives

using DotnetApp.AseFramework.Core.TodoComponent.Storage;
using DotnetApp.ProgramSetup;
using DotnetApp.ProgramSetup.EngineSetups;

#endregion

namespace DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup
{
    #region using directives

    #endregion

    /// <summary>
    ///     The in memory test configuration.
    /// </summary>
    public class InMemoryTestConfiguration
    {
        /// <summary>
        ///     The task repository.
        /// </summary>
        public static ITaskRepository TaskRepository = new InMemoryTaskRepository();

        /// <summary>
        ///     The todo engine.
        /// </summary>
        public static TaskManagementEngineSetup TaskManagementEngineSetup = new TaskManagementEngineSetup();
    }
}