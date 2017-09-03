namespace DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup
{
    #region using directives

    using DotnetApp.AseFramework.Core.TodoComponent;
    using DotnetApp.AseFramework.Core.TodoComponent.Storage;

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
        public static TodoEngine TodoEngine = new TodoEngine();
    }
}