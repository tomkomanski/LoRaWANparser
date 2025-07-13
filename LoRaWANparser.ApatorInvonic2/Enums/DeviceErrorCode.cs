using System;

namespace LoRaWANparser.ApatorInvonic2.Enums
{
    public enum DeviceErrorCode
    {
        UnknownError,
        NoError,
        PowerLow,
        PermanentError,
        EmptySpoolTemporaryError,
        PowerLowTemporaryErrorEmptySpool,
        EmptySpoolTemporaryErrorPermanentError,
        PowerLowPermanentErrorEmptySpoolTemporaryError
    }

    public static class DeviceErrorCodeDescriptor
    {
        public static String GetDescriptor(this DeviceErrorCode deviceErrorCode)
        {
            switch (deviceErrorCode)
            {
                case DeviceErrorCode.UnknownError:
                    return "Unknown error";

                case DeviceErrorCode.NoError:
                    return "No error";

                case DeviceErrorCode.PowerLow:
                    return "Power low";

                case DeviceErrorCode.PermanentError:
                    return "Permanent error";

                case DeviceErrorCode.EmptySpoolTemporaryError:
                    return "Empty spool + Temporary error";

                case DeviceErrorCode.PowerLowTemporaryErrorEmptySpool:
                    return "Power low + Temporary error + Empty spool";

                case DeviceErrorCode.EmptySpoolTemporaryErrorPermanentError:
                    return "Empty spool + Temporary error + Permanent error";

                case DeviceErrorCode.PowerLowPermanentErrorEmptySpoolTemporaryError:
                    return "Power low + Permanent error + Empty spool + Temporary error";

                default:
                    return "Unknown device error code";
            }
        }
    }
}