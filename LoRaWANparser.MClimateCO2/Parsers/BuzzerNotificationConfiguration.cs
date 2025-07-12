using System;
using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;
using LoRaWANparser.MClimateCO2.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2.Parsers
{
    internal sealed class BuzzerNotificationConfiguration : IPartialParser
    {
        private static BuzzerNotificationConfiguration? instance;

        public static BuzzerNotificationConfiguration GetParser()
        {
            if (instance == null)
            {
                instance = new BuzzerNotificationConfiguration();
            }
            return instance;
        }

        private BuzzerNotificationConfiguration()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.BuzzerNotificationConfiguration);

            Byte buzzer = buffer.Dequeue();
            Reading buzzerReading = new Reading()
            {
                ParameterType = ParameterType.DurationOfBuzzerBeepingGoodCO2Levels,
                ReadingValueType = ReadingValueType.Double,
                Value = buzzer,
                Unit = Unit.Second
            };
            parsedData.AddReading(buzzerReading);

            buzzer = buffer.Dequeue();
            buzzerReading = new Reading()
            {
                ParameterType = ParameterType.DurationOfBuzzerLoudPeriodsGoodCO2Levels,
                ReadingValueType = ReadingValueType.Double,
                Value = buzzer * 10,
                Unit = Unit.MiliSecond
            };
            parsedData.AddReading(buzzerReading);

            buzzer = buffer.Dequeue();
            buzzerReading = new Reading()
            {
                ParameterType = ParameterType.DurationOfBuzzerSilentPeriodsGoodCO2Levels,
                ReadingValueType = ReadingValueType.Double,
                Value = buzzer * 10,
                Unit = Unit.MiliSecond
            };
            parsedData.AddReading(buzzerReading);

            buzzer = buffer.Dequeue();
            buzzerReading = new Reading()
            {
                ParameterType = ParameterType.DurationOfBuzzerBeepingMediumCO2Levels,
                ReadingValueType = ReadingValueType.Double,
                Value = buzzer,
                Unit = Unit.Second
            };
            parsedData.AddReading(buzzerReading);

            buzzer = buffer.Dequeue();
            buzzerReading = new Reading()
            {
                ParameterType = ParameterType.DurationOfBuzzerLoudPeriodsMediumCO2Levels,
                ReadingValueType = ReadingValueType.Double,
                Value = buzzer * 10,
                Unit = Unit.MiliSecond
            };
            parsedData.AddReading(buzzerReading);

            buzzer = buffer.Dequeue();
            buzzerReading = new Reading()
            {
                ParameterType = ParameterType.DurationOfBuzzerSilentPeriodsMediumCO2Levels,
                ReadingValueType = ReadingValueType.Double,
                Value = buzzer * 10,
                Unit = Unit.MiliSecond
            };
            parsedData.AddReading(buzzerReading);

            buzzer = buffer.Dequeue();
            buzzerReading = new Reading()
            {
                ParameterType = ParameterType.DurationOfBuzzerBeepingBadCO2Levels,
                ReadingValueType = ReadingValueType.Double,
                Value = buzzer,
                Unit = Unit.Second
            };
            parsedData.AddReading(buzzerReading);

            buzzer = buffer.Dequeue();
            buzzerReading = new Reading()
            {
                ParameterType = ParameterType.DurationOfBuzzerLoudPeriodsBadCO2Levels,
                ReadingValueType = ReadingValueType.Double,
                Value = buzzer * 10,
                Unit = Unit.MiliSecond
            };
            parsedData.AddReading(buzzerReading);

            buzzer = buffer.Dequeue();
            buzzerReading = new Reading()
            {
                ParameterType = ParameterType.DurationOfBuzzerSilentPeriodsBadCO2Levels,
                ReadingValueType = ReadingValueType.Double,
                Value = buzzer * 10,
                Unit = Unit.MiliSecond
            };
            parsedData.AddReading(buzzerReading);

            return parsedData;
        }
    }
}