#region using directives

using System;
using System.Collections.Generic;
using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;

#endregion

namespace DotnetApp.AseFramework.Models
{
    #region using directives

    #endregion

    /// <summary>
    ///     The dates container model.
    /// </summary>
    public class DatesContainerModel
    {
        /// <summary>
        ///     The ev warning.
        /// </summary>
        public event EventHandler EvWarning;

        /// <summary>
        ///     The model changed.
        /// </summary>
        public event EventHandler ModelChanged;

        /// <summary>
        ///     The model sorted.
        /// </summary>
        public event EventHandler ModelSorted;

        /// <summary>
        ///     Gets the dates.
        /// </summary>
        public MySortedSet<DateTimeOffset> Dates { get; private set; }

        /// <summary>
        ///     The sys warnings.
        /// </summary>
        public IList<string> SysWarnings => Dates.SysWarnings;

        /// <summary>
        ///     The create dates.
        /// </summary>
        public void CreateDates()
        {
            EnvManager.WriteLine($"{this}.CreateDates");
            Dates =
                new MySortedSet<DateTimeOffset>
                {
                    DateTimeOffset.MinValue.LocalDateTime,
                    DateTimeOffset.MaxValue.LocalDateTime
                };
            Dates.EvWarning += Dates_EvWarning;
            OnModelChanged();
        }

        /// <summary>
        ///     The insert timestamp.
        /// </summary>
        public void InsertTimestamp()
        {
            EnvManager.WriteLine($"{this}.InsertTimestamp");
            var ts0 = DateTimeOffset.Now.LocalDateTime;
            var ts1 = DateTimeOffset.Now;
            Dates.Add(ts0);
            Dates.Add(ts0);
            Dates.Add(ts0);
            Dates.Add(ts0);
            Dates.Add(ts0);
            Dates.Add(ts0);
            Dates.Add(ts1);
            Dates.Add(ts1);
            Dates.Add(ts1);
            Dates.Add(ts1);
            Dates.Add(ts1);
            Dates.Add(ts1);

            OnModelChanged();
        }

        /// <summary>
        ///     The sort.
        /// </summary>
        public void Sort()
        {
            EnvManager.WriteLine($"{this}.Sort");

            // TODO need deprecation notice; this.Dates is now SortedSet
            Dates.Sort();

            // wird aus Sort ausgeloest    OnEvWarning();
            OnModelSorted();
            OnModelChanged();
        }

        /// <summary>
        ///     The on ev warning.
        /// </summary>
        protected virtual void OnEvWarning()
        {
            EvWarning?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     The on model changed.
        /// </summary>
        protected virtual void OnModelChanged()
        {
            ModelChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     The on model sorted.
        /// </summary>
        protected virtual void OnModelSorted()
        {
            ModelSorted?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     The dates_ ev warning.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The e.
        /// </param>
        private void Dates_EvWarning(object sender, EventArgs e)
        {
            // weiterreichen
            OnEvWarning();
        }

        /// <summary>
        ///     derive from SortedSet to put deprecation notice into 'Sort' method
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        public class MySortedSet<T> : SortedSet<T>
        {
            /// <summary>
            ///     The ev warning.
            /// </summary>
            public event EventHandler EvWarning;

            /// <summary>
            ///     Gets the sys warnings.
            /// </summary>
            public IList<string> SysWarnings { get; } = new List<string>();

            /// <summary>
            ///     The sort.
            /// </summary>
            internal void Sort()
            {
                SysWarnings.Add(
                    $"{this}\n\t - deprecation notice: Dates is now a SortedSet; not need to call Sort");
                OnEvWarning();
            }

            /// <summary>
            ///     The on ev warning.
            /// </summary>
            protected virtual void OnEvWarning()
            {
                EvWarning?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}