using System;
using LoRaWANparser.MClimateCO2Display.Models;

namespace LoRaWANparser.MClimateCO2Display
{
    public interface IParser
    {
        ParsedData Process(String hexFrame);
    }
}