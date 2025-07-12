using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class UplinkMessages
    {
        public UplinkMessages()
        {
        }

        public ParsedData UplinkMessagesProcess(IEnumerable<byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.UplinkMessages);

            byte deviceUplinkMessages = buffer.Dequeue();

            string deviceUplingMessageType = string.Empty;
            if (deviceUplinkMessages == 0x00)
            {
                deviceUplingMessageType = "Device operates with unconfirmed uplinks";
            }
            else if (deviceUplinkMessages == 0x01)
            {
                deviceUplingMessageType = "Device operates with confirmed uplinks";
            }

            Reading deviceUplinkMessagesReading = new Reading()
            {
                ParameterType = ParameterType.DeviceUplinkMessages,
                ReadingValueType = ReadingValueType.String,
                ValueString = deviceUplingMessageType,
                Unit = Unit.None
            };
            parsedData.AddReading(deviceUplinkMessagesReading);

            return parsedData;
        }
    }
}