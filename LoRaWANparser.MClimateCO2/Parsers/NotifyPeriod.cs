using System;
using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2.Parsers
{
    internal sealed class NotifyPeriod
    {
        public NotifyPeriod()
        {
        }

        public ParsedData NotifyPeriodProcess(IEnumerable<Byte> dataBytes)
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