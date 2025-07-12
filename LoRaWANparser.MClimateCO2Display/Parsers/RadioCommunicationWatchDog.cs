using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class RadioCommunicationWatchDog : IPartialParser
    {
        private static RadioCommunicationWatchDog? instance;

        public static RadioCommunicationWatchDog GetParser()
        {
            if (instance == null)
            {
                instance = new RadioCommunicationWatchDog();
            }
            return instance;
        }

        private RadioCommunicationWatchDog()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.RadioCommunicationWatchDog);

            Byte deviceRadioCommunicationWatchDogConfirmedUplink = buffer.Dequeue();

            Reading deviceRadioCommunicationWatchDogConfirmedUplinkReading = new Reading()
            {
                ParameterType = ParameterType.DeviceRadioCommunicationWatchDogConfirmedUplink,
                ReadingValueType = ReadingValueType.Double,
                Value = deviceRadioCommunicationWatchDogConfirmedUplink,
                Unit = Unit.None
            };
            parsedData.AddReading(deviceRadioCommunicationWatchDogConfirmedUplinkReading);

            Byte deviceRadioCommunicationWatchDogUnconfirmedUplink = buffer.Dequeue();

            Reading deviceRadioCommunicationWatchDogUnconfirmedUplinkReading = new Reading()
            {
                ParameterType = ParameterType.DeviceRadioCommunicationWatchDogUnconfirmedUplink,
                ReadingValueType = ReadingValueType.Double,
                Value = deviceRadioCommunicationWatchDogUnconfirmedUplink,
                Unit = Unit.None
            };
            parsedData.AddReading(deviceRadioCommunicationWatchDogUnconfirmedUplinkReading);

            return parsedData;
        }
    }
}