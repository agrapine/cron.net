using System;
using System.Collections.Generic;
using System.Linq;

namespace CRON.Segments
{
    public class CronMonth : CronSegment
    {
        public readonly string[] ShortMonths = 
        {
            "JAN","FEB","MAR",
            "APR","MAY","JUN",
            "JUL","AUG","SEP",
            "OCT","NOV","DEC"
        };

        public readonly string[] ShortWeeks =
        {
            "SUN", "MON", "TUE",
            "WED", "THU", "FRI",
            "SAT"
        };

        protected override bool TryParseIndex(string expr, out int index)
        {
            index = 0;
            if (int.TryParse(expr, out var value) && value > 0 && value < 13)
            {
                index = value;
                return true;
            }
            index = Array.IndexOf(ShortMonths, expr.ToUpper()) + 1;
            return index > 0;
        }

        protected override IEnumerable<int> SIndex()
        {
            return Enumerable.Range(1, 12);
        }

        protected override int QIndex()
        {
            return Outset.Month;
        }

        public CronMonth(DateTime outset, string exprSeg) : base(CronSeg.Month, outset, exprSeg)
        {
        }
    }
}