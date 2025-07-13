using LoRaWANparser.ApatorUltrimis.Enums;
using System;

namespace LoRaWANparser.ApatorUltrimis.Extensions
{
    internal static class Extensions
    {
        public static IEnumerable<DeviceFlag> Flags2String(this Byte status)
        {
            List<DeviceFlag> flag = new();

            if ((status & 0x01) != 0)
            {
                flag.Add(DeviceFlag.Tamper);
            }

            if ((status & 0x02) != 0)
            {
                flag.Add(DeviceFlag.LowBattery);
            }

            if ((status & 0x04) != 0)
            {
                flag.Add(DeviceFlag.Dry);
            }

            if ((status & 0x08) != 0)
            {
                flag.Add(DeviceFlag.AbsenceOfFlow);
            }

            if ((status & 0x10) != 0)
            {
                flag.Add(DeviceFlag.ExtremeTemperature);
            }

            if ((status & 0x20) != 0)
            {
                flag.Add(DeviceFlag.Burst);
            }

            if ((status & 0x40) != 0)
            {
                flag.Add(DeviceFlag.ReverseFlow);
            }

            if ((status & 0x80) != 0)
            {
                flag.Add(DeviceFlag.Leak);
            }

            if (!flag.Any())
            {
                flag.Add(DeviceFlag.None);
            }

            return flag;
        }

        public static Unit GetVolumeUnits(this Byte scale)
        {
            if (scale == 0)
            {
                return Unit.Liters;
            }
            if (scale == 1)
            {
                return Unit.Decaliters;
            }
            if (scale == 2)
            {
                return Unit.Hectoliters;
            }
            if (scale == 3)
            {
                return Unit.Cubic_meters;
            }

            return Unit.Unknown;
        }
    }
}