using System;
using LoRaWANparser.ApatorInvonic2.Extensions;
using LoRaWANparser.ApatorInvonic2.Models;
using LoRaWANparser.ApatorInvonic2.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.ApatorInvonic2.Parsers
{
    internal sealed class BasicWithCoolingEnergyParser : IPartialParser
    {
        private static BasicWithCoolingEnergyParser? instance;

        public static BasicWithCoolingEnergyParser GetParser()
        {
            if (instance == null)
            {
                instance = new BasicWithCoolingEnergyParser();
            }
            return instance;
        }

        private BasicWithCoolingEnergyParser()
        {
        }

        public ParsedData Decoder(Byte[] bufferBytes)
        {
            BasicWithCoolingEnergy decoded = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(bufferBytes);

            Byte[] timeStampBytes = buffer.DequeueChunk(4).ToArray();
            Int64 unixTimeStamp = BitConverter.ToInt32(timeStampBytes, 0);
            decoded.SetTimeStamp(unixTimeStamp.UnixTimeStampToDateTime());

            Byte errorCodeByte = buffer.DequeueChunk(1).ToArray()[0];
            decoded.SetDeviceErrorCode(errorCodeByte.ByteToDeviceErrorCode());

            Byte[] energyForHeatingBytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetEnergyForHeating(BitConverter.ToInt32(energyForHeatingBytes, 0));

            Byte[] energyForCoolingBytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetEnergyForCooling(BitConverter.ToInt32(energyForCoolingBytes, 0));

            Byte[] volumeBytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetVolume(BitConverter.ToInt32(volumeBytes, 0));

            Byte[] energyForHeatingOfThePastPeriod1Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetEnergyForHeatingOfThePastPeriod1(BitConverter.ToInt32(energyForHeatingOfThePastPeriod1Bytes, 0));

            Byte[] energyForCoolingOfThePastPeriod1Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetEnergyForCoolingOfThePastPeriod1(BitConverter.ToInt32(energyForCoolingOfThePastPeriod1Bytes, 0));

            Byte[] volumeOfThePastPeriod1Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetVolumeOfThePastPeriod1(BitConverter.ToInt32(volumeOfThePastPeriod1Bytes, 0));

            Byte[] energyForHeatingOfThePastPeriod2Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetEnergyForHeatingOfThePastPeriod2(BitConverter.ToInt32(energyForHeatingOfThePastPeriod2Bytes, 0));

            Byte[] energyForCoolingOfThePastPeriod2Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetEnergyForCoolingOfThePastPeriod2(BitConverter.ToInt32(energyForCoolingOfThePastPeriod2Bytes, 0));

            Byte[] volumeOfThePastPeriod2Bytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetVolumeOfThePastPeriod2(BitConverter.ToInt32(volumeOfThePastPeriod2Bytes, 0));

            Byte[] periodBetweenPastValuesBytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetPeriodBetweenPastValues(BitConverter.ToInt32(periodBetweenPastValuesBytes, 0));

            return decoded;
        }
    }
}