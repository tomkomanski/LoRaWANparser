using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class PIRinitializationPeriod : IPartialParser
    {
        private static PIRinitializationPeriod? instance;

        public static PIRinitializationPeriod GetParser()
        {
            if (instance == null)
            {
                instance = new PIRinitializationPeriod();
            }
            return instance;
        }

        private PIRinitializationPeriod()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.PIRinitializationPeriod);

            Byte pirInitializationPeriodDataBytes = buffer.Dequeue();
            Reading pirInitializationPeriodDataBytesReading = new Reading()
            {
                ParameterType = ParameterType.DevicePIRsensorInitializationPeriod,
                ReadingValueType = ReadingValueType.Double,
                Value = pirInitializationPeriodDataBytes,
                Unit = Unit.Second
            };
            parsedData.AddReading(pirInitializationPeriodDataBytesReading);

            return parsedData;
        }
    }
}