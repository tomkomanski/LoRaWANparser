using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class RadioCommunicationWatchDog
    {
        public RadioCommunicationWatchDog() 
        { 
        }

        public ParsedData RadioCommunicationWatchDogProcess(IEnumerable<Byte> dataBytes)
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