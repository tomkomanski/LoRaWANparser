using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class CO2MeasurementPeriod : IPartialParser
    {
        private static CO2MeasurementPeriod? instance;

        public static CO2MeasurementPeriod GetParser()
        {
            if (instance == null)
            {
                instance = new CO2MeasurementPeriod();
            }
            return instance;
        }

        private CO2MeasurementPeriod()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.CO2MeasurementPeriod);

            Byte co2MeasurementPeriodGoodZone = buffer.Dequeue();
            Reading co2MeasurementPeriodGoodZoneReading = new Reading()
            {
                ParameterType = ParameterType.CO2MeasurementPeriodGoodZone,
                ReadingValueType = ReadingValueType.Double,
                Value = co2MeasurementPeriodGoodZone,
                Unit = Unit.Minute
            };
            parsedData.AddReading(co2MeasurementPeriodGoodZoneReading);

            Byte co2MeasurementPeriodMediumZone = buffer.Dequeue();
            Reading co2MeasurementPeriodMediumZoneReading = new Reading()
            {
                ParameterType = ParameterType.CO2MeasurementPeriodMediumZone,
                ReadingValueType = ReadingValueType.Double,
                Value = co2MeasurementPeriodMediumZone,
                Unit = Unit.Minute
            };
            parsedData.AddReading(co2MeasurementPeriodMediumZoneReading);

            Byte co2MeasurementPeriodBadZone = buffer.Dequeue();
            Reading co2MeasurementPeriodBadZoneReading = new Reading()
            {
                ParameterType = ParameterType.CO2MeasurementPeriodBadZone,
                ReadingValueType = ReadingValueType.Double,
                Value = co2MeasurementPeriodBadZone,
                Unit = Unit.Minute
            };
            parsedData.AddReading(co2MeasurementPeriodBadZoneReading);

            return parsedData;
        }
    }
}