using System;
using System.Collections.Generic;
using System.IO;
using ClassLibrary.AbstractArchitecture;
using ClassLibrary.AseFramework.Models;

namespace ClassLibrary.AseFramework.Controllers
{
    public class DatesContainerOperations
    {
        protected static Presenter Port { get; set; }

        protected class Controller
        {
            private readonly EngineSetup _engineSetup;

            public Controller(EngineSetup engineSetup, TextWriter textWriter)
            {
                Port = new Presenter {TextWriter = textWriter};
                Port.TextWriter.WriteLine("controller initialization...");

                _engineSetup = engineSetup;

                Port.TextWriter.WriteLine("controller initialized...");
            }

            public void ActionBatch()
            {
                _engineSetup.DatesContainerModel.CreateDates();
                _engineSetup.DatesContainerModel.InsertTimestamp();
                _engineSetup.DatesContainerModel.Sort();
                OnAfterAction();
            }

            public event EventHandler AfterAction;


            protected virtual void OnAfterAction()
            {
                AfterAction?.Invoke(this, EventArgs.Empty);
            }
        }

        public class View : IView
        {
            private readonly DatesContainerModel _datesContainerModel;
            private int _counter;

//            private View()
//            {
//            }

            public View(DatesContainerModel datesContainerModel)
            {
                _datesContainerModel = datesContainerModel;

                _datesContainerModel.ModelChanged += (sender, args) =>
                {
                    Port.TextWriter.WriteLine("Ev DatesContainerModel.ModelChanged Handling");
                    Render();
                    Port.TextWriter.WriteLine(Environment.NewLine);
                };

                _datesContainerModel.ModelSorted += (sender, args) =>
                {
                    Port.TextWriter.WriteLine("Ev DatesContainerModel.ModelSorted Handling");
                    Port.TextWriter.WriteLine("=== datesContainerModel Dates are SortedSet ===");
                    Port.TextWriter.WriteLine(Environment.NewLine);
                };

                _datesContainerModel.EvWarning += (sender, args) =>
                {
                    // datesContainerModel fired a warning; dump it to Port and cleanup
//                    if (_datesContainerModel.SysWarnings == null) return;
                    foreach (var modelSysWarning in _datesContainerModel.SysWarnings)
                        Port.TextWriter.WriteLine(modelSysWarning);
                    _datesContainerModel.SysWarnings.Clear();
                };
            }

            public void Render()
            {
                Helper.FnOutSeparator72(Port.TextWriter, '=');
                Port.TextWriter.WriteLine(DateTimeOffset.Now.LocalDateTime);
                Port.TextWriter.WriteLine($"{this}.Render # {_counter++}");
                Port.TextWriter.WriteLine($"{this}.Render ->  {_datesContainerModel}");

                DumpDates(Port.TextWriter, _datesContainerModel.Dates);

                Helper.FnOutSeparator72(Port.TextWriter);
            }

            private void DumpDates(TextWriter textWriter, IEnumerable<DateTimeOffset> dates)
            {
                Helper.FnOutSeparator72(textWriter, '-');
                textWriter.WriteLine($"{this}.DumpDates: +++ dates: min, now, max");
                Helper.FnOutSeparator72(textWriter, '-');
                foreach (var dateTimeOffset in dates)
                    textWriter.WriteLine($"=== dates-item: {dateTimeOffset}");
            }
        }
    }
}