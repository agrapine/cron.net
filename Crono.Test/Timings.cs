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

        [Theory]
        [InlineData(10)]
        [InlineData(1000)]
        [InlineData(10000)]
        public void FirstOfJanYearly(int years)
        {
            var creationDate = new DateTime(1985, 9, 30);

            //Run once a year at midnight of 1 January
            var chronos = new Chronos("0 0 1 1 *");

            var validYears = chronos.Tick(creationDate)
                .TakeWhile((x, i) => x.Day == 1 && x.Month == 1 && i < years)
                .Count();

            Assert.Equal(validYears, years);
        }

        public int Add(int v1, int v2) => v1 + v2;
    }
}
