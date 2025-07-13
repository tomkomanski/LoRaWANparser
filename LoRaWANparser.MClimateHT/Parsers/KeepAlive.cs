using System;
using LoRaWANparser.MClimateHT.Enums;
using LoRaWANparser.MClimateHT.Models;
using LoRaWANparser.MClimateHT.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateHT.Parsers
{
    internal sealed class KeepAlive : IPartialParser
    {
        private static KeepAlive? instance;

        public static KeepAlive GetParser()
        {
            if (instance == null)
            {
                instance = new KeepAlive();
            }
            return instance;
        }

        private KeepAlive()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.KeepAlive);

            Byte[] internalTemperatureDataBytes = buffer.DequeueChunk(2).ToArray();
            Array.Reverse(internalTemperatureDataBytes);
            UInt16 internalTemperatureData = BitConverter.ToUInt16(internalTemperatureDataBytes, 0);
            Double internalTemperature = ((Double)internalTemperatureData - 400) / 10;
            Reading internalTemperatureReading = new Reading()
            {
                ReadingValueType = ReadingValueType.Double,
                ParameterType = ParameterType.InternalTemperature,
                Value = internalTemperature,
                Unit = Unit.CelsiusSymbol
            };
            parsedData.AddReading(internalTemperatureReading);

            Byte relativeHumidityByte = buffer.Dequeue();
            Double relativeHumidity = ((Double)relativeHumidityByte * 100) / 256;
            Reading relativeHumidityReading = new Reading()
            {
                ReadingValueType = ReadingValueType.Double,
                ParameterType = ParameterType.RelativeHumidity,
                Value = Math.Truncate(relativeHumidity * 100) / 100,
                Unit = Unit.Percentage
            };
            parsedData.AddReading(relativeHumidityReading);

            Byte batteryVoltageByte = buffer.Dequeue();
            Double batteryVoltage = ((Double)batteryVoltageByte * 8) + 1600;
            Reading batteryVoltageReading = new Reading()
            {
                ReadingValueType = ReadingValueType.Double,
                ParameterType = ParameterType.DeviceBatteryVoltage,
                Value = batteryVoltage,
                Unit = Unit.MiliVolt
            };
            parsedData.AddReading(batteryVoltageReading);

            Byte combinedData = buffer.Dequeue();
            //Rserved
            Byte reserved = (Byte)(combinedData & 0xF8);
            //-------
            Byte externalThermistorState = (Byte)((Byte)(combinedData & 0x04) >> 2);

            if (externalThermistorState == 1)
            {
                Reading externalThermistor = new Reading()
                {
                    ReadingValueType = ReadingValueType.String,
                    ParameterType = ParameterType.ExternalThermistorTemperature,
                    ValueString = "External thermistor connection broken",
                    Unit = Unit.None
                };
                parsedData.AddReading(externalThermistor);
            }
            else
            {
                Byte externalThermistorSecondByte = (Byte)(combinedData & 0x03);
                Byte externalThermistorFirstByte = buffer.Dequeue();
                Byte[] externalThermistorBytes = new Byte[2];
                externalThermistorBytes[1] = externalThermistorSecondByte;
                externalThermistorBytes[0] = externalThermistorFirstByte;

                UInt16 externalThermistorTemperatureData = BitConverter.ToUInt16(externalThermistorBytes, 0);
                Double externalThermistorTemperature = (Double)externalThermistorTemperatureData / 10;
                Reading externalThermistorTemperatureReading = new Reading()
                {
                    ReadingValueType = ReadingValueType.Double,
                    ParameterType = ParameterType.ExternalThermistorTemperature,
                    Value = externalThermistorTemperature,
                    Unit = Unit.CelsiusSymbol
                };
                parsedData.AddReading(externalThermistorTemperatureReading);
            }

            return parsedData;
        }
    }
}