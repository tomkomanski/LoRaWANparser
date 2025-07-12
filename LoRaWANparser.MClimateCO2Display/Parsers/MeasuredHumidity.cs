using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class MeasuredHumidity : IPartialParser
    {
        private static MeasuredHumidity? instance;

        public static MeasuredHumidity GetParser()
        {
            if (instance == null)
            {
                instance = new MeasuredHumidity();
            }
            return instance;
        }

        private MeasuredHumidity()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
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