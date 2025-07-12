using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class PIRmeasurementPeriod
    {
        public PIRmeasurementPeriod()
        {
        }

        public ParsedData PIRmeasurementPeriodProcess(IEnumerable<Byte> dataBytes)
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