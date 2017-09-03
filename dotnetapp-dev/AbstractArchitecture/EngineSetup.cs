// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineSetup.cs" company="ase">
//   mit
// </copyright>
// <summary>
//   The engine setup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.AbstractArchitecture
{
    #region

    using DotnetApp.AseFramework.Models;

    #endregion

    /// <summary>
    /// The engine setup.
    /// </summary>
    public class EngineSetup
    {
        /// <summary>
        /// The dates container model.
        /// </summary>
        public readonly DatesContainerModel DatesContainerModel;

        /// <summary>
        /// The view.
        /// </summary>
        public readonly IView View;

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineSetup"/> class.
        /// </summary>
        /// <param name="datesContainerModel">
        /// The dates container model.
        /// </param>
        /// <param name="view">
        /// The view.
        /// </param>
        public EngineSetup(DatesContainerModel datesContainerModel, IView view)
        {
            this.DatesContainerModel = datesContainerModel;
            this.View = view;
        }
    }
}