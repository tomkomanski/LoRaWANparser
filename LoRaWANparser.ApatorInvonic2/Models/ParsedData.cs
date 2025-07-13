using System;
using LoRaWANparser.ApatorInvonic2.Enums;

namespace LoRaWANparser.ApatorInvonic2.Models
{
    public class ParsedData
    {
        private ParserErrorCode parserErrorCode;
        private DeviceType deviceType;

        public ParserErrorCode ParserErrorCode
        {
            get
            {
                return this.parserErrorCode;
            }
        }

        public DeviceType DeviceType
        {
            get
            {
                return this.deviceType;
            }
        }

        public void SetParserErrorCode(ParserErrorCode parserErrorCode)
        {
            this.parserErrorCode = parserErrorCode;
        }

        public void SetDeviceType(DeviceType deviceType)
        {
            this.deviceType = deviceType;
        }
    }
}