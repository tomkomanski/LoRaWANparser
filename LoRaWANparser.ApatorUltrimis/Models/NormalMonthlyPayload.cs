using System;
using LoRaWANparser.ApatorUltrimis.Enums;

namespace LoRaWANparser.ApatorUltrimis.Models
{
    public class NormalMonthlyPayload : Payload
    {
        private List<DeviceFlag> flagsCurrent = new();
        private List<DeviceFlag> flagsCurrentDay = new();
        private List<DeviceFlag> flagsCurrentMonth = new();
        private DateTime timeStamp;
        private String meterSn = String.Empty;
        private TimeStampVolume monthlyReverseVolume = new();
        private TimeStampVolume monthlyVolume = new();

        public IEnumerable<DeviceFlag> FlagsCurrent
        {
            get
            {
                return flagsCurrent;
            }
        }

        public IEnumerable<DeviceFlag> FlagsCurrentDay
        {
            get
            {
                return flagsCurrentDay;
            }
        }

        public IEnumerable<DeviceFlag> FlagsCurrentMonth
        {
            get
            {
                return flagsCurrentMonth;
            }
        }

        public DateTime TimeStamp
        {
            get
            {
                return timeStamp;
            }
        }

        public String MeterSn
        {
            get
            {
                return meterSn;
            }
        }

        public TimeStampVolume MonthlyReverseVolume
        {
            get
            {
                return monthlyReverseVolume;
            }
        }

        public TimeStampVolume MonthlyVolume
        {
            get
            {
                return monthlyVolume;
            }
        }

        public void SetFlagsCurrent(IEnumerable<DeviceFlag> flagsCurrent)
        {
            this.flagsCurrent.Clear();
            this.flagsCurrent.AddRange(flagsCurrent);
        }

        public void SetFlagsCurrentDay(IEnumerable<DeviceFlag> flagsCurrentDay)
        {
            this.flagsCurrentDay.Clear();
            this.flagsCurrentDay.AddRange(flagsCurrentDay);
        }

        public void SetFlagsCurrentMonth(IEnumerable<DeviceFlag> flagsCurrentMonth)
        {
            this.flagsCurrentMonth.Clear();
            this.flagsCurrentMonth.AddRange(flagsCurrentMonth);
        }

        public void SetTimeStamp(DateTime timeStamp)
        {
            this.timeStamp = timeStamp;
        }

        public void SetMeterSN(String meterSN)
        {
            meterSn = meterSN;
        }

        public void SetMonthlyReverseVolume(TimeStampVolume monthlyReverseVolume)
        {
            this.monthlyReverseVolume = monthlyReverseVolume;
        }

        public void SetMonthlyVolume(TimeStampVolume monthlyVolume)
        {
            this.monthlyVolume = monthlyVolume;
        }
    }
}