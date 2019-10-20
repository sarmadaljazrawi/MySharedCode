using System;
using Xunit;

namespace MySharedCode.Common.Tests.Infrastructure.Clock
{
    public class Clock
    {
        [Fact]
        public void UnFreezed_ReturnDifferentTimeEveryCall()
        {
            var sut = GetClock();

            Assert.NotEqual(sut.Now, sut.Now);
        }

        [Fact]
        public void Freezed_ReturnSameTimeEveryCall()
        {
            var sut = GetClock();

            sut.Freeze();

            Assert.Equal(sut.Now, sut.Now);
        }

        [Fact]
        public void UnFreezedAfterFreeze_ReturnDifferentTimeEveryCall()
        {
            var sut = GetClock();

            sut.Freeze();
            Assert.Equal(sut.Now, sut.Now);
            sut.UnFreeze();
            Assert.NotEqual(sut.Now, sut.Now);
        }

        [Theory]
        [InlineData(2019, 7, 4, 14, 30, 00, 636978474000000000)]
        [InlineData(2019, 7, 5, 00, 20, 00, 636978828000000000)]
        public void CreateByDate_MatchTicks(int year, int month, int day, int hour, int minute, int second,
            long expectedTicks)
        {
            var date = new DateTime(year, month, day, hour, minute, second);
            var sut = GetClock(date.Ticks);

            Assert.Equal(expectedTicks, sut.Now.Ticks);
        }

        [Theory]
        [InlineData(2019, 7, 4, "2019-07-04")]
        [InlineData(2019, 7, 5, "2019-07-05")]
        public void Today_ReturnCurrentDate(int year, int month, int day, string expectedDate)
        {
            var date = new DateTime(year, month, day);
            var sut = GetClock(date.Ticks);

            Assert.Equal(expectedDate, sut.Today.ToShortDateString());
        }

        private Common.Infrastructure.Clock.Clock GetClock(long? ticks = null) =>
            ticks == null
                ? new Common.Infrastructure.Clock.Clock()
                : new Common.Infrastructure.Clock.Clock((long)ticks);
    }
}
