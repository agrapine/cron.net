using System;
using System.Collections.Generic;
using System.Linq;
using CRON.Exceptions;

namespace CRON.Segments
{
    public abstract class CronSegment
    {
        protected CronSegment(CronSeg segment, DateTime outset, string exprSeg)
        {
            Segment = segment;
            Outset = outset;
            Indexes.AddRange(Parse(exprSeg).OrderBy(x => x));
        }

        protected DateTime Outset { get; }
        protected List<int> Indexes { get; } = new List<int>();

        protected CronSeg Segment { get; }

        protected IEnumerable<int> Parse(string seg)
        {
            if (string.IsNullOrEmpty(seg))
                throw new CronFaultExpr(Segment);

            var values = seg.Split(',');
            foreach (var value in values)
            {
                var range = value.Split('-');
                if (range.Length == 2)
                    if (TryParseIndex(range[0], out var from)
                        && TryParseIndex(range[1], out var to)
                        && from <= to)
                        for (var m = from; m <= to; m++)
                            yield return m;
                    else
                        throw new CronFaultExpr(Segment);
                else
                    switch (value)
                    {
                        case "*": //all
                        {
                            foreach (var i in SIndex())
                                yield return i;
                        }
                            break;
                        case "?": //inherit
                        {
                            yield return QIndex();
                        }
                            break;
                        default: //value
                        {
                            if (TryParseIndex(value, out var i))
                                yield return i;
                            else
                                throw new CronFaultExpr(Segment);
                        }
                            break;
                    }
            }
        }

        /// <summary>
        /// Validates part
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public abstract bool Holds(DateTime current);

        /// <summary>
        ///     Parse index
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        protected abstract bool TryParseIndex(string expr, out int index);

        /// <summary>
        ///     Full range of indexes
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<int> SIndex();

        /// <summary>
        ///     Index from [Outset]
        /// </summary>
        /// <returns></returns>
        protected abstract int QIndex();
    }
}
