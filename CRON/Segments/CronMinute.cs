using System;
using System.Collections.Generic;
using System.Linq;

namespace CRON.Segments
{
    public class CronMinute : CronSegment
    {
        public CronMinute(DateTime outset, string exprSeg) : base(CronSeg.Minute, outset, exprSeg)
        {
        }

        protected override bool TryParseIndex(string expr, out int index)
        {
            index = 0;
            if (!int.TryParse(expr, out var value) || value < 0 || value > 59) return false;
            index = value;
            return true;
        }

        protected override IEnumerable<int> SIndex()
        {
            return Enumerable.Range(0, 59);
        }

        protected override int QIndex()
        {
            return Outset.Minute;
        }
    }
}