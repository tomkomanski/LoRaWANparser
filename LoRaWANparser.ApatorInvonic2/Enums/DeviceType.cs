using System;

namespace LoRaWANparser.ApatorInvonic2.Enums
{
    public enum DeviceType
    {
        Unknown,
        BasicLT,
        BasicWithCoolingEnergy,
        BasicWithHeatingEnergy,
        Nordic,
        NordicWithCoolingEnergy,
    }

    public static class DeviceTypeDescriptor
    {
        public static String GetDescriptor(this DeviceType deviceType)
        {
            switch (deviceType)
            {
                case DeviceType.Unknown:
                    return "Unknown";

                case DeviceType.BasicLT:
                    return "Basic LT";

                case DeviceType.BasicWithCoolingEnergy:
                    return "Basic with cooling energy";

                case DeviceType.BasicWithHeatingEnergy:
                    return "Basic with heating energy";

                case DeviceType.Nordic:
                    return "Nordic";

                case DeviceType.NordicWithCoolingEnergy:
                    return "Nordic with cooling energy";

                default:
                    return "Unknown device type code";
            }
        }
    }
}