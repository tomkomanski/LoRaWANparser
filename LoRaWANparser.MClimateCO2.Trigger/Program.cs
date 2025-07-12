using System;
using LoRaWANparser.MClimateCO2;
using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;
using LoRaWANparser.Tools;

String frame = "04-20-23-12-0A-1B-00-1F-03-84-05-DC-21-00-53-25-0A-0A-0A-23-00-0A-0A-29-00-02-00-00-15-03-03-00-01-92-03-00-00-01-92-01-04-77-02-5A-74-F4";

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