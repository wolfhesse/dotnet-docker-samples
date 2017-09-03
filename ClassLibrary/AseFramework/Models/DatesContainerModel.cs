using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClassLibrary.AseFramework.Models
{
    public class DatesContainerModel
    {
        public MySortedSet<DateTimeOffset> Dates { get; private set; }

        public IList<string> SysWarnings => Dates.SysWarnings;

        public event EventHandler EvWarning;

        public event EventHandler ModelChanged;

        public event EventHandler ModelSorted;

        public void CreateDates()
        {
            Debug.WriteLine($"{this}.CreateDates");
            Dates = new MySortedSet<DateTimeOffset>
            {
                DateTimeOffset.MinValue.LocalDateTime,
                DateTimeOffset.MaxValue.LocalDateTime
            };
            Dates.EvWarning += Dates_EvWarning;
            OnModelChanged();
        }

        private void Dates_EvWarning(object sender, EventArgs e)
        {
            // weiterreichen
            OnEvWarning();
        }

        public void InsertTimestamp()
        {
            Debug.WriteLine($"{this}.InsertTimestamp");
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

        public void Sort()
        {
            Debug.WriteLine($"{this}.Sort");
            // TODO need deprecation notice; this.Dates is now SortedSet
            Dates.Sort();
//        wird aus Sort ausgeloest    OnEvWarning();
            OnModelSorted();
            OnModelChanged();
        }

        protected virtual void OnEvWarning()
        {
            EvWarning?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnModelChanged()
        {
            ModelChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnModelSorted()
        {
            ModelSorted?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     derive from SortedSet to put deprecation notice into 'Sort' method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class MySortedSet<T> : SortedSet<T>
        {
            public IList<string> SysWarnings { get; } = new List<string>();
            public event EventHandler EvWarning;

            internal void Sort()
            {
                SysWarnings.Add(
                    $"{this}\n\t - deprecation notice: Dates is now a SortedSet; not need to call Sort");
                OnEvWarning();
            }

            protected virtual void OnEvWarning()
            {
                EvWarning?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}