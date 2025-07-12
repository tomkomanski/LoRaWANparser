using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class PIRcheckPeriod
    {
        public PIRcheckPeriod()
        {
        }

        public ParsedData PIRcheckPeriodProcess(IEnumerable<Byte> dataBytes)
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