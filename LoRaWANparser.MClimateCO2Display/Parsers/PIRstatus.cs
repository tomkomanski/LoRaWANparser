using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class PIRstatus
    {
        public PIRstatus()
        {
        }

        public ParsedData PIRstatusProcess(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.PIRstatus);

            Byte pirStatusDataBytes = buffer.Dequeue();

            String pirStatus = String.Empty;
            if (pirStatusDataBytes == 0x00)
            {
                pirStatus = "Disabled";
            }
            else if (pirStatusDataBytes == 0x01)
            {
                pirStatus = "Enabled";
            }

            Reading pirSensorStatusDataBytesReading = new Reading()
            {
                ParameterType = ParameterType.DevicePIRsensorStatus,
                ReadingValueType = ReadingValueType.String,
                ValueString = pirStatus,
                Unit = Unit.None
            };
            parsedData.AddReading(pirSensorStatusDataBytesReading);

            return parsedData;
        }
    }
}