using System;
using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2.Parsers
{
    internal sealed class NetworkJoinRetryPeriod
    {
        public NetworkJoinRetryPeriod()
        {
        }

        public ParsedData NetworkJoinRetryPeriodProcess(IEnumerable<Byte> dataBytes)
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