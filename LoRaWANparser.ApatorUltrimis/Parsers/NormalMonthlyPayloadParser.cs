using System;
using LoRaWANparser.ApatorUltrimis.Extensions;
using LoRaWANparser.ApatorUltrimis.Models;
using LoRaWANparser.ApatorUltrimis.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.ApatorUltrimis.Parsers
{
    internal sealed class NormalMonthlyPayloadParser : IPartialParser
    {
        private static NormalMonthlyPayloadParser? instance;

        public static NormalMonthlyPayloadParser GetParser()
        {
            if (instance == null)
            {
                instance = new NormalMonthlyPayloadParser();
            }
            return instance;
        }

        private NormalMonthlyPayloadParser()
        {
        }

        public Payload Decoder(Byte[] bufferBytes)
        {
            NormalMonthlyPayload mormalMonthlyPayload = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(bufferBytes);

            Byte[] timestampByte = buffer.DequeueChunk(4).ToArray();
            Int64 unix_timestamp1 = BitConverter.ToInt32(timestampByte, 0);

            mormalMonthlyPayload.SetTimeStamp(unix_timestamp1.UnixTimeStampToDateTime());

            Byte[] meterSnBytes = buffer.DequeueChunk(4).ToArray();
            Array.Reverse(meterSnBytes);
            mormalMonthlyPayload.SetMeterSN(Convert.ToHexString(meterSnBytes));

            Byte[] monthlyReverseVolumeBytes = buffer.DequeueChunk(4).ToArray();
            Int32 monthlyReverseVolume = BitConverter.ToInt32(monthlyReverseVolumeBytes, 0);
            TimeStampVolume volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp1.UnixTimeStampToDateTime(),
                Volume = monthlyReverseVolume
            };
            mormalMonthlyPayload.SetMonthlyReverseVolume(volume);

            Byte flagsCurrentMonth = buffer.Dequeue();
            Byte flagsCurrentDay = buffer.Dequeue();
            Byte flagsCurrent = buffer.Dequeue();
            mormalMonthlyPayload.SetFlagsCurrentMonth(flagsCurrentMonth.Flags2String());
            mormalMonthlyPayload.SetFlagsCurrentDay(flagsCurrentDay.Flags2String());
            mormalMonthlyPayload.SetFlagsCurrent(flagsCurrent.Flags2String());

            Byte[] monthlyVolumeByte = buffer.DequeueChunk(4).ToArray();
            Int32 monthlyVolume = BitConverter.ToInt32(monthlyVolumeByte, 0);
            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp1.UnixTimeStampToDateTime(),
                Volume = monthlyVolume,
            };
            mormalMonthlyPayload.SetMonthlyVolume(volume);

            return mormalMonthlyPayload;
        }
    }
}