using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class PIRmeasurementPeriod : IPartialParser
    {
        private static PIRmeasurementPeriod? instance;

        public static PIRmeasurementPeriod GetParser()
        {
            if (instance == null)
            {
                instance = new PIRmeasurementPeriod();
            }
            return instance;
        }

        private PIRmeasurementPeriod()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.PIRmeasurementPeriod);

            Byte pirMeasurementPeriodDataBytes = buffer.Dequeue();
            Reading pirMeasurementPeriodDataBytesReading = new Reading()
            {
                ParameterType = ParameterType.DevicePIRsensorMeasurementPeriod,
                ReadingValueType = ReadingValueType.Double,
                Value = pirMeasurementPeriodDataBytes,
                Unit = Unit.Second
            };
            parsedData.AddReading(pirMeasurementPeriodDataBytesReading);

            return parsedData;
        }
    }
}