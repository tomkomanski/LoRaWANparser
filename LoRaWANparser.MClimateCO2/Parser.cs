using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;
using LoRaWANparser.MClimateCO2.Parsers;
using LoRaWANparser.MClimateCO2.Parsers.Interfaces;
using LoRaWANparser.Tools;
using System;

namespace LoRaWANparser.MClimateCO2
{
    public class Parser : IParser
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
                    IPartialParser keepAlive = KeepAlive.GetParser();
                    ParsedData keepAliveProcessData = keepAlive.Process(bufferKeepAlive);
                    parsedData.AddParserErrorCode(keepAliveProcessData.ParserErrorCode);
                    parsedData.AddCommandType(keepAliveProcessData.CommandType);
                    parsedData.AddReading(keepAliveProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x04)
                {
                    List<Byte> bufferHardwareAndSoftware = new(buffer.DequeueChunk(3));
                    IPartialParser hardwareAndSoftware = HardwareAndSoftware.GetParser();
                    ParsedData hardwareAndSoftwareProcessData = hardwareAndSoftware.Process(bufferHardwareAndSoftware);
                    parsedData.AddParserErrorCode(hardwareAndSoftwareProcessData.ParserErrorCode);
                    parsedData.AddCommandType(hardwareAndSoftwareProcessData.CommandType);
                    parsedData.AddReading(hardwareAndSoftwareProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x12)
                {
                    List<Byte> bufferKeepAlivePeriod = new(buffer.DequeueChunk(2));
                    IPartialParser keepAlivePeriod = KeepAlivePeriod.GetParser();
                    ParsedData keepAlivePeriodProcessData = keepAlivePeriod.Process(bufferKeepAlivePeriod);
                    parsedData.AddParserErrorCode(keepAlivePeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(keepAlivePeriodProcessData.CommandType);
                    parsedData.AddReading(keepAlivePeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x19)
                {
                    List<Byte> bufferNetworkJoinRetryPeriod = new(buffer.DequeueChunk(2));
                    IPartialParser networkJoinRetryPeriod = NetworkJoinRetryPeriod.GetParser();
                    ParsedData networkJoinRetryPeriodProcessData = networkJoinRetryPeriod.Process(bufferNetworkJoinRetryPeriod);
                    parsedData.AddParserErrorCode(networkJoinRetryPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(networkJoinRetryPeriodProcessData.CommandType);
                    parsedData.AddReading(networkJoinRetryPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x1B)
                {
                    List<Byte> bufferUplinkMessages = new(buffer.DequeueChunk(2));
                    IPartialParser uplinkMessages = UplinkMessages.GetParser();
                    ParsedData uplinkMessagesProcessData = uplinkMessages.Process(bufferUplinkMessages);
                    parsedData.AddParserErrorCode(uplinkMessagesProcessData.ParserErrorCode);
                    parsedData.AddCommandType(uplinkMessagesProcessData.CommandType);
                    parsedData.AddReading(uplinkMessagesProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x1D)
                {
                    List<Byte> bufferRadioCommunicationWatchDog = new(buffer.DequeueChunk(3));
                    IPartialParser radioCommunicationWatchDog = RadioCommunicationWatchDog.GetParser();
                    ParsedData radioCommunicationWatchDogProcessData = radioCommunicationWatchDog.Process(bufferRadioCommunicationWatchDog);
                    parsedData.AddParserErrorCode(radioCommunicationWatchDogProcessData.ParserErrorCode);
                    parsedData.AddCommandType(radioCommunicationWatchDogProcessData.CommandType);
                    parsedData.AddReading(radioCommunicationWatchDogProcessData.Reading);
                }
                else if (buffer.Count() >= 5 && buffer.First() == 0x1F)
                {
                    List<Byte> bufferCO2BoundaryLevels = new(buffer.DequeueChunk(5));
                    IPartialParser co2BoundaryLevels = CO2BoundaryLevels.GetParser();
                    ParsedData co2BoundaryLevelsProcessData = co2BoundaryLevels.Process(bufferCO2BoundaryLevels);
                    parsedData.AddParserErrorCode(co2BoundaryLevelsProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2BoundaryLevelsProcessData.CommandType);
                    parsedData.AddReading(co2BoundaryLevelsProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x21)
                {
                    List<Byte> bufferCO2AutoZeroValue = new(buffer.DequeueChunk(3));
                    IPartialParser co2AutoZeroValue = CO2AutoZeroValue.GetParser();
                    ParsedData co2AutoZeroValueProcessData = co2AutoZeroValue.Process(bufferCO2AutoZeroValue);
                    parsedData.AddParserErrorCode(co2AutoZeroValueProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2AutoZeroValueProcessData.CommandType);
                    parsedData.AddReading(co2AutoZeroValueProcessData.Reading);
                }
                else if (buffer.Count() >= 4 && buffer.First() == 0x23)
                {
                    List<Byte> bufferNotifyPeriod = new(buffer.DequeueChunk(4));
                    IPartialParser notifyPeriod = NotifyPeriod.GetParser();
                    ParsedData notifyPeriodProcessData = notifyPeriod.Process(bufferNotifyPeriod);
                    parsedData.AddParserErrorCode(notifyPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(notifyPeriodProcessData.CommandType);
                    parsedData.AddReading(notifyPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 4 && buffer.First() == 0x25)
                {
                    List<Byte> bufferCO2MeasurementPeriod = new(buffer.DequeueChunk(4));
                    IPartialParser co2MeasurementPeriod = CO2MeasurementPeriod.GetParser();
                    ParsedData co2MeasurementPeriodProcessData = co2MeasurementPeriod.Process(bufferCO2MeasurementPeriod);
                    parsedData.AddParserErrorCode(co2MeasurementPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2MeasurementPeriodProcessData.CommandType);
                    parsedData.AddReading(co2MeasurementPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 10 && buffer.First() == 0x27)
                {
                    List<Byte> bufferBuzzerNotificationConfiguration = new(buffer.DequeueChunk(10));
                    IPartialParser buzzerNotificationConfiguration = BuzzerNotificationConfiguration.GetParser();
                    ParsedData buzzerNotificationConfigurationProcessData = buzzerNotificationConfiguration.Process(bufferBuzzerNotificationConfiguration);
                    parsedData.AddParserErrorCode(buzzerNotificationConfigurationProcessData.ParserErrorCode);
                    parsedData.AddCommandType(buzzerNotificationConfigurationProcessData.CommandType);
                    parsedData.AddReading(buzzerNotificationConfigurationProcessData.Reading);
                }
                else if (buffer.Count() >= 16 && buffer.First() == 0x29)
                {
                    List<Byte> bufferLedNotificationConfiguration = new(buffer.DequeueChunk(16));
                    LedNotificationConfiguration ledNotificationConfiguration = LedNotificationConfiguration.GetParser();
                    ParsedData ledNotificationConfigurationProcessData = ledNotificationConfiguration.Process(bufferLedNotificationConfiguration);
                    parsedData.AddParserErrorCode(ledNotificationConfigurationProcessData.ParserErrorCode);
                    parsedData.AddCommandType(ledNotificationConfigurationProcessData.CommandType);
                    parsedData.AddReading(ledNotificationConfigurationProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x2B)
                {
                    List<Byte> bufferCO2AutoZeroPeriod = new(buffer.DequeueChunk(2));
                    IPartialParser co2AutoZeroPeriod = CO2AutoZeroPeriod.GetParser();
                    ParsedData co2AutoZeroPeriodProcessData = co2AutoZeroPeriod.Process(bufferCO2AutoZeroPeriod);
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