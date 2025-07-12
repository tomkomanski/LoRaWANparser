using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class PIRsensitivity
    {
        public PIRsensitivity()
        {
        }

        public ParsedData PIRsensitivityProcess(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.PIRsensitivity);

            Byte pirSensitivityDataBytes = buffer.Dequeue();
            Reading pirSensorSensitivityDataBytesReading = new Reading()
            {
                ParameterType = ParameterType.DevicePIRsensorSensitivity,
                ReadingValueType = ReadingValueType.Double,
                Value = pirSensitivityDataBytes,
                Unit = Unit.None
            };
            parsedData.AddReading(pirSensorSensitivityDataBytesReading);

            return parsedData;
        }
    }
}