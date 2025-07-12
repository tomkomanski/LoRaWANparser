using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class FullDisplayRefresh : IPartialParser
    {
        private static FullDisplayRefresh? instance;

        public static FullDisplayRefresh GetParser()
        {
            if (instance == null)
            {
                instance = new FullDisplayRefresh();
            }
            return instance;
        }

        private FullDisplayRefresh()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.FullDisplayRefresh);

            Byte fullDisplayRefreshDataBytes = buffer.Dequeue();
            Reading fullDisplayRefreshDataBytesReading = new Reading()
            {
                ParameterType = ParameterType.DisplayRefreshPeriod,
                ReadingValueType = ReadingValueType.Double,
                Value = fullDisplayRefreshDataBytes,
                Unit = Unit.Hour
            };
            parsedData.AddReading(fullDisplayRefreshDataBytesReading);

            return parsedData;
        }
    }
}