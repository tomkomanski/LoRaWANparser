using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class MeasuredTemperature
    {
        public MeasuredTemperature()
        {
        }

        public ParsedData MeasuredTemperatureProcess(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.MeasuredTemperature);

            Byte measuredTemperatureDataBytes = buffer.Dequeue();

            String measuredTemperature = String.Empty;
            if (measuredTemperatureDataBytes == 0x00)
            {
                measuredTemperature = "Hidden";
            }
            else if (measuredTemperatureDataBytes == 0x01)
            {
                measuredTemperature = "Shown";
            }

            Reading measuredTemperatureReading = new Reading()
            {
                ParameterType = ParameterType.DeviceMeasuredTemperature,
                ReadingValueType = ReadingValueType.String,
                ValueString = measuredTemperature,
                Unit = Unit.None
            };
            parsedData.AddReading(measuredTemperatureReading);

            return parsedData;
        }
    }
}