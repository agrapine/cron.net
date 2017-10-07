using System;
using CRON.Segments;

namespace CRON.Exceptions
{
    public class CronFaultExpr : Exception
    {
        public CronFaultExpr(CronSeg seg = CronSeg.Expr) : base($"Faulty CRON [{seg}]")
        {
        }
    }
}