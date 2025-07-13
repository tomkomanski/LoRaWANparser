using System;
using LoRaWANparser.ApatorUltrimis.Models;

namespace LoRaWANparser.ApatorUltrimis
{
    public interface IParser
    {
        Payload Process(String hexFrame);
    }
}