using System;
using Xunit;

namespace Alarm.Tests
{
    public class ProgramTest
    {
        [Fact]
        public void AlarmSetOnlyForDayToCheckShouldTriggerAlarm()
        {
            const Program.Days days = Program.Days.Tu;
            const Program.Days dayToCheck = Program.Days.Tu;
            Assert.True(Program.CheckAlarmDay(days, dayToCheck));
        }

        [Fact]
        public void AlarmSetOnlyForDayDifferentThanTheOneToCheckShouldNotTriggerAlarm()
        {
            const Program.Days days = Program.Days.Mo;
            const Program.Days dayToCheck = Program.Days.Tu;
            Assert.False(Program.CheckAlarmDay(days, dayToCheck));
        }

        [Fact]
        public void AlarmSetForMultipleDaysCheckAlarmForOneDayToTriggerAlarm()
        {
            const Program.Days days = Program.Days.Tu | Program.Days.Mo | Program.Days.We;
            const Program.Days dayToCheck = Program.Days.Tu;
            Assert.True(Program.CheckAlarmDay(days, dayToCheck));
        }

        [Fact]
        public void AlarmSetForMultipleDaysCheckAlarmForOneDifferentThanDAysToCheckDayShouldNotToTriggerAlarm()
        {
            const Program.Days days = Program.Days.Su | Program.Days.Sa | Program.Days.Mo;
            const Program.Days dayToCheck = Program.Days.Tu;
            Assert.False(Program.CheckAlarmDay(days, dayToCheck));
        }

        [Fact]
        public void AlarmSetForMultipleDaysCheckIfAlarmISAddedToTriggerPlan()
        {
            const Program.Days days = Program.Days.Su | Program.Days.Sa | Program.Days.Mo;
            var result = new Alert();
            Program.AddDayToAlert(ref result, days);
            Assert.Equal(days, result.Days);
        }
    }
}