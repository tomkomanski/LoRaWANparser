using System;
using LoRaWANparser.ApatorUltrimis.Models;

namespace LoRaWANparser.ApatorUltrimis.Parsers.Interfaces
{
    internal interface IPartialParser
    {
        Payload Decoder(Byte[] bufferBytes);
    }
}