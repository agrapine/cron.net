/*
Takes a CRON cron then yields starting from reference
┌───────────── minute (0 - 59)
│ ┌───────────── hour (0 - 23)
│ │ ┌───────────── day of month (1 - 31)
│ │ │ ┌───────────── month (1 - 12)
│ │ │ │ ┌───────────── day of week (0 - 6) (Sunday to Saturday;
│ │ │ │ │                     7 is also Sunday on some systems)
│ │ │ │ │
│ │ │ │ │
* * * * *  command to execute
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CRON.Exceptions;
using CRON.Segments;

namespace CRON
{
    /// <summary>
    ///     Chronos, The Enumerator
    /// TODO progressive interval increase (not quite sure how yet)
    /// TODO figure out to calibrate (restore) a state machine from outset
    /// </summary>
    public class Chronos : IEnumerator<DateTime>, IEnumerable<DateTime>
    {
        /// <summary>
        ///     CRON Expression
        /// </summary>
        /// <param name="cron"></param>
        /// <param name="outset"></param>
        public Chronos(DateTime outset, string cron)
        {
            if (string.IsNullOrEmpty(cron))
                throw new CronFaultExpr();

            Outset = new DateTime(outset.Year, outset.Month, outset.Day, outset.Hour, outset.Minute, 0);
            
            var parts = cron.Split(' ');
            if (parts.Length != 5)
                throw new CronFaultExpr();

            Minute = new CronMinute(Outset, parts[0]);
            Hour = new CronHour(Outset, parts[1]);
            DayOfMonth = new CronDayOfMonth(Outset, parts[2]);
            Month = new CronMonth(Outset, parts[3]);
            /*Day Of Week*/
            Segments = new CronSegment[] {Minute, Hour, DayOfMonth, Month};
            
            Reset();
        }

        public DateTime Outset { get; }
        public DateTime Current { get; protected set; }

        public CronHour Hour { get; }
        public CronMinute Minute { get; }
        public CronDayOfMonth DayOfMonth { get; }
        public CronMonth Month { get; }
        public CronSegment[] Segments { get; }

        public bool MoveNext()
        {
            var current = Current;
            do
            {
                current = current.AddMinutes(1);
            } while (Segments.Any(s => !s.Holds(current)));

            Current = current;
            return true;
        }

        public void Reset()
        {
            Current = Outset;
        }


        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<DateTime> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
