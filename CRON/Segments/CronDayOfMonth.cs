using System;
using System.Collections.Generic;
using System.Linq;

namespace CRON.Segments
{
    //TODO implement ordinals and workdays
    public class CronDayOfMonth : CronSegment
    {
        public CronDayOfMonth(DateTime outset, string exprSeg) : base(CronSeg.Month, outset, exprSeg)
        {
        }

        public override bool Holds(DateTime current)
        {
            return Indexes.Contains(current.Day);
        }

        protected override bool TryParseIndex(string expr, out int index)
        {
            index = 0;
            if (!int.TryParse(expr, out var value) || value < 1 || value > 31) return false;
            index = value;
            return true;
        }

        protected override IEnumerable<int> SIndex()
        {
            return Enumerable.Range(1, 31);
        }

        protected override int QIndex()
        {
            return Outset.Day;
        }
    }
}
