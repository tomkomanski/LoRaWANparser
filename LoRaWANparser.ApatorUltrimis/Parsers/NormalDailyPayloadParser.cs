using System;
using LoRaWANparser.ApatorUltrimis.Extensions;
using LoRaWANparser.ApatorUltrimis.Models;
using LoRaWANparser.ApatorUltrimis.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.ApatorUltrimis.Parsers
{
    internal sealed class NormalDailyPayloadParser : IPartialParser
    {
        private static NormalDailyPayloadParser? instance;

        public static NormalDailyPayloadParser GetParser()
        {
            if (instance == null)
            {
                instance = new NormalDailyPayloadParser();
            }
            return instance;
        }

        private NormalDailyPayloadParser()
        {
        }

        public Payload Decoder(Byte[] bufferBytes)
        {
            NormalDailyPayload normalDailyPayload = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(bufferBytes);

            Byte[] timestampByte = buffer.DequeueChunk(4).ToArray();
            Int64 unix_timestamp1 = BitConverter.ToInt32(timestampByte, 0);

            normalDailyPayload.SetTimeStamp(unix_timestamp1.UnixTimeStampToDateTime());

            Byte[] meterSnBytes = buffer.DequeueChunk(4).ToArray();
            Array.Reverse(meterSnBytes);
            normalDailyPayload.SetMeterSN(Convert.ToHexString(meterSnBytes));

            Byte[] dailyReverseVolumeByte = buffer.DequeueChunk(4).ToArray();
            Int32 dailyReverseVolume = BitConverter.ToInt32(dailyReverseVolumeByte, 0);
            TimeStampVolume volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp1.UnixTimeStampToDateTime(),
                Volume = dailyReverseVolume
            };
            normalDailyPayload.SetDailyReverseVolume(volume);

            Byte flagsCurrentMonth = buffer.Dequeue();
            Byte flagsCurrentDay = buffer.Dequeue();
            Byte flagsCurrent = buffer.Dequeue();
            normalDailyPayload.SetFlagsCurrentMonth(flagsCurrentMonth.Flags2String());
            normalDailyPayload.SetFlagsCurrentDay(flagsCurrentDay.Flags2String());
            normalDailyPayload.SetFlagsCurrent(flagsCurrent.Flags2String());

            Byte[] dailyVolumeByte = buffer.DequeueChunk(4).ToArray();
            Int32 dailyVolume = BitConverter.ToInt32(dailyVolumeByte, 0);
            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp1.UnixTimeStampToDateTime(),
                Volume = dailyVolume,
            };
            normalDailyPayload.SetDailyVolume(volume);

            return normalDailyPayload;
        }
    }
}