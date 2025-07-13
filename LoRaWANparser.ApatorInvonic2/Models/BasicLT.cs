using System;
using LoRaWANparser.ApatorInvonic2.Enums;

namespace LoRaWANparser.ApatorInvonic2.Models
{
    public class BasicLT : ParsedData
    {
        private DateTime timeStamp;
        private DeviceErrorCode deviceErrorCode;
        private Int32 energyForHeatingOfThePastPeriod;
        private Int32 energyForCoolingOfThePastPeriod;
        private Int32 volumeOfThePastPeriod;
        private Int32 powerOfThePastPeriod;
        private Int32 flowOfThePastPeriod;
        private Int32 temperature1OfThePastPeriod;
        private Int32 temperature2OfThePastPeriod;
        private Int32 workingTimeWithoutError;
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

        public Int32 EnergyForHeatingOfThePastPeriod
        {
            get
            {
                return this.energyForHeatingOfThePastPeriod;
            }
        }
        public Int32 EnergyForCoolingOfThePastPeriod
        {
            get
            {
                return this.energyForCoolingOfThePastPeriod;
            }
        }

        public Int32 VolumeOfThePastPeriod
        {
            get
            {
                return this.volumeOfThePastPeriod;
            }
        }

        public Int32 PowerOfThePastPeriod
        {
            get
            {
                return this.powerOfThePastPeriod;
            }
        }

        public Int32 FlowOfThePastPeriod
        {
            get
            {
                return this.flowOfThePastPeriod;
            }
        }

        public Int32 Temperature1OfThePastPeriod
        {
            get
            {
                return this.temperature1OfThePastPeriod;
            }
        }

        public Int32 Temperature2OfThePastPeriod
        {
            get
            {
                return this.temperature2OfThePastPeriod;
            }
        }

        public Int32 WorkingTimeWithoutError
        {
            get
            {
                return this.workingTimeWithoutError;
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

        public void SetEnergyForHeatingOfThePastPeriod(Int32 energyForHeatingOfThePastPeriod)
        {
            this.energyForHeatingOfThePastPeriod = energyForHeatingOfThePastPeriod;
        }

        public void SetEnergyForCoolingOfThePastPeriod(Int32 energyForCoolingOfThePastPeriod)
        {
            this.energyForCoolingOfThePastPeriod = energyForCoolingOfThePastPeriod;
        }

        public void SetVolumeOfThePastPeriod(Int32 volumeOfThePastPeriod)
        {
            this.volumeOfThePastPeriod = volumeOfThePastPeriod;
        }

        public void SetPowerOfThePastPeriod(Int32 powerOfThePastPeriod)
        {
            this.powerOfThePastPeriod = powerOfThePastPeriod;
        }

        public void SetFlowOfThePastPeriod(Int32 flowOfThePastPeriod)
        {
            this.flowOfThePastPeriod = flowOfThePastPeriod;
        }

        public void SetTemperature1OfThePastPeriod(Int32 temperature1OfThePastPeriod)
        {
            this.temperature1OfThePastPeriod = temperature1OfThePastPeriod;
        }

        public void SetTemperature2OfThePastPeriod(Int32 temperature2OfThePastPeriod)
        {
            this.temperature2OfThePastPeriod = temperature2OfThePastPeriod;
        }

        public void SetWorkingTimeWithoutError(Int32 workingTimeWithoutError)
        {
            this.workingTimeWithoutError = workingTimeWithoutError;
        }

        public void SetPeriodBetweenPastValues(Int32 periodBetweenPastValues)
        {
            this.periodBetweenPastValues = periodBetweenPastValues;
        }
    }
}
