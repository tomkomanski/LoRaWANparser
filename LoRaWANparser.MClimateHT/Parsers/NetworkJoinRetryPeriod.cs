using System;
using LoRaWANparser.MClimateHT.Enums;
using LoRaWANparser.MClimateHT.Models;
using LoRaWANparser.MClimateHT.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateHT.Parsers
{
    internal sealed class NetworkJoinRetryPeriod : IPartialParser
    {
        private static NetworkJoinRetryPeriod? instance;

        public static NetworkJoinRetryPeriod GetParser()
        {
            if (instance == null)
            {
                instance = new NetworkJoinRetryPeriod();
            }
            return instance;
        }

        private NetworkJoinRetryPeriod()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.NetworkJoinRetryPeriod);

            Byte deviceNetworkJoinRetryPeriod = buffer.Dequeue();

            Reading deviceNetworkJoinRetryPeriodReading = new Reading()
            {
                ParameterType = ParameterType.DeviceNetworkJoinRetryPeriod,
                ReadingValueType = ReadingValueType.Double,
                Value = Math.Round((deviceNetworkJoinRetryPeriod * 5) / (Double)60, 1),
                Unit = Unit.Minute
            };
            parsedData.AddReading(deviceNetworkJoinRetryPeriodReading);

            return parsedData;
        }
    }
}