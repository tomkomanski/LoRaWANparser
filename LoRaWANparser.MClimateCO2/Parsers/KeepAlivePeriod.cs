using System;
using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2.Parsers
{
    internal sealed class KeepAlivePeriod
    {
        public KeepAlivePeriod()
        {
        }

        public ParsedData KeepAlivePeriodProcess(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.KeepAlivePeriod);

            Byte deviceKeepAlivePeriod = buffer.Dequeue();

            Reading deviceKeepAlivePeriodReading = new Reading()
            {
                ParameterType = ParameterType.DeviceKeepAlivePeriod,
                ReadingValueType = ReadingValueType.Double,
                Value = deviceKeepAlivePeriod,
                Unit = Unit.Minute
            };
            parsedData.AddReading(deviceKeepAlivePeriodReading);

            return parsedData;
        }
    }
}