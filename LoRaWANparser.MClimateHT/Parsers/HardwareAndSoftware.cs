using System;
using LoRaWANparser.MClimateHT.Enums;
using LoRaWANparser.MClimateHT.Models;
using LoRaWANparser.MClimateHT.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateHT.Parsers
{
    internal sealed class HardwareAndSoftware : IPartialParser
    {
        private static HardwareAndSoftware? instance;

        public static HardwareAndSoftware GetParser()
        {
            if (instance == null)
            {
                instance = new HardwareAndSoftware();
            }
            return instance;
        }

        private HardwareAndSoftware()
        {
        }

        public ParsedData Process(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.HardwareAndSoftwareVersion);

            Byte deviceHardwareVersion = buffer.Dequeue();
            Byte devicePrimaryHardwareVersion = (Byte)(deviceHardwareVersion >> 4);
            Byte deviceSecondaryHardwareVersion = (Byte)(deviceHardwareVersion & 0x0F);

            Reading deviceHardwareVersionReading = new Reading()
            {
                ParameterType = ParameterType.DeviceHardwareVersion,
                ReadingValueType = ReadingValueType.String,
                ValueString = $"{devicePrimaryHardwareVersion}.{deviceSecondaryHardwareVersion}",
                Unit = Unit.None
            };
            parsedData.AddReading(deviceHardwareVersionReading);

            Byte deviceSoftwareVersion = buffer.Dequeue();
            Byte devicePrimarySoftwareVersion = (Byte)(deviceSoftwareVersion >> 4);
            Byte deviceSecondarySoftwareVersion = (Byte)(deviceSoftwareVersion & 0x0F);

            Reading deviceSoftwareVersionReading = new Reading()
            {
                ParameterType = ParameterType.DeviceSoftwareVersion,
                ReadingValueType = ReadingValueType.String,
                ValueString = $"{devicePrimarySoftwareVersion}.{deviceSecondarySoftwareVersion}",
                Unit = Unit.None
            };
            parsedData.AddReading(deviceSoftwareVersionReading);

            return parsedData;
        }
    }
}