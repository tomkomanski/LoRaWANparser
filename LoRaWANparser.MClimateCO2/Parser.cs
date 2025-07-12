using System;
using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;
using LoRaWANparser.MClimateCO2.Parsers;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2
{
    public class Parser
    {
        public Parser()
        {
        }

        public ParsedData Process(String hexFrame)
        {
            ParsedData parsedData = new();

            if (String.IsNullOrEmpty(hexFrame))
            {
                parsedData.AddParserErrorCode(ParserErrorCode.IncorrectFrame);
                return parsedData;
            }

            Byte[] bufferBytes = hexFrame.HexStringToHexByte().ToArray();

            if (!bufferBytes.Any())
            {
                parsedData.AddParserErrorCode(ParserErrorCode.IncorrectFrame);
                return parsedData;
            }

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(bufferBytes);

            while (buffer.Count() > 1)
            {
                if (buffer.Count() >= 7 && buffer.First() == 0x01)
                {
                    List<Byte> bufferKeepAlive = new(buffer.DequeueChunk(7));
                    KeepAlive keepAlive = new();
                    ParsedData keepAliveProcessData = keepAlive.KeepAliveProcess(bufferKeepAlive);
                    parsedData.AddParserErrorCode(keepAliveProcessData.ParserErrorCode);
                    parsedData.AddCommandType(keepAliveProcessData.CommandType);
                    parsedData.AddReading(keepAliveProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x04)
                {
                    List<Byte> bufferHardwareAndSoftware = new(buffer.DequeueChunk(3));
                    HardwareAndSoftware hardwareAndSoftware = new();
                    ParsedData hardwareAndSoftwareProcessData = hardwareAndSoftware.HardwareAndSoftwareProcess(bufferHardwareAndSoftware);
                    parsedData.AddParserErrorCode(hardwareAndSoftwareProcessData.ParserErrorCode);
                    parsedData.AddCommandType(hardwareAndSoftwareProcessData.CommandType);
                    parsedData.AddReading(hardwareAndSoftwareProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x12)
                {
                    List<Byte> bufferKeepAlivePeriod = new(buffer.DequeueChunk(2));
                    KeepAlivePeriod keepAlivePeriod = new();
                    ParsedData keepAlivePeriodProcessData = keepAlivePeriod.KeepAlivePeriodProcess(bufferKeepAlivePeriod);
                    parsedData.AddParserErrorCode(keepAlivePeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(keepAlivePeriodProcessData.CommandType);
                    parsedData.AddReading(keepAlivePeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x19)
                {
                    List<Byte> bufferNetworkJoinRetryPeriod = new(buffer.DequeueChunk(2));
                    NetworkJoinRetryPeriod networkJoinRetryPeriod = new();
                    ParsedData networkJoinRetryPeriodProcessData = networkJoinRetryPeriod.NetworkJoinRetryPeriodProcess(bufferNetworkJoinRetryPeriod);
                    parsedData.AddParserErrorCode(networkJoinRetryPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(networkJoinRetryPeriodProcessData.CommandType);
                    parsedData.AddReading(networkJoinRetryPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x1B)
                {
                    List<Byte> bufferUplinkMessages = new(buffer.DequeueChunk(2));
                    UplinkMessages uplinkMessages = new();
                    ParsedData uplinkMessagesProcessData = uplinkMessages.UplinkMessagesProcess(bufferUplinkMessages);
                    parsedData.AddParserErrorCode(uplinkMessagesProcessData.ParserErrorCode);
                    parsedData.AddCommandType(uplinkMessagesProcessData.CommandType);
                    parsedData.AddReading(uplinkMessagesProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x1D)
                {
                    List<Byte> bufferRadioCommunicationWatchDog = new(buffer.DequeueChunk(3));
                    RadioCommunicationWatchDog radioCommunicationWatchDog = new();
                    ParsedData radioCommunicationWatchDogProcessData = radioCommunicationWatchDog.RadioCommunicationWatchDogProcess(bufferRadioCommunicationWatchDog);
                    parsedData.AddParserErrorCode(radioCommunicationWatchDogProcessData.ParserErrorCode);
                    parsedData.AddCommandType(radioCommunicationWatchDogProcessData.CommandType);
                    parsedData.AddReading(radioCommunicationWatchDogProcessData.Reading);
                }
                else if (buffer.Count() >= 5 && buffer.First() == 0x1F)
                {
                    List<Byte> bufferCO2BoundaryLevels = new(buffer.DequeueChunk(5));
                    CO2BoundaryLevels co2BoundaryLevels = new();
                    ParsedData co2BoundaryLevelsProcessData = co2BoundaryLevels.CO2BoundaryLevelsProcess(bufferCO2BoundaryLevels);
                    parsedData.AddParserErrorCode(co2BoundaryLevelsProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2BoundaryLevelsProcessData.CommandType);
                    parsedData.AddReading(co2BoundaryLevelsProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x21)
                {
                    List<Byte> bufferCO2AutoZeroValue = new(buffer.DequeueChunk(3));
                    CO2AutoZeroValue co2AutoZeroValue = new();
                    ParsedData co2AutoZeroValueProcessData = co2AutoZeroValue.CO2AutoZeroValueProcess(bufferCO2AutoZeroValue);
                    parsedData.AddParserErrorCode(co2AutoZeroValueProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2AutoZeroValueProcessData.CommandType);
                    parsedData.AddReading(co2AutoZeroValueProcessData.Reading);
                }
                else if (buffer.Count() >= 4 && buffer.First() == 0x23)
                {
                    List<Byte> bufferNotifyPeriod = new(buffer.DequeueChunk(4));
                    NotifyPeriod notifyPeriod = new();
                    ParsedData notifyPeriodProcessData = notifyPeriod.NotifyPeriodProcess(bufferNotifyPeriod);
                    parsedData.AddParserErrorCode(notifyPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(notifyPeriodProcessData.CommandType);
                    parsedData.AddReading(notifyPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 4 && buffer.First() == 0x25)
                {
                    List<Byte> bufferCO2MeasurementPeriod = new(buffer.DequeueChunk(4));
                    CO2MeasurementPeriod co2MeasurementPeriod = new();
                    ParsedData co2MeasurementPeriodProcessData = co2MeasurementPeriod.CO2MeasurementPeriodProcess(bufferCO2MeasurementPeriod);
                    parsedData.AddParserErrorCode(co2MeasurementPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2MeasurementPeriodProcessData.CommandType);
                    parsedData.AddReading(co2MeasurementPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 10 && buffer.First() == 0x27)
                {
                    List<Byte> bufferBuzzerNotificationConfiguration = new(buffer.DequeueChunk(10));
                    BuzzerNotificationConfiguration buzzerNotificationConfiguration = new();
                    ParsedData buzzerNotificationConfigurationProcessData = buzzerNotificationConfiguration.BuzzerNotificationConfigurationProcess(bufferBuzzerNotificationConfiguration);
                    parsedData.AddParserErrorCode(buzzerNotificationConfigurationProcessData.ParserErrorCode);
                    parsedData.AddCommandType(buzzerNotificationConfigurationProcessData.CommandType);
                    parsedData.AddReading(buzzerNotificationConfigurationProcessData.Reading);
                }
                else if (buffer.Count() >= 16 && buffer.First() == 0x29)
                {
                    List<Byte> bufferLedNotificationConfiguration = new(buffer.DequeueChunk(16));
                    LedNotificationConfiguration ledNotificationConfiguration = new();
                    ParsedData ledNotificationConfigurationProcessData = ledNotificationConfiguration.LedNotificationConfigurationProcess(bufferLedNotificationConfiguration);
                    parsedData.AddParserErrorCode(ledNotificationConfigurationProcessData.ParserErrorCode);
                    parsedData.AddCommandType(ledNotificationConfigurationProcessData.CommandType);
                    parsedData.AddReading(ledNotificationConfigurationProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x2B)
                {
                    List<Byte> bufferCO2AutoZeroPeriod = new(buffer.DequeueChunk(2));
                    CO2AutoZeroPeriod co2AutoZeroPeriod = new();
                    ParsedData co2AutoZeroPeriodProcessData = co2AutoZeroPeriod.CO2AutoZeroPeriodProcess(bufferCO2AutoZeroPeriod);
                    parsedData.AddParserErrorCode(co2AutoZeroPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2AutoZeroPeriodProcessData.CommandType);
                    parsedData.AddReading(co2AutoZeroPeriodProcessData.Reading);
                }
                else
                {
                    parsedData.AddParserErrorCode(ParserErrorCode.UnknownFrame);
                    return parsedData;
                }
            }

            return parsedData;
        }
    }
}