using System;

namespace LoRaWANparser.ApatorUltrimis.Enums
{
    public enum LogType
    {
        Unknown,
        Not_supported,
        Hourly_14,
        Daily,
        Monthly
    }

    public static class LogTypeDescriptor
    {
        public static String GetDescriptor(this LogType logType)
        {
            switch (logType)
            {
                case LogType.Unknown:
                    return "Unknown";

                case LogType.Not_supported:
                    return "Not supported";

                case LogType.Hourly_14:
                    return "Hourly 14";

                case LogType.Daily:
                    return "Daily";

                case LogType.Monthly:
                    return "Monthly";

                default:
                    return "Unknown log type";
            }
        }
    }
}