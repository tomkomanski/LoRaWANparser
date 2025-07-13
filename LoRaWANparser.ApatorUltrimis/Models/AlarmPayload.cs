using System;
using LoRaWANparser.ApatorUltrimis.Enums;

namespace LoRaWANparser.ApatorUltrimis.Models
{
    public class AlarmPayload : Payload
    {
        private readonly List<DeviceFlag> flagsCurrent = new();
        private readonly List<DeviceFlag> flagsCurrentDay = new();
        private readonly List<DeviceFlag> flagsCurrentMonth = new();
        private DateTime timeStamp;
        private String meterSn = String.Empty;

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
    }
}