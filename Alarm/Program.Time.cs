using System;

namespace Alarm
{
    [Flags]
    public enum Days
    {
        None = 0,
        Su = 1,
        Mo = 2,
        Tu = 4,
        We = 8,
        Th = 16,
        Fr = 32,
        Sa = 64
    }

    public class Time
    {
        private readonly int hour;
        private readonly int minutes;

        public Time()
        {
        }

        public Time(int hour, int minutes)
        {
            this.hour = hour;
            this.minutes = minutes;
        }

        public bool CheckAlarmTime(Time time, Time timeToCheck)
        {
            return timeToCheck != null && (time != null && (time.hour == timeToCheck.hour && time.minutes == timeToCheck.minutes));
        }
    }
}