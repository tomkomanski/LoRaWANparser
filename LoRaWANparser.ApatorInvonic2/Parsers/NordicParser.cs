using System;
using LoRaWANparser.ApatorInvonic2.Models;
using LoRaWANparser.ApatorInvonic2.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.ApatorInvonic2.Parsers
{
    internal sealed class NordicParser : IPartialParser
    {
        private static NordicParser? instance;

        public static NordicParser GetParser()
        {
            if (instance == null)
            {
                instance = new NordicParser();
            }
            return instance;
        }

        private NordicParser()
        {
        }

        public ParsedData Decoder(Byte[] bufferBytes)
        {
            Nordic decoded = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(bufferBytes);

            Byte[] timeStampBytes = buffer.DequeueChunk(4).ToArray();
            Int64 unixTimeStamp = BitConverter.ToInt32(timeStampBytes, 0);
            decoded.SetTimeStamp(unixTimeStamp.UnixTimeStampToDateTime());

            Byte[] dateAndTimeOfPastPeriod1Bytes = buffer.DequeueChunk(4).ToArray();
            Int64 unixTimeDateAndTimeOfPastPeriod1 = BitConverter.ToInt32(dateAndTimeOfPastPeriod1Bytes, 0);
            decoded.SetrDateAndTimeOfPastPeriod1(unixTimeDateAndTimeOfPastPeriod1.UnixTimeStampToDateTime());

            Byte[] energyForCoolingOfThePastPeriod1Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetEnergyOfThePastPeriod1(BitConverter.ToInt32(energyForCoolingOfThePastPeriod1Bytes, 0));

            Byte[] volumeOfThePastPeriod1Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetVolumeOfThePastPeriod1(BitConverter.ToInt32(volumeOfThePastPeriod1Bytes, 0));

            Byte[] powerOfThePastPeriod1Bytes = buffer.DequeueChunk(3).ToArray();
            decoded.SetPowerOfThePastPeriod1((Int32)powerOfThePastPeriod1Bytes.BCDToInt64());

            Byte[] flowOfThePastPeriod1Bytes = buffer.DequeueChunk(3).ToArray();
            decoded.SetFlowOfThePastPeriod1((Int32)flowOfThePastPeriod1Bytes.BCDToInt64());

            Byte[] temperature1OfThePastPeriod1Bytes = buffer.DequeueChunk(2).ToArray();
            decoded.SetTemperature1OfThePastPeriod1(BitConverter.ToInt16(temperature1OfThePastPeriod1Bytes, 0));

            Byte[] temperature2OfThePastPeriod1Bytes = buffer.DequeueChunk(2).ToArray();
            decoded.SetTemperature2OfThePastPeriod1(BitConverter.ToInt16(temperature2OfThePastPeriod1Bytes, 0));

            Byte[] dateAndTimeOfPastPeriod2Bytes = buffer.DequeueChunk(4).ToArray();
            Int64 unixTimeDateAndTimeOfPastPeriod2 = BitConverter.ToInt32(dateAndTimeOfPastPeriod2Bytes, 0);
            decoded.SetrDateAndTimeOfPastPeriod2(unixTimeDateAndTimeOfPastPeriod2.UnixTimeStampToDateTime());

            Byte[] energyForCoolingOfThePastPeriod2Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetEnergyOfThePastPeriod2(BitConverter.ToInt32(energyForCoolingOfThePastPeriod2Bytes, 0));

            Byte[] volumeOfThePastPeriod2Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetVolumeOfThePastPeriod2(BitConverter.ToInt32(volumeOfThePastPeriod2Bytes, 0));

            Byte[] powerOfThePastPeriod2Bytes = buffer.DequeueChunk(3).ToArray();
            decoded.SetPowerOfThePastPeriod2((Int32)powerOfThePastPeriod2Bytes.BCDToInt64());

            Byte[] flowOfThePastPeriod2Bytes = buffer.DequeueChunk(3).ToArray();
            decoded.SetFlowOfThePastPeriod2((Int32)flowOfThePastPeriod2Bytes.BCDToInt64());

            Byte[] temperature1OfThePastPeriod2Bytes = buffer.DequeueChunk(2).ToArray();
            decoded.SetTemperature1OfThePastPeriod2(BitConverter.ToInt16(temperature1OfThePastPeriod2Bytes, 0));

            Byte[] temperature2OfThePastPeriod2Bytes = buffer.DequeueChunk(2).ToArray();
            decoded.SetTemperature2OfThePastPeriod2(BitConverter.ToInt16(temperature2OfThePastPeriod2Bytes, 0));

            return decoded;
        }
    }
}