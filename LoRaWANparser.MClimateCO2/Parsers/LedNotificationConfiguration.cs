using System;
using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;
using LoRaWANparser.MClimateCO2.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2.Parsers
{
    internal sealed class LedNotificationConfiguration : IPartialParser
    {
        private static LedNotificationConfiguration? instance;

        public static LedNotificationConfiguration GetParser()
        {
            if (instance == null)
            {
                instance = new LedNotificationConfiguration();
            }
            return instance;
        }

        private LedNotificationConfiguration()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.LedNotificationConfiguration);

            Byte led = buffer.Dequeue();
            Reading ledReading = new Reading()
            {
                ParameterType = ParameterType.RedLedProcedureGoodCO2level,
                ReadingValueType = ReadingValueType.String,
                ValueString = this.LedProcedure(led),
                Unit = Unit.None
            };
            parsedData.AddReading(ledReading);

            led = buffer.Dequeue();
            ledReading = new Reading()
            {
                ParameterType = ParameterType.GreenLedProcedureGoodCO2level,
                ReadingValueType = ReadingValueType.String,
                ValueString = this.LedProcedure(led),
                Unit = Unit.None
            };
            parsedData.AddReading(ledReading);

            led = buffer.Dequeue();
            ledReading = new Reading()
            {
                ParameterType = ParameterType.BlueLedProcedureGoodCO2level,
                ReadingValueType = ReadingValueType.String,
                ValueString = this.LedProcedure(led),
                Unit = Unit.None
            };
            parsedData.AddReading(ledReading);

            Byte[] ledBytes = buffer.DequeueChunk(2).ToArray();
            Array.Reverse(ledBytes);
            Double ledData = (Double)BitConverter.ToUInt16(ledBytes, 0);
            ledReading = new Reading()
            {
                ParameterType = ParameterType.DurationLedNotificationGoodCO2level,
                ReadingValueType = ReadingValueType.Double,
                Value = ledData * 10,
                Unit = Unit.MiliSecond
            };
            parsedData.AddReading(ledReading);

            led = buffer.Dequeue();
            ledReading = new Reading()
            {
                ParameterType = ParameterType.RedLedProcedureMediumCO2level,
                ReadingValueType = ReadingValueType.String,
                ValueString = this.LedProcedure(led),
                Unit = Unit.None
            };
            parsedData.AddReading(ledReading);

            led = buffer.Dequeue();
            ledReading = new Reading()
            {
                ParameterType = ParameterType.GreenLedProcedureMediumCO2level,
                ReadingValueType = ReadingValueType.String,
                ValueString = this.LedProcedure(led),
                Unit = Unit.None
            };
            parsedData.AddReading(ledReading);

            led = buffer.Dequeue();
            ledReading = new Reading()
            {
                ParameterType = ParameterType.BlueLedProcedureMediumCO2level,
                ReadingValueType = ReadingValueType.String,
                ValueString = this.LedProcedure(led),
                Unit = Unit.None
            };
            parsedData.AddReading(ledReading);

            ledBytes = buffer.DequeueChunk(2).ToArray();
            Array.Reverse(ledBytes);
            ledData = (Double)BitConverter.ToUInt16(ledBytes, 0);
            ledReading = new Reading()
            {
                ParameterType = ParameterType.DurationLedNotificationMediumCO2level,
                ReadingValueType = ReadingValueType.Double,
                Value = ledData * 10,
                Unit = Unit.MiliSecond
            };
            parsedData.AddReading(ledReading);

            led = buffer.Dequeue();
            ledReading = new Reading()
            {
                ParameterType = ParameterType.RedLedProcedureBadCO2level,
                ReadingValueType = ReadingValueType.String,
                ValueString = this.LedProcedure(led),
                Unit = Unit.None
            };
            parsedData.AddReading(ledReading);

            led = buffer.Dequeue();
            ledReading = new Reading()
            {
                ParameterType = ParameterType.GreenLedProcedureBadCO2level,
                ReadingValueType = ReadingValueType.String,
                ValueString = this.LedProcedure(led),
                Unit = Unit.None
            };
            parsedData.AddReading(ledReading);

            led = buffer.Dequeue();
            ledReading = new Reading()
            {
                ParameterType = ParameterType.BlueLedProcedureBadCO2level,
                ReadingValueType = ReadingValueType.String,
                ValueString = this.LedProcedure(led),
                Unit = Unit.None
            };
            parsedData.AddReading(ledReading);

            ledBytes = buffer.DequeueChunk(2).ToArray();
            Array.Reverse(ledBytes);
            ledData = (Double)BitConverter.ToUInt16(ledBytes, 0);
            ledReading = new Reading()
            {
                ParameterType = ParameterType.DurationLedNotificationBadCO2level,
                ReadingValueType = ReadingValueType.Double,
                Value = ledData * 10,
                Unit = Unit.MiliSecond
            };
            parsedData.AddReading(ledReading);

            return parsedData;
        }

        private String LedProcedure(Byte ledProcedureByte)
        {
            String ledProcedure = String.Empty;
            if (ledProcedureByte == 0x00)
            {
                ledProcedure = "None";
            }
            else if (ledProcedureByte == 0x01)
            {
                ledProcedure = "Constantly on for the given time duration";
            }
            else if (ledProcedureByte == 0x02)
            {
                ledProcedure = "Blink fast for the given time duration";
            }
            else if (ledProcedureByte == 0x03)
            {
                ledProcedure = "Blink slow for the given time duration";
            }
            else
            {
                ledProcedure = "Unknown";
            }

            return ledProcedure;
        }
    }
}