using System;

namespace LoRaWANparser.MClimateHT.Enums
{
    public enum CommandType
    {
        KeepAlive,
        HardwareAndSoftwareVersion,
        KeepAlivePeriod,
        NetworkJoinRetryPeriod,
        UplinkMessages,
        RadioCommunicationWatchDog
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

                default:
                    return "Unknown command type";
            }
        }
    }
}