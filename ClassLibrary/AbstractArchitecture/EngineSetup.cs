// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineSetup.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the EngineSetup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClassLibrary.AbstractArchitecture
{
    using AseFramework.Models;

    public class EngineSetup
    {
        public readonly DatesContainerModel DatesContainerModel;
        public readonly IView View;

        public EngineSetup(DatesContainerModel datesContainerModel, IView view)
        {
            DatesContainerModel = datesContainerModel;
            View = view;
        }
    }
}