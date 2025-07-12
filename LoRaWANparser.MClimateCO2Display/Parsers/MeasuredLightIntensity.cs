using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class MeasuredLightIntensity
    {
        public MeasuredLightIntensity()
        {
        }

        public ParsedData MeasuredLightIntensityProcess(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.MeasuredLightIntensity);

            Byte measuredLightIntensityDataBytes = buffer.Dequeue();

            String measuredLightIntensity = String.Empty;
            if (measuredLightIntensityDataBytes == 0x00)
            {
                measuredLightIntensity = "Hidden";
            }
            else if (measuredLightIntensityDataBytes == 0x01)
            {
                measuredLightIntensity = "Shown";
            }

            Reading measuredLightIntensityReading = new Reading()
            {
                ParameterType = ParameterType.DeviceMeasuredLightIntensity,
                ReadingValueType = ReadingValueType.String,
                ValueString = measuredLightIntensity,
                Unit = Unit.None
            };
            parsedData.AddReading(measuredLightIntensityReading);

            return parsedData;
        }
    }
}