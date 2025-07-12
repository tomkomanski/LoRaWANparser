using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class PIRcheckPeriod : IPartialParser
    {
        private static PIRcheckPeriod? instance;

        public static PIRcheckPeriod GetParser()
        {
            if (instance == null)
            {
                instance = new PIRcheckPeriod();
            }
            return instance;
        }

        private PIRcheckPeriod()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.PIRcheckPeriod);

            Byte[] pirCheckPeriodDataBytes = buffer.DequeueChunk(2).ToArray();
            Array.Reverse(pirCheckPeriodDataBytes);
            UInt16 pirCheckPeriodData = BitConverter.ToUInt16(pirCheckPeriodDataBytes, 0);
            Double pirCheckPeriod = (Double)pirCheckPeriodData;

            Reading pirCheckPeriodDataBytesReading = new Reading()
            {
                ParameterType = ParameterType.DevicePIRsensorCheckPeriod,
                ReadingValueType = ReadingValueType.Double,
                Value = pirCheckPeriod,
                Unit = Unit.Second
            };
            parsedData.AddReading(pirCheckPeriodDataBytesReading);

            return parsedData;
        }
    }
}