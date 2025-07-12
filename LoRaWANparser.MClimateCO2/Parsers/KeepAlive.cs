using System;
using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;
using LoRaWANparser.MClimateCO2.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2.Parsers
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

            Byte[] co2DataBytes = buffer.DequeueChunk(2).ToArray();
            Array.Reverse(co2DataBytes);
            UInt16 co2Data = BitConverter.ToUInt16(co2DataBytes, 0);
            Double co2 = (Double)co2Data;
            Reading co2Reading = new Reading()
            {
                ReadingValueType = ReadingValueType.Double,
                ParameterType = ParameterType.Co2,
                Value = co2,
                Unit = Unit.Ppm
            };
            parsedData.AddReading(co2Reading);

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

            return parsedData;
        }
    }
}