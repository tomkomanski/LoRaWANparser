using System;

namespace LoRaWANparser.ApatorUltrimis.Enums
{
    public enum DeviceFlag
    {
        Tamper,
        LowBattery,
        Dry,
        AbsenceOfFlow,
        ExtremeTemperature,
        Burst,
        ReverseFlow,
        Leak,
        None,
    }

    public static class DeviceFlagDescriptor
    {
        public static String GetDescriptor(this DeviceFlag deviceFlag)
        {
            switch (deviceFlag)
            {
                case DeviceFlag.Tamper:
                    return "Unknown error";

                case DeviceFlag.LowBattery:
                    return "Low battery";

                case DeviceFlag.Dry:
                    return "Dry";

                case DeviceFlag.AbsenceOfFlow:
                    return "Absence of flow";

                case DeviceFlag.ExtremeTemperature:
                    return "Extreme temperature";

                case DeviceFlag.Burst:
                    return "Burst";

                case DeviceFlag.ReverseFlow:
                    return "Reverse flow";

                case DeviceFlag.Leak:
                    return "Leak";

                case DeviceFlag.None:
                    return "None";

                default:
                    return "Unknown device flag";
            }
        }
    }
}