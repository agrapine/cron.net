using System;
using System.Linq;
using CRON;
using Xunit;

namespace Crono.Test
{
    public class Timings
    {
        [Fact]
        public void Equality()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FirstOfJanYearly()
        {
            var creationDate = new DateTime(2017, 10, 6);

            //Run once a year at midnight of 1 January
            var chronos = new Chronos("0 0 1 1 *");

            var expectedValidDates = 1000000;
            var actualValidDates = chronos.Tick(creationDate)
                .TakeWhile((x, i) => x.Day == 1 && x.Month == 1 && i < expectedValidDates)
                .Count();

            Assert.Equal(actualValidDates, expectedValidDates);
        }

        public int Add(int v1, int v2) => v1 + v2;
    }
}
