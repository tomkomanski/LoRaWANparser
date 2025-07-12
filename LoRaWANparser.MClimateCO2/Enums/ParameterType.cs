using LoRaWANparser.MClimateCO2.Parsers;
using System;

namespace LoRaWANparser.MClimateCO2.Enums
{
    public enum ParameterType
    {
        Co2,
        InternalTemperature,
        RelativeHumidity,
        DeviceBatteryVoltage,
        DeviceKeepAlivePeriod,
        DeviceHardwareVersion,
        DeviceSoftwareVersion,
        DeviceNetworkJoinRetryPeriod,
        DeviceUplinkMessages,
        DeviceRadioCommunicationWatchDogConfirmedUplink,
        DeviceRadioCommunicationWatchDogUnconfirmedUplink,
        Co2BoundaryLevelGoodMediumZone,
        Co2BoundaryLevelMediumBadZone,
        CO2AutoZeroValue,
        NotificationPeriodGoodZone,
        NotificationPeriodMediumZone,
        NotificationPeriodBadZone,
        CO2MeasurementPeriodGoodZone,
        CO2MeasurementPeriodMediumZone,
        CO2MeasurementPeriodBadZone,
        DurationOfBuzzerBeepingGoodCO2Levels,
        DurationOfBuzzerLoudPeriodsGoodCO2Levels,
        DurationOfBuzzerSilentPeriodsGoodCO2Levels,
        DurationOfBuzzerBeepingMediumCO2Levels,
        DurationOfBuzzerLoudPeriodsMediumCO2Levels,
        DurationOfBuzzerSilentPeriodsMediumCO2Levels,
        DurationOfBuzzerBeepingBadCO2Levels,
        DurationOfBuzzerLoudPeriodsBadCO2Levels,
        DurationOfBuzzerSilentPeriodsBadCO2Levels,
        RedLedProcedureGoodCO2level,
        GreenLedProcedureGoodCO2level,
        BlueLedProcedureGoodCO2level,
        DurationLedNotificationGoodCO2level,
        RedLedProcedureMediumCO2level,
        GreenLedProcedureMediumCO2level,
        BlueLedProcedureMediumCO2level,
        DurationLedNotificationMediumCO2level,
        RedLedProcedureBadCO2level,
        GreenLedProcedureBadCO2level,
        BlueLedProcedureBadCO2level,
        DurationLedNotificationBadCO2level,
        CO2AutoZeroPeriod
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

                case ParameterType.DeviceKeepAlivePeriod:
                    return "Device keep-alive period";

                case ParameterType.DeviceHardwareVersion:
                    return "Device hardware version";

                case ParameterType.DeviceSoftwareVersion:
                    return "Device software version";

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

                case ParameterType.NotificationPeriodGoodZone:
                    return "Notification period when measured CO2 is inside the good zone";

                case ParameterType.NotificationPeriodMediumZone:
                    return "Notification period when measured CO2 is inside the medium zone";

                case ParameterType.NotificationPeriodBadZone:
                    return "Notification period when measured CO2 is inside the bad zone";

                case ParameterType.CO2MeasurementPeriodGoodZone:
                    return "Measurement period until the measured CO2 levels are inside the good zone";

                case ParameterType.CO2MeasurementPeriodMediumZone:
                    return "Measurement period until the measured CO2 levels are inside the medium zone";

                case ParameterType.CO2MeasurementPeriodBadZone:
                    return "Measurement period until the measured CO2 levels are inside the bad zone";

                case ParameterType.DurationOfBuzzerBeepingGoodCO2Levels:
                    return "Duration of the buzzer beeping for good CO2 levels";

                case ParameterType.DurationOfBuzzerLoudPeriodsGoodCO2Levels:
                    return "Duration of the buzzer loud periods for good CO2 levels";

                case ParameterType.DurationOfBuzzerSilentPeriodsGoodCO2Levels:
                    return "Duration of the buzzer silent periods for good CO2 levels";

                case ParameterType.DurationOfBuzzerBeepingMediumCO2Levels:
                    return "Duration of the buzzer beeping for medium CO2 levels";

                case ParameterType.DurationOfBuzzerLoudPeriodsMediumCO2Levels:
                    return "Duration of the buzzer loud periods for medium CO2 levels";

                case ParameterType.DurationOfBuzzerSilentPeriodsMediumCO2Levels:
                    return "Duration of the buzzer silent periods for medium CO2 levels";

                case ParameterType.DurationOfBuzzerBeepingBadCO2Levels:
                    return "Duration of the buzzer beeping for bad CO2 levels";

                case ParameterType.DurationOfBuzzerLoudPeriodsBadCO2Levels:
                    return "Duration of the buzzer loud periods for bad CO2 levels";

                case ParameterType.DurationOfBuzzerSilentPeriodsBadCO2Levels:
                    return "Duration of the buzzer silent periods for bad CO2 levels";

                case ParameterType.RedLedProcedureGoodCO2level:
                    return "Red LED procedure for good CO2 level";

                case ParameterType.GreenLedProcedureGoodCO2level:
                    return "Green LED procedure for good CO2 level";

                case ParameterType.BlueLedProcedureGoodCO2level:
                    return "Blue LED procedure for good CO2 level";

                case ParameterType.DurationLedNotificationGoodCO2level:
                    return "Duration of the LED notification for good CO2 level";

                case ParameterType.RedLedProcedureMediumCO2level:
                    return "Red LED procedure for medium CO2 level";

                case ParameterType.GreenLedProcedureMediumCO2level:
                    return "Green LED procedure for medium CO2 level";

                case ParameterType.BlueLedProcedureMediumCO2level:
                    return "Blue LED procedure for medium CO2 level";

                case ParameterType.DurationLedNotificationMediumCO2level:
                    return "Duration of the LED notification for medium CO2 level";

                case ParameterType.RedLedProcedureBadCO2level:
                    return "Red LED procedure for bad CO2 level";

                case ParameterType.GreenLedProcedureBadCO2level:
                    return "Green LED procedure for bad CO2 level";

                case ParameterType.BlueLedProcedureBadCO2level:
                    return "Blue LED procedure for bad CO2 level";

                case ParameterType.DurationLedNotificationBadCO2level:
                    return "Duration of the LED notification for bad CO2 level";

                case ParameterType.CO2AutoZeroPeriod:
                    return "CO2 auto-zero period";

                default:
                    return "Unknown command type descriptor";
            }
        }
    }
}