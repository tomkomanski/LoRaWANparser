using System;

namespace LoRaWANparser.ApatorInvonic2.Enums
{
    public enum ParserErrorCode
    {
        UnknownError,
        NoError,
        IncorrectFrame,
        IncorrectFrameLength,
    }

    public static class ParserErrorCodeDescriptor
    {
        public static String GetDescriptor(this ParserErrorCode parserErrorCode)
        {
            switch (parserErrorCode)
            {
                case ParserErrorCode.UnknownError:
                    return "Unknown error";

                case ParserErrorCode.NoError:
                    return "No error";

                case ParserErrorCode.IncorrectFrame:
                    return "Incorrect frame";

                case ParserErrorCode.IncorrectFrameLength:
                    return "Incorrect frame length";

                default:
                    return "Unknown parser error code";
            }
        }
    }
}