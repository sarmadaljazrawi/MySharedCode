using System;

namespace MySharedCode.Common.Infrastructure.Clock
{
    public interface IClock
    {
        IClock Freeze();
        DateTime Now { get; }
        DateTime Today { get; }
        IClock UnFreeze();
    }

    public class Clock : IClock
    {
        private long _ticks = DateTime.MinValue.Ticks;

        public Clock()
        {

        }

        public Clock(long ticks)
        {
            _ticks = ticks;
        }

        public IClock Freeze()
        {
            _ticks = DateTime.Now.Ticks;

            return this;
        }

        public DateTime Now => GetDateTime();

        public DateTime Today => GetDateTime().Date;

        public IClock UnFreeze()
        {
            _ticks = DateTime.MinValue.Ticks;

            return this;
        }

        private DateTime GetDateTime()
        {
            return _ticks == DateTime.MinValue.Ticks ? DateTime.Now : new DateTime(_ticks);
        }

    }
}
