#region

#endregion

namespace DotnetApp.AbstractArchitecture
{
    using DotnetApp.AseFramework.Models;

    public class EngineSetup
    {
        public readonly DatesContainerModel DatesContainerModel;
        public readonly IView View;

        public EngineSetup(DatesContainerModel datesContainerModel, IView view)
        {
            this.DatesContainerModel = datesContainerModel;
            this.View = view;
        }
    }
}