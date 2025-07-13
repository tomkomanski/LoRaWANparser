using System;
using LoRaWANparser.ApatorUltrimis.Enums;

namespace LoRaWANparser.ApatorUltrimis.Models
{
    public class Payload
    {
        private ParserErrorCode parserErrorCode;
        private Nullable<Byte> version;
        private Nullable<Byte> extVersion;
        private PayloadType payloadType;
        private LogType logType;
        private DeviceType deviceType;
        private Unit unit;
        private Nullable<Byte> encryption;
        private Boolean isDatagramLengthCorrect;

        public ParserErrorCode ParserErrorCode
        {
            get
            {
                return this.parserErrorCode;
            }
        }

        public Nullable<Byte> Version
        {
            get
            {
                return this.version;
            }
        }

        public Nullable<Byte> ExtVersion
        {
            get
            {
                return extVersion;
            }
        }

        public PayloadType PayloadType
        {
            get
            {
                return this.payloadType;
            }
        }

        public LogType LogType
        {
            get
            {
                return this.logType;
            }
        }

        public DeviceType DeviceType
        {
            get
            {
                return this.deviceType;
            }
        }

        public Unit Unit
        {
            get
            {
                return this.unit;
            }
        }

        public Nullable<Byte> Encryption
        {
            get
            {
                return this.encryption;
            }
        }

        public Boolean IsDatagramLengthCorrect
        {
            get
            {
                return this.isDatagramLengthCorrect;
            }
        }

        public void SetParserErrorCode(ParserErrorCode parserErrorCode)
        {
            this.parserErrorCode = parserErrorCode;
        }

        public void SetVersion(Nullable<Byte> version)
        {
            this.version = version;
        }

        public void SetExtVersion(Nullable<Byte> extVersion)
        {
            this.extVersion = extVersion;
        }

        public void SetPayloadType(PayloadType payloadType)
        {
            this.payloadType = payloadType;
        }

        public void SetLogType(LogType logType)
        {
            this.logType = logType;
        }

        public void SetDeviceType(DeviceType deviceType)
        {
            this.deviceType = deviceType;
        }

        public void SetUnit(Unit unit)
        {
            this.unit = unit;
        }

        public void SetEncryption(Nullable<Byte> encryption)
        {
            this.encryption = encryption;
        }

        public void SetDatagramLengthCorrectFlag(Boolean isDatagramLengthCorrect)
        {
            this.isDatagramLengthCorrect = isDatagramLengthCorrect;
        }
    }
}