using System;
using LoRaWANparser.MClimateCO2Display;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.Tools;

String frame = "21-00-52-01-02-3A-6C-0A-66-CD-08-00-0A-00";

IParser parser = new Parser();
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