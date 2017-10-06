using System;
using System.Collections;
using System.Collections.Generic;

namespace CRON
{
    /// <summary>
    /// Takes a CRON expression then yields starting from reference
    ///┌───────────── minute (0 - 59)
    ///│ ┌───────────── hour (0 - 23)
    ///│ │ ┌───────────── day of month (1 - 31)
    ///│ │ │ ┌───────────── month (1 - 12)
    ///│ │ │ │ ┌───────────── day of week (0 - 6) (Sunday to Saturday;
    ///│ │ │ │ │                     7 is also Sunday on some systems)
    ///│ │ │ │ │
    ///│ │ │ │ │
    ///* * * * *  command to execute
    /// </summary>
    public class Chronos
    {
        /// <summary>
        /// CRON Expression
        /// </summary>
        /// <param name="expression"></param>
        public Chronos(string expression)
        {
        }

        /// <summary>
        ///     Start yielding from
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public IEnumerable<DateTime> Tick(DateTime reference)
        {
            var current = new DateTime(reference.Year, 1, 1);
            if (current < reference)
                current = current.AddYears(1);
            yield return current;
            while (true)
            {
                current = current.AddYears(1);
                yield return current;
            }
        }
    }

    public class ChronoLexer
    {
        
    }

    public class Cronik : IEnumerator<DateTime>
    {
        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public DateTime Current { get; }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}