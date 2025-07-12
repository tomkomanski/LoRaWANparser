using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class CO2MeasurementBlindTime : IPartialParser
    {
        private static CO2MeasurementBlindTime? instance;

        public static CO2MeasurementBlindTime GetParser()
        {
            if (instance == null)
            {
                instance = new CO2MeasurementBlindTime();
            }
            return instance;
        }

        private CO2MeasurementBlindTime()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.CO2MeasurementBlindTime);

            Byte co2MeasurementBlindTimeDataBytes = buffer.Dequeue();
            Reading co2MeasurementBlindTimeDataBytesReading = new Reading()
            {
                ParameterType = ParameterType.CO2MeasurementBlindTime,
                ReadingValueType = ReadingValueType.Double,
                Value = co2MeasurementBlindTimeDataBytes,
                Unit = Unit.Minute
            };
            parsedData.AddReading(co2MeasurementBlindTimeDataBytesReading);

            return parsedData;
        }
    }
}