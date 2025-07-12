using System;
using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;
using LoRaWANparser.MClimateCO2.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2.Parsers
{
    internal sealed class CO2AutoZeroValue : IPartialParser
    {
        private static CO2AutoZeroValue? instance;

        public static CO2AutoZeroValue GetParser()
        {
            if (instance == null)
            {
                instance = new CO2AutoZeroValue();
            }
            return instance;
        }

        private CO2AutoZeroValue()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.CO2AutoZeroValue);

            Byte[] co2AutoZeroValueDataBytes = buffer.DequeueChunk(2).ToArray();
            Array.Reverse(co2AutoZeroValueDataBytes);
            UInt16 co2AutoZeroValueData = BitConverter.ToUInt16(co2AutoZeroValueDataBytes, 0);
            Double co2AutoZero = (Double)co2AutoZeroValueData;

            Reading co2AutoZeroValueReading = new Reading()
            {
                ParameterType = ParameterType.CO2AutoZeroValue,
                ReadingValueType = ReadingValueType.Double,
                Value = co2AutoZero,
                Unit = Unit.Ppm
            };
            parsedData.AddReading(co2AutoZeroValueReading);

            return parsedData;
        }
    }
}