// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryTestConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The in memory test configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.EnvironmentSetup
{
    #region

    using DotnetApp.TodoComponent;
    using DotnetApp.TodoComponent.Storage;

    #endregion

    /// <summary>
    /// The in memory test configuration.
    /// </summary>
    public class InMemoryTestConfiguration
    {
        /// <summary>
        /// The task repository.
        /// </summary>
        public static ITaskRepository TaskRepository = new InMemoryTaskRepository();

        /// <summary>
        /// The todo engine.
        /// </summary>
        public static TodoEngine TodoEngine = new TodoEngine();
    }
}