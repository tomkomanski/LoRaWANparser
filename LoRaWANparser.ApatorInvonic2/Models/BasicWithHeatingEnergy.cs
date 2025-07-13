using System;
using LoRaWANparser.ApatorInvonic2.Enums;

namespace LoRaWANparser.ApatorInvonic2.Models
{
    public class BasicWithHeatingEnergy : ParsedData
    {
        private DateTime timeStamp;
        private DeviceErrorCode deviceErrorCode;
        private Int32 energy;
        private Int32 volume;
        private Int32 energyOfThePastPeriod1;
        private Int32 volumeOfThePastPeriod1;
        private Int32 energyOfThePastPeriod2;
        private Int32 volumeOfThePastPeriod2;
        private Int32 energyOfThePastPeriod3;
        private Int32 volumeOfThePastPeriod3;
        private Int32 periodBetweenPastValues;

        public DateTime TimeStamp
        {
            get
            {
                return this.timeStamp;
            }
        }

        public DeviceErrorCode ErrorCodes
        {
            get
            {
                return this.deviceErrorCode;
            }
        }

        public Int32 Energy
        {
            get
            {
                return this.energy;
            }
        }
        public Int32 Volume
        {
            get
            {
                return this.volume;
            }
        }

        public Int32 EnergyOfThePastPeriod1
        {
            get
            {
                return this.energyOfThePastPeriod1;
            }
        }

        public Int32 VolumeOfThePastPeriod1
        {
            get
            {
                return this.volumeOfThePastPeriod1;
            }
        }

        public Int32 EnergyOfThePastPeriod2
        {
            get
            {
                return this.energyOfThePastPeriod2;
            }
        }

        public Int32 VolumeOfThePastPeriod2
        {
            get
            {
                return this.volumeOfThePastPeriod2;
            }
        }

        public Int32 EnergyOfThePastPeriod3
        {
            get
            {
                return this.energyOfThePastPeriod3;
            }
        }

        public Int32 VolumeOfThePastPeriod3
        {
            get
            {
                return this.volumeOfThePastPeriod3;
            }
        }

        public Int32 PeriodBetweenPastValues
        {
            get
            {
                return this.periodBetweenPastValues;
            }
        }

        public void SetTimeStamp(DateTime timeStamp)
        {
            this.timeStamp = timeStamp;
        }

        public void SetDeviceErrorCode(DeviceErrorCode deviceErrorCode)
        {
            this.deviceErrorCode = deviceErrorCode;
        }

        public void SetEnergy(Int32 energy)
        {
            this.energy = energy;
        }

        public void SetVolume(Int32 volume)
        {
            this.volume = volume;
        }

        public void SetEnergyOfThePastPeriod1(Int32 energyOfThePastPeriod1)
        {
            this.energyOfThePastPeriod1 = energyOfThePastPeriod1;
        }

        public void SetVolumeOfThePastPeriod1(Int32 volumeOfThePastPeriod1)
        {
            this.volumeOfThePastPeriod1 = volumeOfThePastPeriod1;
        }

        public void SetEnergyOfThePastPeriod2(Int32 energyOfThePastPeriod2)
        {
            this.energyOfThePastPeriod2 = energyOfThePastPeriod2;
        }

        public void SetVolumeOfThePastPeriod2(Int32 volumeOfThePastPeriod2)
        {
            this.volumeOfThePastPeriod2 = volumeOfThePastPeriod2;
        }

        public void SetEnergyOfThePastPeriod3(Int32 energyOfThePastPeriod3)
        {
            this.energyOfThePastPeriod3 = energyOfThePastPeriod3;
        }

        public void SetVolumeOfThePastPeriod3(Int32 volumeOfThePastPeriod3)
        {
            this.volumeOfThePastPeriod3 = volumeOfThePastPeriod3;
        }

        public void SetPeriodBetweenPastValues(Int32 periodBetweenPastValues)
        {
            this.periodBetweenPastValues = periodBetweenPastValues;
        }
    }
}