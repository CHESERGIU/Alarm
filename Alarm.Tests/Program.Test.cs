using System;
using Xunit;

namespace Alarm.Tests
{
    public class ProgramTest
    {
        [Fact]
        public void AlarmSetOnlyForDayToCheckShouldTriggerAlarm()
        {
            const Days days = Days.Tu;
            const Days dayToCheck = Days.Tu;
            var actual = new Alert();
            var alarmSet = actual.CheckAlarmDay(days, dayToCheck);
            Assert.True(alarmSet);
        }

        [Fact]
        public void AlarmSetOnlyForDayDifferentThanTheOneToCheckShouldNotTriggerAlarm()
        {
            const Days days = Days.Mo;
            const Days dayToCheck = Days.Tu;
            var actual = new Alert();
            var alarmSet = actual.CheckAlarmDay(days, dayToCheck);
            Assert.False(alarmSet);
        }

        [Fact]
        public void AlarmSetForMultipleDaysCheckAlarmForOneDayToTriggerAlarm()
        {
            const Days days = Days.Tu | Days.Mo | Days.We;
            const Days dayToCheck = Days.Tu;
            var actual = new Alert();
            var alarmSet = actual.CheckAlarmDay(days, dayToCheck);
            Assert.True(alarmSet);
        }

        [Fact]
        public void AlarmSetForMultipleDaysCheckAlarmForOneDifferentThanDAysToCheckDayShouldNotToTriggerAlarm()
        {
            const Days days = Days.Su | Days.Sa | Days.Mo;
            const Days dayToCheck = Days.Tu;
            var actual = new Alert();
            var alarmSet = actual.CheckAlarmDay(days, dayToCheck);
            Assert.False(alarmSet);
        }

        [Fact]
        public void AlarmSetForMultipleDaysCheckIfAlarmIsAddedToTriggerPlan()
        {
            const Days days = Days.Su | Days.Sa | Days.Mo;
            var actual = new Alert();
            var result = actual.AddDayToAlert(ref actual, days);

            Assert.Equal(days, result);
        }
    }
}