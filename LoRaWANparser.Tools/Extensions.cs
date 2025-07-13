using System;
using System.Text.RegularExpressions;

namespace LoRaWANparser.Tools
{
    public static class Extensions
    {
        public static IEnumerable<Byte> HexStringToHexByte(this String hexString)
        {
            List<Byte> byteList = new();

            if (!String.IsNullOrEmpty(hexString))
            {
                String hex = hexString.Replace("-", String.Empty).Replace(" ", String.Empty);
                if (hex.Count() % 2 == 0)
                {
                    Boolean isHexString = Regex.IsMatch(hex, @"\A\b[0-9a-fA-F]+\b\Z");
                    if (isHexString)
                    {
                        Int32 hexBytesInString = hex.Count();

                        for (Int32 i = 0; i < hexBytesInString; i += 2)
                        {
                            Byte hexByte = Convert.ToByte($"0x{hex.Substring(i, 2)}", 16);
                            byteList.Add(hexByte);
                        }
                    }
                }
            }

            return byteList;
        }

        public static void EnqueueChunk<T>(this Queue<T> queue, IEnumerable<T> items)
        {
            if (queue != null)
            {
                foreach (T obj in items)
                {
                    queue.Enqueue(obj);
                }
            }
        }

        public static IEnumerable<T> DequeueChunk<T>(this Queue<T> queue, Int32 chunkSize)
        {
            List<T> result = new();

            if (queue != null)
            {
                for (Int32 i = 0; i < chunkSize && queue.Count > 0; i++)
                {
                    result.Add(queue.Dequeue());
                }
            }

            return result;
        }

        public static String TrimEnd(this String input, String suffixToRemove, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            if (suffixToRemove != null && input.EndsWith(suffixToRemove, comparisonType))
            {
                return input.Substring(0, input.Length - suffixToRemove.Length);
            }

            return input;
        }

        public static DateTime UnixTimeStampToDateTime(this Int64 unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp);
            return dateTime;
        }

        public static Int64 BCDToInt64(this IEnumerable<Byte> data)
        {
            Int64 val = 0;

            if (data != null && data.Any())
            {
                Byte[] dataBytes = data.ToArray();

                Int32 length = dataBytes.Count();

                for (Int32 i = length; i > 0; i--)
                {
                    val = val * 10 + (dataBytes[i - 1] >> 4 & 0xF);
                    val = val * 10 + (dataBytes[i - 1] & 0xF);
                }
            }

            return val;
        }

        public static Byte[] CalculateCrc16(this IEnumerable<Byte> data)
        {
            Byte[] crc = new Byte[2];

            if (data != null && data.Any())
            {
                Byte[] dataByte = data.ToArray();
                Int32 poly = 0x3D65;
                Int32 crcVal = 0x0000;
                Int32 xorValue = 0xFFFF;
                Int32 i;

                foreach (Byte b in dataByte)
                {
                    for (i = 0x80; i != 0; i >>= 1)
                    {
                        if ((crcVal & 0x8000) != 0)
                        {
                            crcVal = crcVal << 1 ^ poly;
                        }
                        else
                        {
                            crcVal = crcVal << 1;
                        }
                        if ((b & i) != 0)
                        {
                            crcVal ^= poly;
                        }
                    }
                }

                Byte[] tmpCrc = BitConverter.GetBytes(crcVal & 0xffff ^ xorValue);

                crc[0] = tmpCrc[1];
                crc[1] = tmpCrc[0];
            }

            return crc;
        }
    }
}