using System;

namespace LoRaWANparser.MClimateCO2.Enums
{
    public enum CommandType
    {
        KeepAlive,
        HardwareAndSoftwareVersion,
        KeepAlivePeriod,
        NetworkJoinRetryPeriod,
        UplinkMessages,
        RadioCommunicationWatchDog,
        CO2BoundaryLevels,
        CO2AutoZeroValue,
        NotifyPeriod,
        CO2MeasurementPeriod,
        BuzzerNotificationConfiguration,
        LedNotificationConfiguration,
        CO2AutoZeroPeriod,
    }

    public static class CommandTypeDescriptor
    {
        public static String GetDescriptor(this CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.KeepAlive:
                    return "Keep-alive";

                case CommandType.HardwareAndSoftwareVersion:
                    return "Hardware and software version";

                case CommandType.KeepAlivePeriod:
                    return "Keep-alive period";

                case CommandType.NetworkJoinRetryPeriod:
                    return "Network join retry period";

                case CommandType.UplinkMessages:
                    return "Uplink messages";

                case CommandType.RadioCommunicationWatchDog:
                    return "Radio communication watchdog";

                case CommandType.CO2BoundaryLevels:
                    return "CO2 boundary levels";

                case CommandType.CO2AutoZeroValue:
                    return "CO2 auto-zero value";

                case CommandType.NotifyPeriod:
                    return "Notify period";

                case CommandType.CO2MeasurementPeriod:
                    return "CO2 measurement period";

                case CommandType.BuzzerNotificationConfiguration:
                    return "Buzzer notification configuration";

                case CommandType.LedNotificationConfiguration:
                    return "LED notification configuration";

                case CommandType.CO2AutoZeroPeriod:
                    return "CO2 auto-zero period";

                default:
                    return "Unknown command type";
            }
        }
    }
}