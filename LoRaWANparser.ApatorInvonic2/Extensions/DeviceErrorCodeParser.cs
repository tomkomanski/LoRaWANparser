using System;
using LoRaWANparser.ApatorInvonic2.Enums;

namespace LoRaWANparser.ApatorInvonic2.Extensions
{
    public static class DeviceErrorCodeParser
    {
        public static DeviceErrorCode ByteToDeviceErrorCode(this Byte deviceErrorCodeByte)
        {
            if (deviceErrorCodeByte == (Byte)0x00)
            {
                return DeviceErrorCode.NoError;
            }
            else if (deviceErrorCodeByte == (Byte)0x04)
            {
                return DeviceErrorCode.PowerLow;
            }
            else if (deviceErrorCodeByte == (Byte)0x08)
            {
                return DeviceErrorCode.PermanentError;
            }
            else if (deviceErrorCodeByte == (Byte)0x10)
            {
                return DeviceErrorCode.EmptySpoolTemporaryError;
            }
            else if (deviceErrorCodeByte == (Byte)0x1)
            {
                return DeviceErrorCode.PowerLowTemporaryErrorEmptySpool;
            }
            else if (deviceErrorCodeByte == (Byte)0x18)
            {
                return DeviceErrorCode.EmptySpoolTemporaryErrorPermanentError;
            }
            else if (deviceErrorCodeByte == (Byte)0x1C)
            {
                return DeviceErrorCode.PowerLowPermanentErrorEmptySpoolTemporaryError;
            }
            else
            {
                return DeviceErrorCode.UnknownError;
            }
        }
    }
}