using System;
using LoRaWANparser.ApatorInvonic2.Models;

namespace LoRaWANparser.ApatorInvonic2
{
    public interface IParser
    {
        ParsedData Process(String hexFrame);
    }
}