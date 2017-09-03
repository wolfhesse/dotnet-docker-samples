// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatesEngineSetup.cs" company="">
//   
// </copyright>
// <summary>
//   The dates engine setup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using dotnetapp.AbstractArchitecture;
using dotnetapp.AseFramework.Models;

namespace dotnetapp.AseFramework.EngineSetups
{
    #region

    #endregion

    /// <summary>
    ///     The dates engine setup.
    /// </summary>
    public class DatesEngineSetup
    {
        /// <summary>
        ///     The dates container model.
        /// </summary>
        public readonly DatesContainerModel DatesContainerModel;

        /// <summary>
        ///     The view.
        /// </summary>
        public readonly IView View;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DatesEngineSetup" /> class.
        /// </summary>
        /// <param name="datesContainerModel">
        ///     The dates container model.
        /// </param>
        /// <param name="view">
        ///     The view.
        /// </param>
        public DatesEngineSetup(DatesContainerModel datesContainerModel, IView view)
        {
            DatesContainerModel = datesContainerModel;
            View = view;
        }

        /// <summary>
        ///     The action batch.
        /// </summary>
        public void ActionBatch()
        {
            DatesContainerModel.CreateDates();
            DatesContainerModel.InsertTimestamp();
            DatesContainerModel.Sort();
        }
    }
}