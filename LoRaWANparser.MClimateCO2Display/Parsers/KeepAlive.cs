using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
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

            Byte[] batteryVoltageBytes = buffer.DequeueChunk(2).ToArray();
            Array.Reverse(batteryVoltageBytes);
            UInt16 batteryVoltageData = BitConverter.ToUInt16(batteryVoltageBytes, 0);
            Double batteryVoltage = (Double)batteryVoltageData;
            Reading batteryVoltageReading = new Reading()
            {
                ReadingValueType = ReadingValueType.Double,
                ParameterType = ParameterType.DeviceBatteryVoltage,
                Value = batteryVoltage,
                Unit = Unit.MiliVolt
            };
            parsedData.AddReading(batteryVoltageReading);

            Byte co21 = buffer.Dequeue();
            Byte combinedByte = buffer.Dequeue();
            Byte co22 = (Byte)(combinedByte >> 3);

            Byte[] co2array = new Byte[2];
            co2array[1] = co22;
            co2array[0] = co21;

            UInt16 co2Data = BitConverter.ToUInt16(co2array, 0);
            Double co2 = (Double)co2Data;
            Reading co2Reading = new Reading()
            {
                ReadingValueType = ReadingValueType.Double,
                ParameterType = ParameterType.Co2,
                Value = co2,
                Unit = Unit.Ppm
            };
            parsedData.AddReading(co2Reading);

            Byte powerSource = (Byte)(combinedByte & 0x07);
            if (powerSource == 0)
            {
                Reading powerSourceReading = new Reading()
                {
                    ReadingValueType = ReadingValueType.String,
                    ParameterType = ParameterType.PowerSource,
                    ValueString = "Photovoltaic panel",
                    Unit = Unit.None
                };
                parsedData.AddReading(powerSourceReading);
            }
            else if (powerSource == 1)
            {
                Reading powerSourceReading = new Reading()
                {
                    ReadingValueType = ReadingValueType.String,
                    ParameterType = ParameterType.PowerSource,
                    ValueString = "Batteries",
                    Unit = Unit.None
                };
                parsedData.AddReading(powerSourceReading);
            }
            else if (powerSource == 2)
            {
                Reading powerSourceReading = new Reading()
                {
                    ReadingValueType = ReadingValueType.String,
                    ParameterType = ParameterType.PowerSource,
                    ValueString = "USB",
                    Unit = Unit.None
                };
                parsedData.AddReading(powerSourceReading);
            }

            Byte[] deviceLightIntensityBytes = buffer.DequeueChunk(2).ToArray();
            Array.Reverse(deviceLightIntensityBytes);
            UInt16 deviceLightIntensityData = BitConverter.ToUInt16(deviceLightIntensityBytes, 0);
            Double deviceLightIntensity = (Double)deviceLightIntensityData;
            Reading deviceLightIntensityReading = new Reading()
            {
                ReadingValueType = ReadingValueType.Double,
                ParameterType = ParameterType.DeviceLightIntensity,
                Value = deviceLightIntensity,
                Unit = Unit.Lux
            };
            parsedData.AddReading(deviceLightIntensityReading);

            Byte pirSensorByte = buffer.Dequeue();

            if (pirSensorByte == 0)
            {
                Reading pirSensorReading = new Reading()
                {
                    ReadingValueType = ReadingValueType.String,
                    ParameterType = ParameterType.PIRsensor,
                    ValueString = "No motion detected",
                    Unit = Unit.None
                };
                parsedData.AddReading(pirSensorReading);
            }
            else if (pirSensorByte == 1)
            {
                Reading pirSensorReading = new Reading()
                {
                    ReadingValueType = ReadingValueType.String,
                    ParameterType = ParameterType.PIRsensor,
                    ValueString = "Motion detected",
                    Unit = Unit.Percentage
                };
                parsedData.AddReading(pirSensorReading);
            }

            return parsedData;
        }
    }
}