using System;
using LoRaWANparser.MClimateCO2.Models;

namespace LoRaWANparser.MClimateCO2
{
    public interface IParser
    {
        ParsedData Process(String hexFrame);
    }
}