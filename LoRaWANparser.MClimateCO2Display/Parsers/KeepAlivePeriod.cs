using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class KeepAlivePeriod : IPartialParser
    {
        private static KeepAlivePeriod? instance;

        public static KeepAlivePeriod GetParser()
        {
            if (instance == null)
            {
                instance = new KeepAlivePeriod();
            }
            return instance;
        }

        private KeepAlivePeriod()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
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