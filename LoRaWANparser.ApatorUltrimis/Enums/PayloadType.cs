using System;

namespace LoRaWANparser.ApatorUltrimis.Enums
{
    public enum PayloadType
    {
        Unknown,
        Alarm,
        Normal
    }

    public static class PayloadTypeDescriptor
    {
        public static String GetDescriptor(this PayloadType payloadType)
        {
            switch (payloadType)
            {
                case PayloadType.Unknown:
                    return "Unknown";

                case PayloadType.Alarm:
                    return "Alarm";

                case PayloadType.Normal:
                    return "Normal";

                default:
                    return "Unknown payload type";
            }
        }
    }
}