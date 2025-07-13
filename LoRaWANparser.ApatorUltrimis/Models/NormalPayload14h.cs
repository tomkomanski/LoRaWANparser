using System;
using LoRaWANparser.ApatorUltrimis.Enums;

namespace LoRaWANparser.ApatorUltrimis.Models
{
    public class NormalPayload14h : Payload
    {
        private List<DeviceFlag> flagsCurrent = new();
        private List<DeviceFlag> flagsCurrentDay = new();
        private List<DeviceFlag> flagsCurrentMonth = new();
        private DateTime timeStamp;
        private String meterSn = String.Empty;
        private TimeStampVolume reverseVolume;
        private List<TimeStampVolume> volume = new();

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

        public TimeStampVolume ReverseVolume
        {
            get
            {
                return reverseVolume;
            }
        }

        public IEnumerable<TimeStampVolume> Volume
        {
            get
            {
                return volume;
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

        public void SetReverseVolume(TimeStampVolume reverseVolume)
        {
            this.reverseVolume = reverseVolume;
        }

        public void SetVolume(IEnumerable<TimeStampVolume> volume)
        {
            this.volume.Clear();
            this.volume.AddRange(volume);
        }
    }
}