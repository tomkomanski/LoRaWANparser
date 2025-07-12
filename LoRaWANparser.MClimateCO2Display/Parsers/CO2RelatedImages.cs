using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display.Parsers
{
    internal sealed class CO2RelatedImages
    {
        public CO2RelatedImages()
        {
        }

        public ParsedData CO2RelatedImagesProcess(IEnumerable<Byte> dataBytes)
        {
            ParsedData parsedData = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(dataBytes);

            Byte commandByte = buffer.Dequeue();

            parsedData.AddCommandType(CommandType.CO2RelatedImages);

            Byte co2RelatedImagesDataBytes = buffer.Dequeue();

            String chart = String.Empty;
            if ((co2RelatedImagesDataBytes & 0x04) == 0x00)
            {
                chart = "Hidden";
            }
            else
            {
                chart = "Shown";
            }

            String digitalValue = String.Empty;
            if ((co2RelatedImagesDataBytes & 0x02) == 0x00)
            {
                digitalValue = "Hidden";
            }
            else
            {
                digitalValue = "Shown";
            }

            String emoji = String.Empty;
            if ((co2RelatedImagesDataBytes & 0x01) == 0x00)
            {
                emoji = "Hidden";
            }
            else
            {
                emoji = "Shown";
            }

            Reading chartReading = new Reading()
            {
                ParameterType = ParameterType.CO2ChartOnDisplay,
                ReadingValueType = ReadingValueType.String,
                ValueString = chart,
                Unit = Unit.None
            };
            parsedData.AddReading(chartReading);

            Reading digitalValueReading = new Reading()
            {
                ParameterType = ParameterType.CO2DigitalValueOnDisplay,
                ReadingValueType = ReadingValueType.String,
                ValueString = digitalValue,
                Unit = Unit.None
            };
            parsedData.AddReading(digitalValueReading);

            Reading emojiReading = new Reading()
            {
                ParameterType = ParameterType.CO2EmojiOnDisplay,
                ReadingValueType = ReadingValueType.String,
                ValueString = emoji,
                Unit = Unit.None
            };
            parsedData.AddReading(emojiReading);

            return parsedData;
        }
    }
}