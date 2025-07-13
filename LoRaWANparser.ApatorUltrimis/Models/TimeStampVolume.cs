using System;

namespace LoRaWANparser.ApatorUltrimis.Models
{
    public class TimeStampVolume
    {
        private DateTime timestamp;
        private Nullable<Int32> volume;

        public DateTime Timestamp
        {
            get
            {
                return this.timestamp;
            }
            set
            {
                this.timestamp = value;
            }
        }

        public Nullable<Int32> Volume
        {
            get
            {
                return this.volume;
            }
            set
            {
                this.volume = value;
            }
        }
    }
}