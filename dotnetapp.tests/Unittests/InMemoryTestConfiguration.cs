#region using directives

using DotnetApp.AseFramework.Core.TodoComponent.Storage;
using DotnetApp.ProgramSetup.EngineSetups;
using DotnetAppDev.Tests.ClassLibrary.AseFramework;

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
        ///     The task repository.
        /// </summary>
        public static ITaskRepository TaskRepository = new InMemoryTaskRepository();

        /// <summary>
        ///     The todo engine.
        /// </summary>
        public static TaskManagementEngineSetup TaskManagementEngineSetup = new TaskManagementEngineSetup();
    }
}