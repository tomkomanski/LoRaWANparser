using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class MeasuredHumidity
    {
        public MeasuredHumidity()
        {
        }

        public ParsedData MeasuredHumidityProcess(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.MeasuredHumidity);

            Byte measuredHumidityDataBytes = buffer.Dequeue();

            String measuredHumidity = String.Empty;
            if (measuredHumidityDataBytes == 0x00)
            {
                measuredHumidity = "Hidden";
            }
            else if (measuredHumidityDataBytes == 0x01)
            {
                measuredHumidity = "Shown";
            }

            Reading measuredHumidityReading = new Reading()
            {
                ParameterType = ParameterType.DeviceMeasuredHumidity,
                ReadingValueType = ReadingValueType.String,
                ValueString = measuredHumidity,
                Unit = Unit.None
            };
            parsedData.AddReading(measuredHumidityReading);

            return parsedData;
        }
    }
}