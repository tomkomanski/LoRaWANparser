using System;
using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;
using LoRaWANparser.MClimateCO2.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2.Parsers
{
    internal sealed class UplinkMessages : IPartialParser
    {
        private static UplinkMessages? instance;

        public static UplinkMessages GetParser()
        {
            if (instance == null)
            {
                instance = new UplinkMessages();
            }
            return instance;
        }

        private UplinkMessages()
        {
        }

        public ParsedData Process(IEnumerable<byte> dataBytes)
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