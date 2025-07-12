using System;

namespace LoRaWANparser.MClimateCO2Display.Enums
{
    public enum Unit
    {
        None,
        Ppm,
        CelsiusSymbol,
        Percentage,
        MiliVolt,
        Lux,
        Hour,
        Minute,
        Second
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

                case Unit.Lux:
                    return "lx";

                case Unit.Hour:
                    return "h";

                case Unit.Minute:
                    return "min";

                case Unit.Second:
                    return "s";

                default:
                    return "Unknown unit";
            }
        }
    }
}