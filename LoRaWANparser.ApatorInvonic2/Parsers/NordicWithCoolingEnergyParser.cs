using System;
using LoRaWANparser.ApatorInvonic2.Models;
using LoRaWANparser.ApatorInvonic2.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.ApatorInvonic2.Parsers
{
    internal sealed class NordicWithCoolingEnergyParser : IPartialParser
    {
        private static NordicWithCoolingEnergyParser? instance;

        public static NordicWithCoolingEnergyParser GetParser()
        {
            if (instance == null)
            {
                instance = new NordicWithCoolingEnergyParser();
            }
            return instance;
        }

        private NordicWithCoolingEnergyParser()
        {
        }

        public ParsedData Decoder(Byte[] bufferBytes)
        {
            NordicWithCoolingEnergy decoded = new();

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(bufferBytes);

            Byte[] timeStampBytes = buffer.DequeueChunk(4).ToArray();
            Int64 unixTimeStamp = BitConverter.ToInt32(timeStampBytes, 0);
            decoded.SetTimeStamp(unixTimeStamp.UnixTimeStampToDateTime());

            Byte[] dateAndTimeOfPastPeriodBytes = buffer.DequeueChunk(4).ToArray();
            Int64 dateAndTimeOfPastPeriod = BitConverter.ToInt32(dateAndTimeOfPastPeriodBytes, 0);
            decoded.SetDateAndTimeOfPastPeriod(dateAndTimeOfPastPeriod.UnixTimeStampToDateTime());

            Byte[] energyForHeatingOfThePastPeriodBytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetEnergyForHeatingOfThePastPeriod(BitConverter.ToInt32(energyForHeatingOfThePastPeriodBytes, 0));

            Byte[] energyForCoolingOfThePastPeriodBytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetEnergyForCoolingOfThePastPeriod(BitConverter.ToInt32(energyForCoolingOfThePastPeriodBytes, 0));

            Byte[] volumeOfThePastPeriodBytes = buffer.DequeueChunk(4).ToArray();
            decoded.SetVolumeOfThePastPeriod(BitConverter.ToInt32(volumeOfThePastPeriodBytes, 0));

            Byte[] powerOfThePastPeriodBytes = buffer.DequeueChunk(3).ToArray();
            decoded.SetPowerOfThePastPeriod((Int32)powerOfThePastPeriodBytes.BCDToInt64());

            Byte[] flowOfThePastPeriodBytes = buffer.DequeueChunk(3).ToArray();
            decoded.SetFlowOfThePastPeriod((Int32)flowOfThePastPeriodBytes.BCDToInt64());

            Byte[] temperature1OfThePastPeriodBytes = buffer.DequeueChunk(2).ToArray();
            decoded.SetTemperature1OfThePastPeriod(BitConverter.ToInt16(temperature1OfThePastPeriodBytes, 0));

            Byte[] temperature2OfThePastPeriodBytes = buffer.DequeueChunk(2).ToArray();
            decoded.SetTemperature2OfThePastPeriod(BitConverter.ToInt16(temperature2OfThePastPeriodBytes, 0));

            return decoded;
        }
    }
}