using System;
using System.Globalization;
using LoRaWANparser.ApatorUltrimis.Enums;
using LoRaWANparser.ApatorUltrimis.Models;

namespace LoRaWANparser.ApatorUltrimis.Test
{
    [TestClass]
    public sealed class LoRaWANparser
    {
        [DataTestMethod]
        [DataRow(
         "00c16c2c645312009000000000044c0c7d0a0000000000000000000000000000000000005a02cc000000000000009e73"
         )]
        public void NormalPayload14hFrame1(String frame)
        {
            ParserErrorCode parserErrorCode = ParserErrorCode.NoError;
            Nullable<Byte> version = 0;
            Nullable<Byte> extVersion = null;
            PayloadType payloadType = PayloadType.Normal;
            LogType logType = LogType.Hourly_14;
            DeviceType deviceType = DeviceType.Ultrimis;
            Unit unit = Unit.Liters;
            Nullable<Byte> encryption = 0;
            Boolean isDatagramLengthCorrect = true;
            List<DeviceFlag> flagsCurrent = new();
            flagsCurrent.Add(DeviceFlag.Dry);
            flagsCurrent.Add(DeviceFlag.AbsenceOfFlow);
            List<DeviceFlag> flagsCurrentDay = new();
            flagsCurrentDay.Add(DeviceFlag.Dry);
            flagsCurrentDay.Add(DeviceFlag.AbsenceOfFlow);
            flagsCurrentDay.Add(DeviceFlag.ReverseFlow);
            List<DeviceFlag> flagsCurrentMonth = new();
            flagsCurrentMonth.Add(DeviceFlag.Dry);
            DateTime timeStamp = DateTime.ParseExact("2023-04-04 18:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            String meterSn = "90001253";
            TimeStampVolume reverseVolume = new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 18:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 0
            };
            List<TimeStampVolume> volume = new();
            volume.Add(new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 18:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 2685
            });
            volume.Add(new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 17:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 2685
            });
            volume.Add(new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 16:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 2685
            });
            volume.Add(new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 15:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 2685
            });
            volume.Add(new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 14:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 2685
            });
            volume.Add(new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 13:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 2685
            });
            volume.Add(new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 12:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 2685
            });
            volume.Add(new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 11:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 2685
            });
            volume.Add(new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 10:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 2685
            });
            volume.Add(new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 09:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 2083
            });
            volume.Add(new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 08:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 1879
            });
            volume.Add(new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 07:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 1879
            });
            volume.Add(new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 06:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 1879
            });
            volume.Add(new()
            {
                Timestamp = DateTime.ParseExact("2023-04-04 05:30:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Volume = 1879
            });

            IParser parser = new Parser();
            NormalPayload14h normalPayload14h = (NormalPayload14h)parser.Process(frame);

            Assert.IsTrue(normalPayload14h.ParserErrorCode == parserErrorCode);
            Assert.IsTrue(normalPayload14h.Version == version);
            Assert.IsTrue(normalPayload14h.ExtVersion == extVersion);
            Assert.IsTrue(normalPayload14h.PayloadType == payloadType);
            Assert.IsTrue(normalPayload14h.LogType == logType);
            Assert.IsTrue(normalPayload14h.DeviceType == deviceType);
            Assert.IsTrue(normalPayload14h.Unit == unit);
            Assert.IsTrue(normalPayload14h.Encryption == encryption);
            Assert.IsTrue(normalPayload14h.IsDatagramLengthCorrect == isDatagramLengthCorrect);

            if (normalPayload14h.FlagsCurrent.Count() == 2)
            {
                Assert.IsTrue(normalPayload14h.FlagsCurrent.ToArray()[0] == flagsCurrent[0] &&
                              normalPayload14h.FlagsCurrent.ToArray()[1] == flagsCurrent[1]);
            }
            else
            {
                Assert.IsTrue(false);
            }

            if (normalPayload14h.FlagsCurrentDay.Count() == 3)
            {
                Assert.IsTrue(normalPayload14h.FlagsCurrentDay.ToArray()[0] == flagsCurrentDay[0] &&
                              normalPayload14h.FlagsCurrentDay.ToArray()[1] == flagsCurrentDay[1] &&
                              normalPayload14h.FlagsCurrentDay.ToArray()[2] == flagsCurrentDay[2]);
            }
            else
            {
                Assert.IsTrue(false);
            }

            if (normalPayload14h.FlagsCurrentMonth.Count() == 1)
            {
                Assert.IsTrue(normalPayload14h.FlagsCurrentMonth.ToArray()[0] == flagsCurrentMonth[0]);
            }
            else
            {
                Assert.IsTrue(false);
            }

            Assert.IsTrue(normalPayload14h.TimeStamp == timeStamp);
            Assert.IsTrue(normalPayload14h.MeterSn == meterSn);
            Assert.IsTrue(normalPayload14h.ReverseVolume.Timestamp == reverseVolume.Timestamp &&
                          normalPayload14h.ReverseVolume.Volume == reverseVolume.Volume);

            if (normalPayload14h.Volume.Count() == 14)
            {
                for (Int32 i = 0; i < 14; i++)
                {
                    Assert.IsTrue(normalPayload14h.Volume.ToArray()[i].Timestamp == volume[i].Timestamp &&
                                  normalPayload14h.Volume.ToArray()[i].Volume == volume[i].Volume);
                }
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
    }
}