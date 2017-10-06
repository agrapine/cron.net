using System;
using System.Collections.Generic;

namespace CRON
{
    public class Cronos
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="expression">CRON Expression</param>
        public Cronos(string expression)
        {
        }

        /// <summary>
        /// Start yielding from
        /// </summary>
        /// <param name="firstTarget"></param>
        /// <returns></returns>
        public IEnumerable<DateTime> Tick(DateTime firstTarget)
        {
            throw new NotImplementedException();
        }
    }
}
