using LoRaWANparser.ApatorUltrimis.Enums;
using LoRaWANparser.ApatorUltrimis.Extensions;
using LoRaWANparser.ApatorUltrimis.Models;
using LoRaWANparser.ApatorUltrimis.Parsers;
using LoRaWANparser.ApatorUltrimis.Parsers.Interfaces;
using LoRaWANparser.Tools;
using System;

namespace LoRaWANparser.ApatorUltrimis
{
    public class Parser : IParser
    {
        public Parser()
        {
        }

        public Payload Process(String hexFrame)
        {
            Payload payload = new();

            if (String.IsNullOrEmpty(hexFrame))
            {
                payload.SetParserErrorCode(ParserErrorCode.Invalid_frame_string);
                payload.SetPayloadType(PayloadType.Unknown);
                payload.SetLogType(LogType.Unknown);
                payload.SetDeviceType(DeviceType.Unknown);
                payload.SetUnit(Unit.Unknown);
                return payload;
            }

            Byte[] bufferBytes = hexFrame.HexStringToHexByte().ToArray();

            if (!bufferBytes.Any())
            {
                payload.SetParserErrorCode(ParserErrorCode.Invalid_frame_string);
                payload.SetPayloadType(PayloadType.Unknown);
                payload.SetLogType(LogType.Unknown);
                payload.SetDeviceType(DeviceType.Unknown);
                payload.SetUnit(Unit.Unknown);
                return payload;
            }

            Byte[] bytesFrameForCrc = bufferBytes.SkipLast(2).ToArray();
            Byte[] calculatedCrc = bytesFrameForCrc.CalculateCrc16();
            Byte[] frameCrc = bufferBytes.Skip(bufferBytes.Count() - 2).ToArray();
            Array.Reverse(frameCrc);

            if (calculatedCrc[0] != frameCrc[0] || calculatedCrc[1] != frameCrc[1])
            {
                payload.SetParserErrorCode(ParserErrorCode.Crc_error);
                payload.SetPayloadType(PayloadType.Unknown);
                return payload;
            }

            payload.SetParserErrorCode(ParserErrorCode.NoError);

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(bufferBytes);

            Int32 length = buffer.Count();

            Byte version_byte = buffer.Dequeue();
            payload.SetVersion(version_byte);

            if ((version_byte & 0x80) != 0)
            {
                payload.SetExtVersion(buffer.Dequeue());
            }

            if ((version_byte & 0x40) != 0)
            {
                payload.SetPayloadType(PayloadType.Alarm);
            }
            else
            {
                payload.SetPayloadType(PayloadType.Normal);

                if ((version_byte & 0x03) == 0)
                {
                    payload.SetLogType(LogType.Hourly_14);
                }
                else if ((version_byte & 0x03) == 1)
                {
                    payload.SetLogType(LogType.Daily);
                }
                else if ((version_byte & 0x03) == 2)
                {
                    payload.SetLogType(LogType.Monthly);
                }
                else
                {
                    payload.SetLogType(LogType.Not_supported);
                }
            }

            if ((version_byte & 0x04) != 0)
            {
                payload.SetDeviceType(DeviceType.Unknown);
                return payload;
            }
            else
            {
                payload.SetDeviceType(DeviceType.Ultrimis);
            }

            Byte volumeScalePow = (Byte)(version_byte & 0x18);
            Unit unit = volumeScalePow.GetVolumeUnits();
            payload.SetUnit(unit);

            payload.SetEncryption((Byte)(version_byte & 0x20));

            if (payload.PayloadType == PayloadType.Alarm)
            {
                if (length == (Int32)DataTypeLength.tAlarm && payload.ExtVersion == null)
                {
                    payload.SetDatagramLengthCorrectFlag(true);
                }
                else if (length == ((Int32)DataTypeLength.tAlarm + 1) && payload.ExtVersion != null)
                {
                    payload.SetDatagramLengthCorrectFlag(true);
                }
                else
                {
                    payload.SetPayloadType(PayloadType.Unknown);
                    payload.SetDatagramLengthCorrectFlag(false);
                }
            }
            else if (payload.PayloadType == PayloadType.Normal)
            {
                if (payload.LogType == LogType.Hourly_14)
                {
                    if (length == (Int32)DataTypeLength.t14h && payload.ExtVersion == null)
                    {
                        payload.SetDatagramLengthCorrectFlag(true);
                    }
                    else if (length == ((Int32)DataTypeLength.t14h + 1) && payload.ExtVersion != null)
                    {
                        payload.SetDatagramLengthCorrectFlag(true);
                    }
                    else
                    {
                        payload.SetPayloadType(PayloadType.Unknown);
                        payload.SetDatagramLengthCorrectFlag(false);
                    }
                }
                else if (payload.LogType == LogType.Daily)
                {
                    if (length == (Int32)DataTypeLength.tDaily && payload.ExtVersion == null)
                    {
                        payload.SetDatagramLengthCorrectFlag(true);
                    }
                    else if (length == ((Int32)DataTypeLength.tDaily + 1) && payload.ExtVersion != null)
                    {
                        payload.SetDatagramLengthCorrectFlag(true);
                    }
                    else
                    {
                        payload.SetPayloadType(PayloadType.Unknown);
                        payload.SetDatagramLengthCorrectFlag(false);
                    }
                }
                else if (payload.LogType == LogType.Monthly)
                {
                    if (length == (Int32)DataTypeLength.tMonthly && payload.ExtVersion == null)
                    {
                        payload.SetDatagramLengthCorrectFlag(true);
                    }
                    else if (length == ((Int32)DataTypeLength.tMonthly + 1) && payload.ExtVersion != null)
                    {
                        payload.SetDatagramLengthCorrectFlag(true);
                    }
                    else
                    {
                        payload.SetPayloadType(PayloadType.Unknown);
                        payload.SetDatagramLengthCorrectFlag(false);
                    }
                }
                else
                {
                    payload.SetPayloadType(PayloadType.Unknown);
                    payload.SetDatagramLengthCorrectFlag(false);
                }
            }
            else
            {
                payload.SetPayloadType(PayloadType.Unknown);
                payload.SetDatagramLengthCorrectFlag(false);
            }

            if (!payload.IsDatagramLengthCorrect)
            {
                return payload;
            }

            if (payload.PayloadType == PayloadType.Alarm)
            {
                IPartialParser alarmPayloadParser = AlarmPayloadParser.GetParser();
                AlarmPayload alarmPayload = (AlarmPayload)alarmPayloadParser.Decoder(buffer.DequeueChunk(buffer.Count()).ToArray());
                alarmPayload.SetParserErrorCode(payload.ParserErrorCode);
                alarmPayload.SetVersion(payload.Version);
                alarmPayload.SetExtVersion(payload.ExtVersion);
                alarmPayload.SetPayloadType(payload.PayloadType);
                alarmPayload.SetLogType(payload.LogType);
                alarmPayload.SetDeviceType(payload.DeviceType);
                alarmPayload.SetUnit(payload.Unit);
                alarmPayload.SetEncryption(payload.Encryption);
                alarmPayload.SetDatagramLengthCorrectFlag(payload.IsDatagramLengthCorrect);

                return alarmPayload;
            }
            else if (payload.PayloadType == PayloadType.Normal && payload.LogType == LogType.Hourly_14)
            {
                IPartialParser normalPayload14hParser = NormalPayload14hParser.GetParser();
                NormalPayload14h normalPayload14h = (NormalPayload14h)normalPayload14hParser.Decoder(buffer.DequeueChunk(buffer.Count()).ToArray());
                normalPayload14h.SetParserErrorCode(payload.ParserErrorCode);
                normalPayload14h.SetVersion(payload.Version);
                normalPayload14h.SetExtVersion(payload.ExtVersion);
                normalPayload14h.SetPayloadType(payload.PayloadType);
                normalPayload14h.SetLogType(payload.LogType);
                normalPayload14h.SetDeviceType(payload.DeviceType);
                normalPayload14h.SetUnit(payload.Unit);
                normalPayload14h.SetEncryption(payload.Encryption);
                normalPayload14h.SetDatagramLengthCorrectFlag(payload.IsDatagramLengthCorrect);

                return normalPayload14h;
            }
            else if (payload.PayloadType == PayloadType.Normal && payload.LogType == LogType.Daily)
            {
                IPartialParser normalDailyPayloadParser = NormalDailyPayloadParser.GetParser();
                NormalDailyPayload normalDailyPayload = (NormalDailyPayload)normalDailyPayloadParser.Decoder(buffer.DequeueChunk(buffer.Count()).ToArray());
                normalDailyPayload.SetParserErrorCode(payload.ParserErrorCode);
                normalDailyPayload.SetVersion(payload.Version);
                normalDailyPayload.SetExtVersion(payload.ExtVersion);
                normalDailyPayload.SetPayloadType(payload.PayloadType);
                normalDailyPayload.SetLogType(payload.LogType);
                normalDailyPayload.SetDeviceType(payload.DeviceType);
                normalDailyPayload.SetUnit(payload.Unit);
                normalDailyPayload.SetEncryption(payload.Encryption);
                normalDailyPayload.SetDatagramLengthCorrectFlag(payload.IsDatagramLengthCorrect);

                return normalDailyPayload;
            }
            else if (payload.PayloadType == PayloadType.Normal && payload.LogType == LogType.Monthly)
            {
                IPartialParser normalMonthlyPayloadParser = NormalMonthlyPayloadParser.GetParser();
                NormalMonthlyPayload normalMonthlyPayload = (NormalMonthlyPayload)normalMonthlyPayloadParser.Decoder(buffer.DequeueChunk(buffer.Count()).ToArray());
                normalMonthlyPayload.SetParserErrorCode(payload.ParserErrorCode);
                normalMonthlyPayload.SetVersion(payload.Version);
                normalMonthlyPayload.SetExtVersion(payload.ExtVersion);
                normalMonthlyPayload.SetPayloadType(payload.PayloadType);
                normalMonthlyPayload.SetLogType(payload.LogType);
                normalMonthlyPayload.SetDeviceType(payload.DeviceType);
                normalMonthlyPayload.SetUnit(payload.Unit);
                normalMonthlyPayload.SetEncryption(payload.Encryption);
                normalMonthlyPayload.SetDatagramLengthCorrectFlag(payload.IsDatagramLengthCorrect);

                return normalMonthlyPayload;
            }

            return payload;
        }
    }
}