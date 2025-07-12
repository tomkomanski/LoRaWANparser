using System;
using LoRaWANparser.MClimateCO2Display.Models;

namespace LoRaWANparser.MClimateCO2Display.Parsers.Interfaces
{
    internal interface IPartialParser
    {
        ParsedData Process(IEnumerable<Byte> dataBytes);
    }
}