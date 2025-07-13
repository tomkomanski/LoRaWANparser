using System;
using LoRaWANparser.ApatorUltrimis.Extensions;
using LoRaWANparser.ApatorUltrimis.Models;
using LoRaWANparser.ApatorUltrimis.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.ApatorUltrimis.Parsers
{
    internal sealed class NormalPayload14hParser : IPartialParser
    {
        private const Int32 TIME_RESOLUTION = 3600;
        private static NormalPayload14hParser? instance;

        public static NormalPayload14hParser GetParser()
        {
            if (instance == null)
            {
                instance = new NormalPayload14hParser();
            }
            return instance;
        }

        private NormalPayload14hParser()
        {
        }

        public Payload Decoder(Byte[] bufferBytes)
        {
            NormalPayload14h normalPayload = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(bufferBytes);

            Byte[] timestampByte = buffer.DequeueChunk(4).ToArray();
            Int64 unix_timestamp1 = BitConverter.ToInt32(timestampByte, 0);

            normalPayload.SetTimeStamp(unix_timestamp1.UnixTimeStampToDateTime());

            Int64 unix_timestamp2 = unix_timestamp1 - TIME_RESOLUTION;
            Int64 unix_timestamp3 = unix_timestamp2 - TIME_RESOLUTION;
            Int64 unix_timestamp4 = unix_timestamp3 - TIME_RESOLUTION;
            Int64 unix_timestamp5 = unix_timestamp4 - TIME_RESOLUTION;
            Int64 unix_timestamp6 = unix_timestamp5 - TIME_RESOLUTION;
            Int64 unix_timestamp7 = unix_timestamp6 - TIME_RESOLUTION;
            Int64 unix_timestamp8 = unix_timestamp7 - TIME_RESOLUTION;
            Int64 unix_timestamp9 = unix_timestamp8 - TIME_RESOLUTION;
            Int64 unix_timestamp10 = unix_timestamp9 - TIME_RESOLUTION;
            Int64 unix_timestamp11 = unix_timestamp10 - TIME_RESOLUTION;
            Int64 unix_timestamp12 = unix_timestamp11 - TIME_RESOLUTION;
            Int64 unix_timestamp13 = unix_timestamp12 - TIME_RESOLUTION;
            Int64 unix_timestamp14 = unix_timestamp13 - TIME_RESOLUTION;

            Byte[] meterSNBytes = buffer.DequeueChunk(4).ToArray();
            Array.Reverse(meterSNBytes);
            normalPayload.SetMeterSN(Convert.ToHexString(meterSNBytes));

            Byte[] reverseVolumeByte = buffer.DequeueChunk(4).ToArray();
            Int32 reverseVolume = BitConverter.ToInt32(reverseVolumeByte, 0);
            TimeStampVolume volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp1.UnixTimeStampToDateTime(),
                Volume = reverseVolume
            };
            normalPayload.SetReverseVolume(volume);

            Byte flagsCurrentMonth = buffer.Dequeue();
            Byte flagsCurrentDay = buffer.Dequeue();
            Byte flagsCurrent = buffer.Dequeue();
            normalPayload.SetFlagsCurrentMonth(flagsCurrentMonth.Flags2String());
            normalPayload.SetFlagsCurrentDay(flagsCurrentDay.Flags2String());
            normalPayload.SetFlagsCurrent(flagsCurrent.Flags2String());

            Byte[] volume1Bytes = buffer.DequeueChunk(4).ToArray();
            Int32 volume1 = BitConverter.ToInt32(volume1Bytes, 0);

            Byte[] volume2Bytes = buffer.DequeueChunk(2).ToArray();
            Int32 volume2 = volume1 - BitConverter.ToInt16(volume2Bytes, 0);

            Byte[] volume3Bytes = buffer.DequeueChunk(2).ToArray();
            Int32 volume3 = volume2 - BitConverter.ToInt16(volume3Bytes, 0);

            Byte[] volume4Bytes = buffer.DequeueChunk(2).ToArray();
            Int32 volume4 = volume3 - BitConverter.ToInt16(volume4Bytes, 0);

            Byte[] volume5Bytes = buffer.DequeueChunk(2).ToArray();
            Int32 volume5 = volume4 - BitConverter.ToInt16(volume5Bytes, 0);

            Byte[] volume6Bytes = buffer.DequeueChunk(2).ToArray();
            Int32 volume6 = volume5 - BitConverter.ToInt16(volume6Bytes, 0);

            Byte[] volume7Bytes = buffer.DequeueChunk(2).ToArray();
            Int32 volume7 = volume6 - BitConverter.ToInt16(volume7Bytes, 0);

            Byte[] volume8Bytes = buffer.DequeueChunk(2).ToArray();
            Int32 volume8 = volume7 - BitConverter.ToInt16(volume8Bytes, 0);

            Byte[] volume9Bytes = buffer.DequeueChunk(2).ToArray();
            Int32 volume9 = volume8 - BitConverter.ToInt16(volume9Bytes, 0);

            Byte[] volume10Bytes = buffer.DequeueChunk(2).ToArray();
            Int32 volume10 = volume9 - BitConverter.ToInt16(volume10Bytes, 0);

            Byte[] volume11Bytes = buffer.DequeueChunk(2).ToArray();
            Int32 volume11 = volume10 - BitConverter.ToInt16(volume11Bytes, 0);

            Byte[] volume12Bytes = buffer.DequeueChunk(2).ToArray();
            Int32 volume12 = volume11 - BitConverter.ToInt16(volume12Bytes, 0);

            Byte[] volume13Bytes = buffer.DequeueChunk(2).ToArray();
            Int32 volume13 = volume12 - BitConverter.ToInt16(volume13Bytes, 0);

            Byte[] volume14Bytes = buffer.DequeueChunk(2).ToArray();
            Int32 volume14 = volume13 - BitConverter.ToInt16(volume14Bytes, 0);

            List<TimeStampVolume> volumes = new();
            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp1.UnixTimeStampToDateTime(),
                Volume = volume1
            };
            volumes.Add(volume);

            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp2.UnixTimeStampToDateTime(),
                Volume = volume2
            };
            volumes.Add(volume);

            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp3.UnixTimeStampToDateTime(),
                Volume = volume3
            };
            volumes.Add(volume);

            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp4.UnixTimeStampToDateTime(),
                Volume = volume4
            };
            volumes.Add(volume);

            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp5.UnixTimeStampToDateTime(),
                Volume = volume5
            };
            volumes.Add(volume);

            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp6.UnixTimeStampToDateTime(),
                Volume = volume6
            };
            volumes.Add(volume);

            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp7.UnixTimeStampToDateTime(),
                Volume = volume7
            };
            volumes.Add(volume);

            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp8.UnixTimeStampToDateTime(),
                Volume = volume8
            };
            volumes.Add(volume);

            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp9.UnixTimeStampToDateTime(),
                Volume = volume9
            };
            volumes.Add(volume);

            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp10.UnixTimeStampToDateTime(),
                Volume = volume10
            };
            volumes.Add(volume);

            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp11.UnixTimeStampToDateTime(),
                Volume = volume11

            };
            volumes.Add(volume);

            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp12.UnixTimeStampToDateTime(),
                Volume = volume12
            };
            volumes.Add(volume);

            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp13.UnixTimeStampToDateTime(),
                Volume = volume13
            };
            volumes.Add(volume);

            volume = new TimeStampVolume()
            {
                Timestamp = unix_timestamp14.UnixTimeStampToDateTime(),
                Volume = volume14
            };
            volumes.Add(volume);

            normalPayload.SetVolume(volumes);

            return normalPayload;
        }
    }
}