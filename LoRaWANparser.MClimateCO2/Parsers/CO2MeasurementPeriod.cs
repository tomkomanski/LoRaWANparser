using System;
using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2.Parsers
{
    internal sealed class CO2MeasurementPeriod
    {
        public CO2MeasurementPeriod()
        {
        }

        public ParsedData CO2MeasurementPeriodProcess(IEnumerable<Byte> dataBytes)
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