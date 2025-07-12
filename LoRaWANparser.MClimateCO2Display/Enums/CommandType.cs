using System;

namespace LoRaWANparser.MClimateCO2Display.Enums
{
    public enum CommandType
    {
        KeepAlive,
        HardwareAndSoftwareVersion,
        KeepAlivePeriod,
        ChildLock,
        NetworkJoinRetryPeriod,
        UplinkMessages,
        RadioCommunicationWatchDog,
        CO2BoundaryLevels,
        CO2AutoZeroValue,
        CO2MeasurementPeriod,
        CO2AutoZeroPeriod,
        FullDisplayRefresh,
        PIRstatus,
        PIRsensitivity,
        MeasuredTemperature,
        MeasuredHumidity,
        MeasuredLightIntensity,
        PIRinitializationPeriod,
        PIRmeasurementPeriod,
        PIRcheckPeriod,
        PIRblindPeriod,
        CO2MeasurementBlindTime,
        CO2RelatedImages
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

                case CommandType.ChildLock:
                    return "Child lock";

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

                case CommandType.CO2MeasurementPeriod:
                    return "CO2 measurement period";

                case CommandType.CO2AutoZeroPeriod:
                    return "CO2 auto-zero period";

                case CommandType.FullDisplayRefresh:
                    return "Full display refresh";

                case CommandType.PIRstatus:
                    return "PIR status";

                case CommandType.PIRsensitivity:
                    return "PIR sensitivity";

                case CommandType.MeasuredTemperature:
                    return "Measured temperature";

                case CommandType.MeasuredHumidity:
                    return "Measured humidity";

                case CommandType.MeasuredLightIntensity:
                    return "Measured light intensity";

                case CommandType.PIRinitializationPeriod:
                    return "PIR initialization period";

                case CommandType.PIRmeasurementPeriod:
                    return "PIR measurement period";

                case CommandType.PIRcheckPeriod:
                    return "PIR check period";

                case CommandType.PIRblindPeriod:
                    return "PIR blind period";

                case CommandType.CO2MeasurementBlindTime:
                    return "CO2 measurement blind time";

                case CommandType.CO2RelatedImages:
                    return "CO2 related images";

                default:
                    return "Unknown command type";
            }
        }
    }
}