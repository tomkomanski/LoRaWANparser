using System;
using LoRaWANparser.ApatorInvonic2.Extensions;
using LoRaWANparser.ApatorInvonic2.Models;
using LoRaWANparser.ApatorInvonic2.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.ApatorInvonic2.Parsers
{
    internal sealed class BasicWithHeatingEnergyParser : IPartialParser
    {
        private static BasicWithHeatingEnergyParser? instance;

        public static BasicWithHeatingEnergyParser GetParser()
        {
            if (instance == null)
            {
                instance = new BasicWithHeatingEnergyParser();
            }
            return instance;
        }

        private BasicWithHeatingEnergyParser()
        {
        }

        public ParsedData Decoder(Byte[] bufferBytes)
        {
            BasicWithHeatingEnergy decoded = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(bufferBytes);

            Byte[] timeStampBytes = buffer.DequeueChunk(4).ToArray();
            Int64 unixTimeStamp = BitConverter.ToInt32(timeStampBytes, 0);
            decoded.SetTimeStamp(unixTimeStamp.UnixTimeStampToDateTime());

            Byte errorCodeByte = buffer.DequeueChunk(1).ToArray()[0];
            decoded.SetDeviceErrorCode(errorCodeByte.ByteToDeviceErrorCode());

            Byte[] energyByte = buffer.DequeueChunk(4).ToArray();
            decoded.SetEnergy(BitConverter.ToInt32(energyByte, 0));

            Byte[] volumeByte = buffer.DequeueChunk(4).ToArray();
            decoded.SetVolume(BitConverter.ToInt32(volumeByte, 0));

            Byte[] energyOfThePastPeriod1Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetEnergyOfThePastPeriod1(BitConverter.ToInt32(energyOfThePastPeriod1Bytes, 0));

            Byte[] volumeOfThePastPeriod1Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetVolumeOfThePastPeriod1(BitConverter.ToInt32(volumeOfThePastPeriod1Bytes, 0));

            Byte[] energyOfThePastPeriod2Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetEnergyOfThePastPeriod2(BitConverter.ToInt32(energyOfThePastPeriod2Bytes, 0));

            Byte[] volumeOfThePastPeriod2Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetVolumeOfThePastPeriod2(BitConverter.ToInt32(volumeOfThePastPeriod2Bytes, 0));

            Byte[] energyOfThePastPeriod3Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetEnergyOfThePastPeriod3(BitConverter.ToInt32(energyOfThePastPeriod3Bytes, 0));

            Byte[] volumeOfThePastPeriod3Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetVolumeOfThePastPeriod3(BitConverter.ToInt32(volumeOfThePastPeriod3Bytes, 0));

            Byte[] periodBetweenPastValuesBytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetPeriodBetweenPastValues(BitConverter.ToInt32(periodBetweenPastValuesBytes, 0));

            return decoded;
        }
    }
}