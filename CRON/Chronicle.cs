using System;
using System.Collections.Generic;

namespace CRON
{
    public static class Chronicle
    {
        public static IEnumerable<DateTime> Roam(DateTime outset, string cron)
        {
            var cronos = new Chronos(outset, cron);
            while (cronos.MoveNext())
                yield return cronos.Current;
        }
    }
}
