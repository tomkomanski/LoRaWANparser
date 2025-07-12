using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class CO2AutoZeroValue
    {
        public CO2AutoZeroValue()
        {
        }

        public ParsedData CO2AutoZeroValueProcess(IEnumerable<Byte> dataBytes)
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