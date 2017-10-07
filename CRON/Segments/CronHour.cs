using System;
using System.Collections.Generic;
using System.Linq;

namespace CRON.Segments
{
    public class CronHour : CronSegment
    {
        public CronHour(DateTime outset, string exprSeg) : base(CronSeg.Hour, outset, exprSeg)
        {
        }

        protected override IEnumerable<int> SIndex()
        {
            return Enumerable.Range(0, 23);
        }

        protected override int QIndex()
        {
            return Outset.Hour;
        }

        protected override bool TryParseIndex(string expr, out int index)
        {
            index = 0;
            if (!int.TryParse(expr, out var value) || value < 0 || value > 23) return false;
            index = value;
            return true;
        }
    }
}