using System;

namespace LoRaWANparser.ApatorUltrimis.Enums
{
    public enum ParserErrorCode
    {
        Unknown,
        NoError,
        Invalid_frame_string,
        Crc_error
    }

    public static class ParserErrorCodeDescriptor
    {
        public static String GetDescriptor(this ParserErrorCode parserErrorCode)
        {
            switch (parserErrorCode)
            {
                case ParserErrorCode.Unknown:
                    return "Unknown";

                case ParserErrorCode.NoError:
                    return "No error";

                case ParserErrorCode.Invalid_frame_string:
                    return "Invalid frame string";

                case ParserErrorCode.Crc_error:
                    return "CRC error";

                default:
                    return "Unknown parser error code";
            }
        }
    }
}