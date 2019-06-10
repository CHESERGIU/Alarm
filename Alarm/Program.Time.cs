namespace Alarm
{
    public class Time
    {
        public Time(int hour, int minutes)
        {
            Hour = hour;
            Minutes = minutes;
        }

        public int Hour { get; }

        public int Minutes { get; }
    }
}