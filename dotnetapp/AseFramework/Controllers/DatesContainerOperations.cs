#region using directives

using System;
using System.Collections.Generic;
using System.IO;
using DotnetApp.AseFramework.AbstractArchitecture;
using DotnetApp.AseFramework.Models;
using DotnetApp.ProgramSetup.EngineSetups;

#endregion

namespace DotnetApp.AseFramework.Controllers
{
    #region using directives

    #endregion

    /// <summary>
    ///     The dates container operations.
    /// </summary>
    public class DatesContainerOperations
    {
        /// <summary>
        ///     Gets or sets the port.
        /// </summary>
        protected static Presenter Port { get; set; }

        /// <summary>
        ///     The controller.
        /// </summary>
        public class Controller : IDisposable
        {
            /// <summary>
            ///     The dates engine setup.
            /// </summary>
            private readonly DatesEngineSetup _datesEngineSetup;

            /// <summary>
            ///     Initializes a new instance of the <see cref="Controller" /> class.
            /// </summary>
            /// <param name="datesEngineSetup">
            ///     The dates engine setup.
            /// </param>
            /// <param name="textWriter">
            ///     The text writer.
            /// </param>
            public Controller(DatesEngineSetup datesEngineSetup, TextWriter textWriter)
            {
                Port = new Presenter {TextWriter = textWriter};
                Port.TextWriter.WriteLine("controller initialization...");

                _datesEngineSetup = datesEngineSetup;

                Port.TextWriter.WriteLine("controller initialized...");
            }

            /// <summary>
            ///     The after action.
            /// </summary>
            public event EventHandler EvAfterActionHookEventHandler;

            /// <summary>
            ///     The ev post processing hook.
            /// </summary>
            public event EventHandler EvPostProcessingHook;

            /// <summary>
            ///     Gets or sets the ts start.
            /// </summary>
            public DateTime TsStart { get; set; }

            /// <summary>
            ///     The dispose.
            /// </summary>
            public void Dispose()
            {
                Console.Write("disposing " + this);
            }

            /// <summary>
            ///     The fire post processing.
            /// </summary>
            public void FirePostProcessing()
            {
                OnEvPostProcessingHook();
            }

            /// <summary>
            ///     The action batch.
            /// </summary>
            public void StartActionBatch()
            {
                _datesEngineSetup.ActionBatch();
                OnEvAfterActionHookEventHandler();
            }

            /// <summary>
            ///     The on ev after action hook event handler.
            /// </summary>
            protected virtual void OnEvAfterActionHookEventHandler()
            {
                EvAfterActionHookEventHandler?.Invoke(this, EventArgs.Empty);
            }

            /// <summary>
            ///     The on ev post processing hook.
            /// </summary>
            protected virtual void OnEvPostProcessingHook()
            {
                EvPostProcessingHook?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        ///     The helper.
        /// </summary>
        public class Helper
        {
            /// <summary>
            ///     The fn out separator 72.
            /// </summary>
            /// <param name="textWriter">
            ///     The text writer.
            /// </param>
            /// <param name="character">
            ///     The character.
            /// </param>
            public static void FnOutSeparator72(TextWriter textWriter, char character = '_')
            {
                textWriter.WriteLine(new string(character, 72));
            }
        }

        /// <summary>
        ///     The view.
        /// </summary>
        public class View : IView
        {
            /// <summary>
            ///     The _dates container model.
            /// </summary>
            private readonly DatesContainerModel _datesContainerModel;

            /// <summary>
            ///     The _counter.
            /// </summary>
            private int _counter;

            /// <summary>
            ///     Initializes a new instance of the <see cref="View" /> class.
            /// </summary>
            /// <param name="datesContainerModel">
            ///     The dates container model.
            /// </param>
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
                    // if (_datesContainerModel.SysWarnings == null) return;
                    foreach (var modelSysWarning in _datesContainerModel.SysWarnings)
                    {
                        Port.TextWriter.WriteLine(modelSysWarning);

                        // ReSharper disable once ObjectCreationAsStatement
                        new WarningWrittenHook(this);
                    }

                    _datesContainerModel.SysWarnings.Clear();
                    var unused = new SysWarningsClearedHook(this);
                };
            }

            // private View()
            // {
            // }

            /// <summary>
            ///     The ev sys warnings cleard.
            /// </summary>
            public event EventHandler EvSysWarningsCleared;

            /// <summary>
            ///     The ev warning written.
            /// </summary>
            public event EventHandler EvWarningWritten;

            /// <summary>
            ///     The render.
            /// </summary>
            public void Render()
            {
                Helper.FnOutSeparator72(Port.TextWriter, '=');
                Port.TextWriter.WriteLine(DateTimeOffset.Now.LocalDateTime);
                Port.TextWriter.WriteLine($"{this}.Render # {_counter++}");
                Port.TextWriter.WriteLine($"{this}.Render ->  {_datesContainerModel}");

                DumpDates(Port.TextWriter, _datesContainerModel.Dates);

                Helper.FnOutSeparator72(Port.TextWriter);
            }

            /// <summary>
            ///     The on ev sys warnings cleard.
            /// </summary>
            protected virtual void OnEvSysWarningsCleared()
            {
                EvSysWarningsCleared?.Invoke(this, EventArgs.Empty);
            }

            /// <summary>
            ///     The on ev warning written.
            /// </summary>
            protected virtual void OnEvWarningWritten()
            {
                EvWarningWritten?.Invoke(this, EventArgs.Empty);
            }

            /// <summary>
            ///     The dump dates.
            /// </summary>
            /// <param name="textWriter">
            ///     The text writer.
            /// </param>
            /// <param name="dates">
            ///     The dates.
            /// </param>
            private void DumpDates(TextWriter textWriter, IEnumerable<DateTimeOffset> dates)
            {
                Helper.FnOutSeparator72(textWriter, '-');
                textWriter.WriteLine($"{this}.DumpDates: +++ dates: min, now, max");
                Helper.FnOutSeparator72(textWriter, '-');
                foreach (var dateTimeOffset in dates) textWriter.WriteLine($"=== dates-item: {dateTimeOffset}");
            }

            /// <summary>
            ///     The sys warnings cleared hook.
            /// </summary>
            public class SysWarningsClearedHook
            {
                /// <summary>
                ///     Initializes a new instance of the <see cref="SysWarningsClearedHook" /> class.
                /// </summary>
                /// <param name="view">
                ///     The view.
                /// </param>
                /// <exception cref="NotImplementedException">
                /// </exception>
                public SysWarningsClearedHook(View view)
                {
                    view.OnEvSysWarningsCleared();
                }
            }

            /// <summary>
            ///     The warning written hook.
            /// </summary>
            public class WarningWrittenHook
            {
                /// <summary>
                ///     Initializes a new instance of the <see cref="WarningWrittenHook" /> class.
                /// </summary>
                /// <param name="view">
                ///     The view.
                /// </param>
                /// <exception cref="NotImplementedException">
                /// </exception>
                public WarningWrittenHook(View view)
                {
                    view.OnEvWarningWritten();
                }
            }
        }
    }
}