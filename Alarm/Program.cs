using System;
using static System.Console;

namespace Alarm
{
    public class Program
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

        public static void Main()
        {
            var countOfAlerts = Convert.ToInt32(ReadLine());
            var alerts = new Alert[countOfAlerts];
            for (var i = 0; i < alerts.Length; i++)
            {
                alerts[i] = ReadAlert();
            }

            var timeToCheck = ReadTime();
            var dayToCheck = GetDay(ReadLine());

            WriteLine(CheckAlarm(alerts, timeToCheck, dayToCheck));
            Read();
        }

        public static bool CheckAlarmDay(Days days, Days dayToCheck) => (days & dayToCheck) != 0;

        public static Days GetDay(string day)
        {
            switch (day)
            {
                case "Mo":
                    return Days.Mo;
                case "Tu":
                    return Days.Tu;
                case "We":
                    return Days.We;
                case "Th":
                    return Days.Th;
                case "Fr":
                    return Days.Fr;
                case "Sa":
                    return Days.Sa;
                default:
                    return Days.Su;
            }
        }

        public static void AddDayToAlert(ref Alert result, Days day) => result.Days |= day;

        static bool CheckAlarmTime(Time time, Time timeToCheck) => time.Hour == timeToCheck.Hour && time.Minutes == timeToCheck.Minutes;

        static Alert ReadAlert()
        {
            var result = new Alert { Time = ReadTime() };
            foreach (var t in ReadLine()?.Split(' '))
            {
                AddDayToAlert(ref result, GetDay(t));
            }

            return result;
        }

        static Time ReadTime()
        {
            var time = ReadLine().Split(':');
            return new Time(Convert.ToInt32(time[0]), Convert.ToInt32(time[1]));
        }

        static bool CheckAlarm(Alert[] alerts, Time timeToCheck, Days dayToCheck)
        {
            if (alerts == null)
            {
                return false;
            }

            foreach (var alert in alerts)
            {
                if (!CheckAlarmTime(alert.Time, timeToCheck))
                {
                    continue;
                }

                if (CheckAlarmDay(alert.Days, dayToCheck))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
