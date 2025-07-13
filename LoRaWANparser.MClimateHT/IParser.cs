using System;
using LoRaWANparser.MClimateHT.Models;

namespace LoRaWANparser.MClimateHT
{
    public interface IParser
    {
        ParsedData Process(String hexFrame);
    }
}