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
using CRON.Exceptions;
using CRON.Segments;

namespace CRON
{
    /// <summary>
    ///     Chronos, The Enumerator
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

            Outset = outset;

            var parts = cron.Split(' ');
            if (parts.Length < 5)
                throw new CronFaultExpr();

            Minute = new CronMinute(Outset, parts[0]);
            Hour = new CronHour(Outset, parts[1]);
            Month = new CronMonth(Outset, parts[3]);
        }

        public DateTime Outset { get; }

        public CronHour Hour { get; }
        public CronMinute Minute { get; }
        public CronMonth Month { get; }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public DateTime Current => Outset;

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