using System;
using LoRaWANparser.ApatorInvonic2.Models;

namespace LoRaWANparser.ApatorInvonic2.Parsers.Interfaces
{
    internal interface IPartialParser
    {
        ParsedData Decoder(Byte[] bufferBytes);
    }
}