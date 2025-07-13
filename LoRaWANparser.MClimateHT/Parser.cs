using System;
using LoRaWANparser.MClimateHT.Enums;
using LoRaWANparser.MClimateHT.Models;
using LoRaWANparser.MClimateHT.Parsers;
using LoRaWANparser.MClimateHT.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateHT
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