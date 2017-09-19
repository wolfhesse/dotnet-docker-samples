namespace DnsLib.ProgramSetupHere.EngineSetups
{
    #region using directives

    using DnsLib.AseFramework.AbstractArchitecture;
    using DnsLib.AseFramework.Models;

    #endregion

    #region using directives

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
            this.DatesContainerModel = datesContainerModel;
            this.View = view;
        }

        /// <summary>
        ///     The action batch.
        /// </summary>
        public void ActionBatch()
        {
            this.DatesContainerModel.CreateDates();
            this.DatesContainerModel.InsertTimestamp();
            this.DatesContainerModel.Sort();
        }
    }
}