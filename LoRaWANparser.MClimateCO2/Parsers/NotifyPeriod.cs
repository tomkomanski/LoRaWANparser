using System;
using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;
using LoRaWANparser.MClimateCO2.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2.Parsers
{
    internal sealed class NotifyPeriod : IPartialParser
    {
        private static NotifyPeriod? instance;

        public static NotifyPeriod GetParser()
        {
            if (instance == null)
            {
                instance = new NotifyPeriod();
            }
            return instance;
        }

        private NotifyPeriod()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.NotifyPeriod);

            Byte notifyPeriodGoodZone = buffer.Dequeue();
            Reading notifyPeriodGoodZoneReading = new Reading()
            {
                ParameterType = ParameterType.NotificationPeriodGoodZone,
                ReadingValueType = ReadingValueType.Double,
                Value = notifyPeriodGoodZone,
                Unit = Unit.Minute
            };
            parsedData.AddReading(notifyPeriodGoodZoneReading);

            Byte notifyPeriodMediumZone = buffer.Dequeue();
            Reading notifyPeriodMediumZoneReading = new Reading()
            {
                ParameterType = ParameterType.NotificationPeriodMediumZone,
                ReadingValueType = ReadingValueType.Double,
                Value = notifyPeriodMediumZone,
                Unit = Unit.Minute
            };
            parsedData.AddReading(notifyPeriodMediumZoneReading);

            Byte notifyPeriodBadZone = buffer.Dequeue();
            Reading notifyPeriodBadZoneReading = new Reading()
            {
                ParameterType = ParameterType.NotificationPeriodBadZone,
                ReadingValueType = ReadingValueType.Double,
                Value = notifyPeriodBadZone,
                Unit = Unit.Minute
            };
            parsedData.AddReading(notifyPeriodBadZoneReading);

            return parsedData;
        }
    }
}