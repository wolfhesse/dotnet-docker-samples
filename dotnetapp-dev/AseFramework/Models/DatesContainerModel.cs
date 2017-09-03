// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatesContainerModel.cs" company="ase">
//   mit
// </copyright>
// <summary>
//   The dates container model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.AseFramework.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

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
        public IList<string> SysWarnings => this.Dates.SysWarnings;

        /// <summary>
        ///     The create dates.
        /// </summary>
        public void CreateDates()
        {
            Debug.WriteLine($"{this}.CreateDates");
            this.Dates =
                new MySortedSet<DateTimeOffset>
                    {
                        DateTimeOffset.MinValue.LocalDateTime,
                        DateTimeOffset.MaxValue.LocalDateTime
                    };
            this.Dates.EvWarning += this.Dates_EvWarning;
            this.OnModelChanged();
        }

        /// <summary>
        ///     The insert timestamp.
        /// </summary>
        public void InsertTimestamp()
        {
            Debug.WriteLine($"{this}.InsertTimestamp");
            var ts0 = DateTimeOffset.Now.LocalDateTime;
            var ts1 = DateTimeOffset.Now;
            this.Dates.Add(ts0);
            this.Dates.Add(ts0);
            this.Dates.Add(ts0);
            this.Dates.Add(ts0);
            this.Dates.Add(ts0);
            this.Dates.Add(ts0);
            this.Dates.Add(ts1);
            this.Dates.Add(ts1);
            this.Dates.Add(ts1);
            this.Dates.Add(ts1);
            this.Dates.Add(ts1);
            this.Dates.Add(ts1);

            this.OnModelChanged();
        }

        /// <summary>
        ///     The sort.
        /// </summary>
        public void Sort()
        {
            Debug.WriteLine($"{this}.Sort");

            // TODO need deprecation notice; this.Dates is now SortedSet
            this.Dates.Sort();

            // wird aus Sort ausgeloest    OnEvWarning();
            this.OnModelSorted();
            this.OnModelChanged();
        }

        /// <summary>
        ///     The on ev warning.
        /// </summary>
        protected virtual void OnEvWarning()
        {
            this.EvWarning?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     The on model changed.
        /// </summary>
        protected virtual void OnModelChanged()
        {
            this.ModelChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     The on model sorted.
        /// </summary>
        protected virtual void OnModelSorted()
        {
            this.ModelSorted?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// The dates_ ev warning.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Dates_EvWarning(object sender, EventArgs e)
        {
            // weiterreichen
            this.OnEvWarning();
        }

        /// <summary>
        /// derive from SortedSet to put deprecation notice into 'Sort' method
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
                this.SysWarnings.Add(
                    $"{this}\n\t - deprecation notice: Dates is now a SortedSet; not need to call Sort");
                this.OnEvWarning();
            }

            /// <summary>
            ///     The on ev warning.
            /// </summary>
            protected virtual void OnEvWarning()
            {
                this.EvWarning?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}