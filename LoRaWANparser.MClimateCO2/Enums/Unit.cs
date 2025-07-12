using System;

namespace LoRaWANparser.MClimateCO2.Enums
{
    public enum Unit
    {
        None,
        Ppm,
        CelsiusSymbol,
        Percentage,
        MiliVolt,
        Hour,
        Minute,
        Second,
        MiliSecond
    }

    public static class UnitDescriptor
    {
        public static String GetDescriptor(this Unit unit)
        {
            switch (unit)
            {
                case Unit.None:
                    return "";

                case Unit.Ppm:
                    return "ppm";

                case Unit.CelsiusSymbol:
                    return "°C";

                case Unit.Percentage:
                    return "%";

                case Unit.MiliVolt:
                    return "mV";

                case Unit.Hour:
                    return "h";

                case Unit.Minute:
                    return "min";

                case Unit.Second:
                    return "s";

                case Unit.MiliSecond:
                    return "ms";

                default:
                    return "Unknown unit";
            }
        }
    }
}