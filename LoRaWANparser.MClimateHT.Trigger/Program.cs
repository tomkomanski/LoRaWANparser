using System;
using LoRaWANparser.MClimateHT;
using LoRaWANparser.MClimateHT.Enums;
using LoRaWANparser.MClimateHT.Models;
using LoRaWANparser.Tools;

String frame = "1209";

Parser parser = new();
ParsedData parsedData = parser.Process(frame);

String parserErrorCodeString = String.Empty;
foreach (ParserErrorCode parserErrorCode in parsedData.ParserErrorCode)
{
    parserErrorCodeString += $"{parserErrorCode.GetDescriptor()}, ";
}
parserErrorCodeString = parserErrorCodeString.TrimEnd(", ");

String commandTypeString = String.Empty;
foreach (CommandType commandType in parsedData.CommandType)
{
    commandTypeString += $"{commandType.GetDescriptor()}, ";
}
commandTypeString = commandTypeString.TrimEnd(", ");

Console.WriteLine($"Parser error: {parserErrorCodeString}");
Console.WriteLine($"Command type: {commandTypeString}");

foreach (Reading item in parsedData.Reading)
{
    if (item.ReadingValueType == ReadingValueType.Double)
    {
        Console.WriteLine($"{item.ParameterType.GetDescriptor()}: {item.Value} {item.Unit.GetDescriptor()}");
    }
    else if (item.ReadingValueType == ReadingValueType.String)
    {
        Console.WriteLine($"{item.ParameterType.GetDescriptor()}: {item.ValueString} {item.Unit.GetDescriptor()}");
    }
}