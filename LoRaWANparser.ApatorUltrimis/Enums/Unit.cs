using System;

namespace LoRaWANparser.ApatorUltrimis.Enums
{
    public enum Unit
    {
        Unknown,
        Liters,
        Decaliters,
        Hectoliters,
        Cubic_meters
    }

    public static class UnitDescriptor
    {
        public static String GetDescriptor(this Unit unit)
        {
            switch (unit)
            {
                case Unit.Unknown:
                    return "Unknown";

                case Unit.Liters:
                    return "Liters";

                case Unit.Decaliters:
                    return "Decaliters";

                case Unit.Hectoliters:
                    return "Hectoliters";

                case Unit.Cubic_meters:
                    return "Cubic meters";

                default:
                    return "Unknown unit";
            }
        }
    }
}