using System;
using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;
using LoRaWANparser.MClimateCO2.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2.Parsers
{
    internal sealed class CO2BoundaryLevels : IPartialParser
    {
        private static CO2BoundaryLevels? instance;

        public static CO2BoundaryLevels GetParser()
        {
            if (instance == null)
            {
                instance = new CO2BoundaryLevels();
            }
            return instance;
        }

        private CO2BoundaryLevels()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.CO2BoundaryLevels);

            Byte[] co2BoundaryLevelGoodMediumDataBytes = buffer.DequeueChunk(2).ToArray();
            Array.Reverse(co2BoundaryLevelGoodMediumDataBytes);
            UInt16 co2BoundaryLevelGoodMediumData = BitConverter.ToUInt16(co2BoundaryLevelGoodMediumDataBytes, 0);
            Double co2BoundaryLevelGoodMedium = (Double)co2BoundaryLevelGoodMediumData;

            Reading co2BoundaryLevelGoodMediumReading = new Reading()
            {
                ParameterType = ParameterType.Co2BoundaryLevelGoodMediumZone,
                ReadingValueType = ReadingValueType.Double,
                Value = co2BoundaryLevelGoodMedium,
                Unit = Unit.Ppm
            };
            parsedData.AddReading(co2BoundaryLevelGoodMediumReading);

            Byte[] co2BoundaryLevelMediumBadDataBytes = buffer.DequeueChunk(2).ToArray();
            Array.Reverse(co2BoundaryLevelMediumBadDataBytes);
            UInt16 co2BoundaryLevelMediumBadData = BitConverter.ToUInt16(co2BoundaryLevelMediumBadDataBytes, 0);
            Double co2BoundaryLevelMediumBad = (Double)co2BoundaryLevelMediumBadData;

            Reading co2BoundaryLevelMediumBadReading = new Reading()
            {
                ParameterType = ParameterType.Co2BoundaryLevelMediumBadZone,
                ReadingValueType = ReadingValueType.Double,
                Value = co2BoundaryLevelMediumBad,
                Unit = Unit.Ppm
            };
            parsedData.AddReading(co2BoundaryLevelMediumBadReading);

            return parsedData;
        }
    }
}