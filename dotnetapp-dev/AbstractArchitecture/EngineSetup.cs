#region

using dotnetapp.AseFramework.Models;

#endregion

namespace dotnetapp.AbstractArchitecture
{
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