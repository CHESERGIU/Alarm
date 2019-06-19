using System;

namespace Alarm
{
    public class Program
    {
        public static void Main()
        {
            var countOfAlerts = Convert.ToInt32(Console.ReadLine());
            var alerts = new Alert[countOfAlerts];
            var readAlert = new Alert();
            for (var i = 0; i < alerts.Length; i++)
            {
                alerts[i] = readAlert.ReadAlert();
            }

            var timeToCheck = readAlert.ReadTime();
            var dayToCheck = readAlert.GetDay(Console.ReadLine());

            Console.WriteLine(readAlert.CheckAlarm(alerts, timeToCheck, dayToCheck));
            Console.Read();
        }
    }
}
