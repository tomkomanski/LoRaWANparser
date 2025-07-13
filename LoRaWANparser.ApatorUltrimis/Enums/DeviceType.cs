using System;

namespace LoRaWANparser.ApatorUltrimis.Enums
{
    public enum DeviceType
    {
        Unknown,
        Ultrimis
    }

    public static class DeviceTypeDescriptor
    {
        public static String GetDescriptor(this DeviceType deviceType)
        {
            switch (deviceType)
            {
                case DeviceType.Unknown:
                    return "Unknown";

                case DeviceType.Ultrimis:
                    return "Ultrimis";

                default:
                    return "Unknown device type";
            }
        }
    }
}