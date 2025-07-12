using System;

namespace LoRaWANparser.MClimateCO2Display.Enums
{
    public enum ParameterType
    {
        Co2,
        InternalTemperature,
        RelativeHumidity,
        DeviceBatteryVoltage,
        PowerSource,
        DeviceLightIntensity,
        PIRsensor,
        DeviceHardwareVersion,
        DeviceSoftwareVersion,
        DeviceKeepAlivePeriod,
        DeviceChildLock,
        DeviceNetworkJoinRetryPeriod,
        DeviceUplinkMessages,
        DeviceRadioCommunicationWatchDogConfirmedUplink,
        DeviceRadioCommunicationWatchDogUnconfirmedUplink,
        Co2BoundaryLevelGoodMediumZone,
        Co2BoundaryLevelMediumBadZone,
        CO2AutoZeroValue,
        CO2MeasurementPeriodGoodZone,
        CO2MeasurementPeriodMediumZone,
        CO2MeasurementPeriodBadZone,
        CO2AutoZeroPeriod,
        DisplayRefreshPeriod,
        DevicePIRsensorStatus,
        DevicePIRsensorSensitivity,
        DeviceMeasuredTemperature,
        DeviceMeasuredHumidity,
        DeviceMeasuredLightIntensity,
        DevicePIRsensorInitializationPeriod,
        DevicePIRsensorMeasurementPeriod,
        DevicePIRsensorCheckPeriod,
        DevicePIRsensorBlindPeriod,
        CO2MeasurementBlindTime,
        CO2ChartOnDisplay,
        CO2DigitalValueOnDisplay,
        CO2EmojiOnDisplay
    }

    public static class ParameterTypeDescriptor
    {
        public static String GetDescriptor(this ParameterType parameterType)
        {
            switch (parameterType)
            {
                case ParameterType.Co2:
                    return "CO2";

                case ParameterType.InternalTemperature:
                    return "Internal temperature";

                case ParameterType.RelativeHumidity:
                    return "Relative humidity";

                case ParameterType.DeviceBatteryVoltage:
                    return "Device battery voltage";

                case ParameterType.PowerSource:
                    return "Power source";

                case ParameterType.DeviceLightIntensity:
                    return "Device light intensity";

                case ParameterType.PIRsensor:
                    return "PIR sensor";

                case ParameterType.DeviceHardwareVersion:
                    return "Device hardware version";

                case ParameterType.DeviceSoftwareVersion:
                    return "Device software version";

                case ParameterType.DeviceKeepAlivePeriod:
                    return "Device keep-alive period";

                case ParameterType.DeviceChildLock:
                    return "Device child-lock";

                case ParameterType.DeviceNetworkJoinRetryPeriod:
                    return "Device network join retry period";

                case ParameterType.DeviceUplinkMessages:
                    return "Device uplink messages";

                case ParameterType.DeviceRadioCommunicationWatchDogConfirmedUplink:
                    return "Device radio communication watchdog confirmed uplink";

                case ParameterType.DeviceRadioCommunicationWatchDogUnconfirmedUplink:
                    return "Device radio communication watchdog unconfirmed uplink";

                case ParameterType.Co2BoundaryLevelGoodMediumZone:
                    return "CO2 boundary level good-medium zone";

                case ParameterType.Co2BoundaryLevelMediumBadZone:
                    return "CO2 boundary level medium-bad zone";

                case ParameterType.CO2AutoZeroValue:
                    return "CO2 auto-zero value";

                case ParameterType.CO2MeasurementPeriodGoodZone:
                    return "Measurement period until the measured CO2 levels are inside the good zone";

                case ParameterType.CO2MeasurementPeriodMediumZone:
                    return "Measurement period until the measured CO2 levels are inside the medium zone";

                case ParameterType.CO2MeasurementPeriodBadZone:
                    return "Measurement period until the measured CO2 levels are inside the bad zone";

                case ParameterType.CO2AutoZeroPeriod:
                    return "CO2 auto-zero period";

                case ParameterType.DisplayRefreshPeriod:
                    return "Display refresh period";

                case ParameterType.DevicePIRsensorStatus:
                    return "Device PIR sensor status";

                case ParameterType.DevicePIRsensorSensitivity:
                    return "Device PIR sensor sensitivity";

                case ParameterType.DeviceMeasuredTemperature:
                    return "Device measured temperature";

                case ParameterType.DeviceMeasuredHumidity:
                    return "Device measured humidity";

                case ParameterType.DeviceMeasuredLightIntensity:
                    return "Device measured light intensity";

                case ParameterType.DevicePIRsensorInitializationPeriod:
                    return "Device PIR sensor initialization period";

                case ParameterType.DevicePIRsensorMeasurementPeriod:
                    return "Device PIR sensor measurement period";

                case ParameterType.DevicePIRsensorCheckPeriod:
                    return "Device PIR sensor check period";

                case ParameterType.DevicePIRsensorBlindPeriod:
                    return "Device PIR sensor blind period";

                case ParameterType.CO2MeasurementBlindTime:
                    return "CO2 measurement blind time";

                case ParameterType.CO2ChartOnDisplay:
                    return "CO2 chart on display";

                case ParameterType.CO2DigitalValueOnDisplay:
                    return "CO2 digital value on display";

                case ParameterType.CO2EmojiOnDisplay:
                    return "CO2 emoji on display";

                default:
                    return "Unknown parameter type";
            }
        }
    }
}