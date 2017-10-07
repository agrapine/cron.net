using System;
using System.Linq;
using CRON;
using CRON.Exceptions;
using Xunit;
using Xunit.Sdk;

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
        [InlineData(10, "0 0 1 1 *")]
        [InlineData(1000, "0 0 1 1 *")]
        [InlineData(9998, "0 0 1 1 *")]
        public void FirstOfJanYearly(int expected, string cron)
        {
            var date = new DateTime(1985, 9, 30);

            var actual = Chronicle.Roam(date, cron)
                .TakeWhile((x, i) => x.Day == 1 && x.Month == 1 && i < expected)
                .Count();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2017-10-06", "* * * * *")]
        [InlineData("2017-10-06", "0 * * * *")]
        [InlineData("2017-10-06", "1-5 * * * *")]
        [InlineData("2017-10-06", "0,5 * * * *")]
        [InlineData("2017-10-06", "1,5,30-35 * * * *")]
        [InlineData("2017-10-06", "0 0-23 * * *")]
        [InlineData("2017-10-06", "0 0 * 2,SEP-DEC *")]
        [InlineData("2017-10-06", "? * * * *")]
        public void Lexer(string date, string cron)
        {
            var target = DateTime.Parse(date);
            var chronos = new Chronos(target, cron);
            Assert.Equal(true, true);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("* * * *")]
        [InlineData("-1 * * * *")]
        [InlineData("60 * * * *")]
        [InlineData("5-1 * * * *")]
        [InlineData("* 24 * * *")]
        [InlineData("* -1 * * *")]
        public void FaultyExpr(string cron)
        {
            Assert.Throws<CronFaultExpr>(() => new Chronos(DateTime.Now, cron));
        }

        public int Add(int v1, int v2) => v1 + v2;
    }
}
