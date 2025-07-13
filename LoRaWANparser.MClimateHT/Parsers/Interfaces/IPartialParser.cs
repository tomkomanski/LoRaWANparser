using System;
using LoRaWANparser.MClimateHT.Models;

namespace LoRaWANparser.MClimateHT.Parsers.Interfaces
{
    internal interface IPartialParser
    {
        ParsedData Process(IEnumerable<Byte> dataBytes);
    }
}