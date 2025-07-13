using System;

namespace LoRaWANparser.MClimateHT.Enums
{
    public enum ParameterType
    {
        InternalTemperature,
        RelativeHumidity,
        DeviceBatteryVoltage,
        ExternalThermistorTemperature,
        DeviceHardwareVersion,
        DeviceSoftwareVersion,
        DeviceKeepAlivePeriod,
        DeviceNetworkJoinRetryPeriod,
        DeviceUplinkMessages,
        DeviceRadioCommunicationWatchDogConfirmedUplink,
        DeviceRadioCommunicationWatchDogUnconfirmedUplink
    }

    public static class ParameterTypeDescriptor
    {
        public static String GetDescriptor(this ParameterType parameterType)
        {
            switch (parameterType)
            {
                case ParameterType.InternalTemperature:
                    return "Internal temperature";

                case ParameterType.RelativeHumidity:
                    return "Relative humidity";

                case ParameterType.DeviceBatteryVoltage:
                    return "Device battery voltage";

                case ParameterType.ExternalThermistorTemperature:
                    return "External thermistor temperature";

                case ParameterType.DeviceHardwareVersion:
                    return "Device hardware version";

                case ParameterType.DeviceSoftwareVersion:
                    return "Device software version";

                case ParameterType.DeviceKeepAlivePeriod:
                    return "Device keep-alive period";

                case ParameterType.DeviceNetworkJoinRetryPeriod:
                    return "Device network join retry period";

                case ParameterType.DeviceUplinkMessages:
                    return "Device uplink messages";

                case ParameterType.DeviceRadioCommunicationWatchDogConfirmedUplink:
                    return "Device radio communication watchdog confirmed uplink";

                case ParameterType.DeviceRadioCommunicationWatchDogUnconfirmedUplink:
                    return "Device radio communication watchdog unconfirmed uplink";

                default:
                    return "Unknown command type descriptor";
            }
        }
    }
}