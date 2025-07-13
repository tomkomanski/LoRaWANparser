using System;
using LoRaWANparser.ApatorUltrimis;
using LoRaWANparser.ApatorUltrimis.Enums;
using LoRaWANparser.ApatorUltrimis.Models;

String hexFrame = "00c16c2c645312009000000000044c0c7d0a0000000000000000000000000000000000005a02cc000000000000009e73";
//String hexFrame = "00f17f34645312009000000000040c0c7d0a0000000000000000000000000000000000000000000000000000000065bf";
//String hexFrame = "00216c36645312009000000000040c0c7d0a00000000000000000000000000000000000000000000000000000000c151";

IParser parser = new Parser();
Payload payload = parser.Process(hexFrame);

if (payload is AlarmPayload alarmPayload)
{
    Console.WriteLine($"Parser error code: {alarmPayload.ParserErrorCode.GetDescriptor()}");
    Console.WriteLine($"Version: {alarmPayload.Version}");
    Console.WriteLine($"Extended version: {alarmPayload.ExtVersion}");
    Console.WriteLine($"Payload type: {alarmPayload.PayloadType.GetDescriptor()}");
    Console.WriteLine($"Log type: {alarmPayload.LogType.GetDescriptor()}");
    Console.WriteLine($"Device type: {alarmPayload.DeviceType.GetDescriptor()}");
    Console.WriteLine($"Unit: {alarmPayload.Unit.GetDescriptor()}");
    Console.WriteLine($"Encryption: {alarmPayload.Encryption}");
    Console.WriteLine($"Is length correct: {alarmPayload.IsDatagramLengthCorrect}");

    foreach (DeviceFlag item in alarmPayload.FlagsCurrent)
    {
        Console.WriteLine($"Flags current: {item.GetDescriptor()}");
    }
    foreach (DeviceFlag item in alarmPayload.FlagsCurrentDay)
    {
        Console.WriteLine($"Flags current day: {item.GetDescriptor()}");
    }
    foreach (DeviceFlag item in alarmPayload.FlagsCurrentMonth)
    {
        Console.WriteLine($"Flags current month: {item.GetDescriptor()}");
    }
    Console.WriteLine($"Time stamp: {alarmPayload.TimeStamp}");
    Console.WriteLine($"Meter serial number: {alarmPayload.MeterSn}");
}
else if (payload is NormalPayload14h normalPayload)
{
    String volumes = String.Empty;
    if (normalPayload.Volume.Any())
    {
        foreach (TimeStampVolume volume in normalPayload.Volume)
        {
            volumes += Environment.NewLine + volume.Timestamp + " " + volume.Volume;
        }
    }

    Console.WriteLine($"Parser error code: {normalPayload.ParserErrorCode.GetDescriptor()}");
    Console.WriteLine($"Version: {normalPayload.Version}");
    Console.WriteLine($"Extended version: {normalPayload.ExtVersion}");
    Console.WriteLine($"Payload type: {normalPayload.PayloadType.GetDescriptor()}");
    Console.WriteLine($"Log type: {normalPayload.LogType.GetDescriptor()}");
    Console.WriteLine($"Device type: {normalPayload.DeviceType.GetDescriptor()}");
    Console.WriteLine($"Unit: {normalPayload.Unit.GetDescriptor()}");
    Console.WriteLine($"Encryption: {normalPayload.Encryption}");
    Console.WriteLine($"Is length correct: {normalPayload.IsDatagramLengthCorrect}");

    foreach (DeviceFlag item in normalPayload.FlagsCurrent)
    {
        Console.WriteLine($"Flags current: {item.GetDescriptor()}");
    }
    foreach (DeviceFlag item in normalPayload.FlagsCurrentDay)
    {
        Console.WriteLine($"Flags current day: {item.GetDescriptor()}");
    }
    foreach (DeviceFlag item in normalPayload.FlagsCurrentMonth)
    {
        Console.WriteLine($"Flags current month: {item.GetDescriptor()}");
    }
    Console.WriteLine($"Time stamp: {normalPayload.TimeStamp}");
    Console.WriteLine($"Meter serial number: {normalPayload.MeterSn}");
    Console.WriteLine($"Reverse volume: {normalPayload.ReverseVolume.Timestamp} {normalPayload.ReverseVolume.Volume}");
    Console.WriteLine($"Volume: {volumes}");
}
else if (payload is NormalDailyPayload normalDailyPayload)
{
    Console.WriteLine($"Parser error code: {normalDailyPayload.ParserErrorCode.GetDescriptor()}");
    Console.WriteLine($"Version: {normalDailyPayload.Version}");
    Console.WriteLine($"Extended version: {normalDailyPayload.ExtVersion}");
    Console.WriteLine($"Payload type: {normalDailyPayload.PayloadType.GetDescriptor()}");
    Console.WriteLine($"Log type: {normalDailyPayload.LogType.GetDescriptor()}");
    Console.WriteLine($"Device type: {normalDailyPayload.DeviceType.GetDescriptor()}");
    Console.WriteLine($"Unit: {normalDailyPayload.Unit.GetDescriptor()}");
    Console.WriteLine($"Encryption: {normalDailyPayload.Encryption}");
    Console.WriteLine($"Is length correct: {normalDailyPayload.IsDatagramLengthCorrect}");

    foreach (DeviceFlag item in normalDailyPayload.FlagsCurrent)
    {
        Console.WriteLine($"Flags current: {item.GetDescriptor()}");
    }
    foreach (DeviceFlag item in normalDailyPayload.FlagsCurrentDay)
    {
        Console.WriteLine($"Flags current day: {item.GetDescriptor()}");
    }
    foreach (DeviceFlag item in normalDailyPayload.FlagsCurrentMonth)
    {
        Console.WriteLine($"Flags current month: {item.GetDescriptor()}");
    }
    Console.WriteLine($"Time stamp: {normalDailyPayload.TimeStamp}");
    Console.WriteLine($"Meter serial number: {normalDailyPayload.MeterSn}");
    Console.WriteLine($"Reverse volume: {normalDailyPayload.TimeStamp} {normalDailyPayload.DailyReverseVolume.Volume}");
    Console.WriteLine($"Volume: {normalDailyPayload.TimeStamp} {normalDailyPayload.DailyVolume.Volume}");
}
else if (payload is NormalMonthlyPayload normalMonthlyPayload)
{
    Console.WriteLine($"Parser error code: {normalMonthlyPayload.ParserErrorCode.GetDescriptor()}");
    Console.WriteLine($"Version: {normalMonthlyPayload.Version}");
    Console.WriteLine($"Extended version: {normalMonthlyPayload.ExtVersion}");
    Console.WriteLine($"Payload type: {normalMonthlyPayload.PayloadType.GetDescriptor()}");
    Console.WriteLine($"Log type: {normalMonthlyPayload.LogType.GetDescriptor()}");
    Console.WriteLine($"Device type: {normalMonthlyPayload.DeviceType.GetDescriptor()}");
    Console.WriteLine($"Unit: {normalMonthlyPayload.Unit.GetDescriptor()}");
    Console.WriteLine($"Encryption: {normalMonthlyPayload.Encryption}");
    Console.WriteLine($"Is length correct: {normalMonthlyPayload.IsDatagramLengthCorrect}");

    foreach (DeviceFlag item in normalMonthlyPayload.FlagsCurrent)
    {
        Console.WriteLine($"Flags current: {item.GetDescriptor()}");
    }
    foreach (DeviceFlag item in normalMonthlyPayload.FlagsCurrentDay)
    {
        Console.WriteLine($"Flags current day: {item.GetDescriptor()}");
    }
    foreach (DeviceFlag item in normalMonthlyPayload.FlagsCurrentMonth)
    {
        Console.WriteLine($"Flags current month: {item.GetDescriptor()}");
    }
    Console.WriteLine($"Time stamp: {normalMonthlyPayload.TimeStamp}");
    Console.WriteLine($"Meter serial number: {normalMonthlyPayload.MeterSn}");
    Console.WriteLine($"Reverse volume: {normalMonthlyPayload.TimeStamp} {normalMonthlyPayload.MonthlyReverseVolume.Volume}");
    Console.WriteLine($"Volume: {normalMonthlyPayload.TimeStamp} {normalMonthlyPayload.MonthlyVolume.Volume}");
}
else
{
    Console.WriteLine($"Parser error code: {payload.ParserErrorCode.GetDescriptor()}");
    Console.WriteLine($"Version: {payload.Version}");
    Console.WriteLine($"Extended version: {payload.ExtVersion}");
    Console.WriteLine($"Payload type: {payload.PayloadType.GetDescriptor()}");
    Console.WriteLine($"Log type: {payload.LogType.GetDescriptor()}");
    Console.WriteLine($"Device type: {payload.DeviceType.GetDescriptor()}");
    Console.WriteLine($"Unit: {payload.Unit.GetDescriptor()}");
    Console.WriteLine($"Encryption: {payload.Encryption}");
    Console.WriteLine($"Is length correct: {payload.IsDatagramLengthCorrect}");
}