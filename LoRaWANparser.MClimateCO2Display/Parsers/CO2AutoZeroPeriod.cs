﻿using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class CO2AutoZeroPeriod : IPartialParser
    {
        private static CO2AutoZeroPeriod? instance;

        public static CO2AutoZeroPeriod GetParser()
        {
            if (instance == null)
            {
                instance = new CO2AutoZeroPeriod();
            }
            return instance;
        }

        private CO2AutoZeroPeriod()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.CO2AutoZeroPeriod);

            Byte co2AutoZeroPeriodDataBytes = buffer.Dequeue();
            Reading co2AutoZeroPeriodDataBytesReading = new Reading()
            {
                ParameterType = ParameterType.CO2AutoZeroPeriod,
                ReadingValueType = ReadingValueType.Double,
                Value = co2AutoZeroPeriodDataBytes,
                Unit = Unit.Hour
            };
            parsedData.AddReading(co2AutoZeroPeriodDataBytesReading);

            return parsedData;
        }
    }
}