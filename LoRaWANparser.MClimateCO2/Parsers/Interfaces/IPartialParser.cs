using System;
using LoRaWANparser.MClimateCO2.Models;

namespace LoRaWANparser.MClimateCO2.Parsers.Interfaces
{
    internal interface IPartialParser
    {
        ParsedData Process(IEnumerable<Byte> dataBytes);
    }
}