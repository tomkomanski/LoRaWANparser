using System;
using LoRaWANparser.ApatorInvonic2.Enums;

namespace LoRaWANparser.ApatorInvonic2.Models
{
    public class BasicWithCoolingEnergy : ParsedData
    {
        private DateTime timeStamp;
        private DeviceErrorCode deviceErrorCode;
        private Int32 energyForHeating;
        private Int32 energyForCooling;
        private Int32 volume;
        private Int32 energyForHeatingOfThePastPeriod1;
        private Int32 energyForCoolingOfThePastPeriod1;
        private Int32 volumeOfThePastPeriod1;
        private Int32 energyForHeatingOfThePastPeriod2;
        private Int32 energyForCoolingOfThePastPeriod2;
        private Int32 volumeOfThePastPeriod2;
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

        public Int32 EnergyForHeating
        {
            get
            {
                return this.energyForHeating;
            }
        }
        public Int32 EnergyForCooling
        {
            get
            {
                return this.energyForCooling;
            }
        }

        public Int32 Volume
        {
            get
            {
                return this.volume;
            }
        }

        public Int32 EnergyForHeatingOfThePastPeriod1
        {
            get
            {
                return this.energyForHeatingOfThePastPeriod1;
            }
        }

        public Int32 EnergyForCoolingOfThePastPeriod1
        {
            get
            {
                return this.energyForCoolingOfThePastPeriod1;
            }
        }

        public Int32 VolumeOfThePastPeriod1
        {
            get
            {
                return this.volumeOfThePastPeriod1;
            }
        }

        public Int32 EnergyForHeatingOfThePastPeriod2
        {
            get
            {
                return this.energyForHeatingOfThePastPeriod2;
            }
        }

        public Int32 EnergyForCoolingOfThePastPeriod2
        {
            get
            {
                return this.energyForCoolingOfThePastPeriod2;
            }
        }

        public Int32 VolumeOfThePastPeriod2
        {
            get
            {
                return this.volumeOfThePastPeriod2;
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

        public void SetEnergyForHeating(Int32 energyForHeating)
        {
            this.energyForHeating = energyForHeating;
        }

        public void SetEnergyForCooling(Int32 energyForCooling)
        {
            this.energyForCooling = energyForCooling;
        }

        public void SetVolume(Int32 volume)
        {
            this.volume = volume;
        }

        public void SetEnergyForHeatingOfThePastPeriod1(Int32 energyForHeatingOfThePastPeriod1)
        {
            this.energyForHeatingOfThePastPeriod1 = energyForHeatingOfThePastPeriod1;
        }

        public void SetEnergyForCoolingOfThePastPeriod1(Int32 energyForCoolingOfThePastPeriod1)
        {
            this.energyForCoolingOfThePastPeriod1 = energyForCoolingOfThePastPeriod1;
        }

        public void SetVolumeOfThePastPeriod1(Int32 volumeOfThePastPeriod1)
        {
            this.volumeOfThePastPeriod1 = volumeOfThePastPeriod1;
        }

        public void SetEnergyForHeatingOfThePastPeriod2(Int32 energyForHeatingOfThePastPeriod2)
        {
            this.energyForHeatingOfThePastPeriod2 = energyForHeatingOfThePastPeriod2;
        }

        public void SetEnergyForCoolingOfThePastPeriod2(Int32 energyForCoolingOfThePastPeriod2)
        {
            this.energyForCoolingOfThePastPeriod2 = energyForCoolingOfThePastPeriod2;
        }

        public void SetVolumeOfThePastPeriod2(Int32 volumeOfThePastPeriod2)
        {
            this.volumeOfThePastPeriod2 = volumeOfThePastPeriod2;
        }

        public void SetPeriodBetweenPastValues(Int32 periodBetweenPastValues)
        {
            this.periodBetweenPastValues = periodBetweenPastValues;
        }
    }
}