using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class PIRsensitivity : IPartialParser
    {
        private static PIRsensitivity? instance;

        public static PIRsensitivity GetParser()
        {
            if (instance == null)
            {
                instance = new PIRsensitivity();
            }
            return instance;
        }

        private PIRsensitivity()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
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