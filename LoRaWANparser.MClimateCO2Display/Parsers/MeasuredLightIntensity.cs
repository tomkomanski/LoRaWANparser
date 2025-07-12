using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class MeasuredLightIntensity : IPartialParser
    {
        private static MeasuredLightIntensity? instance;

        public static MeasuredLightIntensity GetParser()
        {
            if (instance == null)
            {
                instance = new MeasuredLightIntensity();
            }
            return instance;
        }

        private MeasuredLightIntensity()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
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