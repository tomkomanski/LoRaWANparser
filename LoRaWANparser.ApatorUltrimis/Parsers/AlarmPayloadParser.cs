using System;
using LoRaWANparser.ApatorUltrimis.Extensions;
using LoRaWANparser.ApatorUltrimis.Models;
using LoRaWANparser.ApatorUltrimis.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.ApatorUltrimis.Parsers
{
    internal sealed class AlarmPayloadParser : IPartialParser
    {
        private static AlarmPayloadParser? instance;

        public static AlarmPayloadParser GetParser()
        {
            if (instance == null)
            {
                instance = new AlarmPayloadParser();
            }
            return instance;
        }

        private AlarmPayloadParser()
        {
        }

        public Payload Decoder(Byte[] bufferBytes)
        {
            AlarmPayload alarmPayload = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(bufferBytes);

            Byte[] timestampByte = buffer.DequeueChunk(4).ToArray();
            Int64 unix_timestamp1 = BitConverter.ToInt32(timestampByte, 0);

            alarmPayload.SetTimeStamp(unix_timestamp1.UnixTimeStampToDateTime());

            Byte[] meterSNBytes = buffer.DequeueChunk(4).ToArray();
            Array.Reverse(meterSNBytes);
            alarmPayload.SetMeterSN(Convert.ToHexString(meterSNBytes));

            Byte flagsCurrentMonth = buffer.Dequeue();
            Byte flagsCurrentDay = buffer.Dequeue();
            Byte flagsCurrent = buffer.Dequeue();
            alarmPayload.SetFlagsCurrentMonth(flagsCurrentMonth.Flags2String());
            alarmPayload.SetFlagsCurrentDay(flagsCurrentDay.Flags2String());
            alarmPayload.SetFlagsCurrent(flagsCurrent.Flags2String());

            return alarmPayload;
        }
    }
}