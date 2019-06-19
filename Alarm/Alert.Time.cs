using System;

namespace Alarm
{
    public class Alert
    {
        private Time time;
        private Days days;

        public Alert(Time time, Days days)
        {
            this.time = time;
            this.days = days;
        }

        public Alert()
        {
        }

        public Alert ReadAlert()
        {
            var readAlert = new Alert { time = ReadTime() };
            foreach (var t in Console.ReadLine()?.Split(' '))
            {
                AddDayToAlert(ref readAlert, GetDay(t));
            }

            return readAlert;
        }

        public Time ReadTime()
        {
            var timeRead = Console.ReadLine().Split(':');
            return new Time(Convert.ToInt32(timeRead[0]), Convert.ToInt32(timeRead[1]));
        }

        public bool CheckAlarm(Alert[] alerts, Time timeToCheck, Days dayToCheck)
        {
            if (alerts == null)
            {
                return false;
            }

            foreach (var alert in alerts)
            {
                var check = new Time();
                if (!check.CheckAlarmTime(alert.time, timeToCheck))
                {
                    continue;
                }

                if (CheckAlarmDay(alert.days, dayToCheck))
                {
                    return true;
                }
            }

            return false;
        }

        public Days GetDay(string day)
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

        public bool CheckAlarmDay(Days daysWithAlarm, Days dayToCheck)
        {
            return (daysWithAlarm & dayToCheck) != 0;
        }

        public Days AddDayToAlert(ref Alert result, Days day)
        {
            if (result == null)
            {
                return days;
            }

            result.days |= day;

            return result.days;
        }
    }
}