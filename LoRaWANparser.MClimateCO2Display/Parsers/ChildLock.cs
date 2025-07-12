using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class ChildLock
    {
        public ChildLock()
        {
        }

        public ParsedData ChildLockProcess(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.ChildLock);

            Byte deviceChildLock = buffer.Dequeue();

            String childLock = String.Empty;
            if (deviceChildLock == 0x00)
            {
                childLock = "Disabled";
            }
            else if (deviceChildLock == 0x01)
            {
                childLock = "Enabled";
            }

            Reading deviceChildLockReading = new Reading()
            {
                ParameterType = ParameterType.DeviceChildLock,
                ReadingValueType = ReadingValueType.String,
                ValueString = childLock,
                Unit = Unit.None
            };
            parsedData.AddReading(deviceChildLockReading);

            return parsedData;
        }
    }
}