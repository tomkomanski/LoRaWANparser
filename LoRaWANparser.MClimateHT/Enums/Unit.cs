using System;

namespace LoRaWANparser.MClimateHT.Enums
{
    public enum Unit
    {
        None,
        CelsiusSymbol,
        Percentage,
        MiliVolt,
        Minute
    }

    public static class UnitDescriptor
    {
        public static String GetDescriptor(this Unit unit)
        {
            switch (unit)
            {
                case Unit.None:
                    return "";

                case Unit.CelsiusSymbol:
                    return "°C";

                case Unit.Percentage:
                    return "%";

                case Unit.MiliVolt:
                    return "mV";

                case Unit.Minute:
                    return "min";

                default:
                    return "Unknown unit";
            }
        }
    }
}