using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class PIRblindPeriod : IPartialParser
    {
        private static PIRblindPeriod? instance;

        public static PIRblindPeriod GetParser()
        {
            if (instance == null)
            {
                instance = new PIRblindPeriod();
            }
            return instance;
        }

        private PIRblindPeriod()
        {
        }


        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.PIRblindPeriod);

            Byte[] pirBlindPeriodDataBytes = buffer.DequeueChunk(2).ToArray();
            Array.Reverse(pirBlindPeriodDataBytes);
            UInt16 pirBlindPeriodData = BitConverter.ToUInt16(pirBlindPeriodDataBytes, 0);
            Double pirBlindPeriod = (Double)pirBlindPeriodData;

            Reading pirBlindPeriodDataBytesReading = new Reading()
            {
                ParameterType = ParameterType.DevicePIRsensorBlindPeriod,
                ReadingValueType = ReadingValueType.Double,
                Value = pirBlindPeriod,
                Unit = Unit.Second
            };
            parsedData.AddReading(pirBlindPeriodDataBytesReading);

            return parsedData;
        }
    }
}