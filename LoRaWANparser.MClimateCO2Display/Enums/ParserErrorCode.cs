using System;

namespace LoRaWANparser.MClimateCO2Display.Enums
{
    public enum ParserErrorCode
    {
        UnknownError,
        IncorrectFrame,
        UnknownFrame
    }

    public static class ParserErrorCodeDescriptor
    {
        public static String GetDescriptor(this ParserErrorCode parserErrorCode)
        {
            switch (parserErrorCode)
            {
                case ParserErrorCode.UnknownError:
                    return "Unknown error";

                case ParserErrorCode.IncorrectFrame:
                    return "Incorrect frame";

                case ParserErrorCode.UnknownFrame:
                    return "Unknown frame";

                default:
                    return "Unknown parser error code";
            }
        }
    }
}