using System;
using LoRaWANparser.ApatorInvonic2;
using LoRaWANparser.ApatorInvonic2.Enums;
using LoRaWANparser.ApatorInvonic2.Models;

// Basic LT
String frame = "61a0426204240e00006e050000d8c503001700009906004e09d30834120000100e0000";

// Basic with heating energy payload
//String frame = "61a04262006e050000d8c503006d0500005ac503006d050000dcc403006c0500005dc40300100e0000";

// Basic with cooling energy
//String frame = "c46f0363008d020000000000003ba701008b020000000000006da6010089020000000000009fa50100c0120000";

// Nordic
//String frame = "a9ac0463801804630d070000ead10300100000260100df0b280900c70263f306000013c60300090000260100f50b450a";

// Nordic with cooling energy
//String frame = "a9ac0463801804630d0700000d040000ead10300100000140100da0a2809";

IParser parser = new Parser();
ParsedData parsedData = parser.Process(frame);

if (parsedData is BasicLT basicLT)
{
    Console.WriteLine("Parser error: " + basicLT.ParserErrorCode.GetDescriptor());
    Console.WriteLine("Device type: " + basicLT.DeviceType.GetDescriptor());
    Console.WriteLine("TimeStamp: " + basicLT.TimeStamp);
    Console.WriteLine("Device error codes: " + basicLT.ErrorCodes.GetDescriptor());
    Console.WriteLine("Energy for heating of the past period: " + basicLT.EnergyForHeatingOfThePastPeriod + " kWh");
    Console.WriteLine("Energy for cooling of the past period: " + basicLT.EnergyForCoolingOfThePastPeriod + " kWh");
    Console.WriteLine("Volume of the past period: " + Math.Round((Double)basicLT.VolumeOfThePastPeriod * 0.001, 3) + " m\u00B3");
    Console.WriteLine("Power of the past period: " + Math.Round((Double)basicLT.PowerOfThePastPeriod * 0.1, 3) + " kW");
    Console.WriteLine("Flow of the past period: " + Math.Round((Double)basicLT.FlowOfThePastPeriod * 0.001, 3) + " m\u00B3/h");
    Console.WriteLine("Temperature 1 of the past period: " + Math.Round((Double)basicLT.Temperature1OfThePastPeriod * 0.01, 3) + " °C");
    Console.WriteLine("Temperature 2 of the past period: " + Math.Round((Double)basicLT.Temperature2OfThePastPeriod * 0.01, 3) + " °C"); ;
    Console.WriteLine("Working time without error: " + basicLT.WorkingTimeWithoutError + " s");
    Console.WriteLine("Period between past values (store period): " + basicLT.PeriodBetweenPastValues + " s");
}
else if (parsedData is BasicWithHeatingEnergy basicWithHeatingEnergy)
{
    Console.WriteLine("Parser error: " + basicWithHeatingEnergy.ParserErrorCode.GetDescriptor());
    Console.WriteLine("Device type: " + basicWithHeatingEnergy.DeviceType.GetDescriptor());
    Console.WriteLine("TimeStamp: " + basicWithHeatingEnergy.TimeStamp);
    Console.WriteLine("Device error codes: " + basicWithHeatingEnergy.ErrorCodes.GetDescriptor());
    Console.WriteLine("Energy: " + basicWithHeatingEnergy.Energy + " kWh");
    Console.WriteLine("Volume: " + Math.Round((Double)basicWithHeatingEnergy.Volume * 0.001, 3) + " m3");
    Console.WriteLine("Energy of the past period 1: " + basicWithHeatingEnergy.EnergyOfThePastPeriod1 + " kWh");
    Console.WriteLine("Volume of the past period 1: " + Math.Round((Double)basicWithHeatingEnergy.VolumeOfThePastPeriod1 * 0.001, 3) + " m\u00B3");
    Console.WriteLine("Energy of the past period 2: " + basicWithHeatingEnergy.EnergyOfThePastPeriod2 + " kWh");
    Console.WriteLine("Volume of the past period 2: " + Math.Round((Double)basicWithHeatingEnergy.VolumeOfThePastPeriod2 * 0.001, 3) + " m\u00B3");
    Console.WriteLine("Energy of the past period 3: " + basicWithHeatingEnergy.EnergyOfThePastPeriod3 + " kWh");
    Console.WriteLine("Volume of the past period 3: " + Math.Round((Double)basicWithHeatingEnergy.VolumeOfThePastPeriod3 * 0.001, 3) + " m\u00B3");
    Console.WriteLine("Period between past values: " + basicWithHeatingEnergy.PeriodBetweenPastValues + " s");
}
else if (parsedData is BasicWithCoolingEnergy basicWithCoolingEnergy)
{
    Console.WriteLine("Parser error: " + basicWithCoolingEnergy.ParserErrorCode.GetDescriptor());
    Console.WriteLine("Device type: " + basicWithCoolingEnergy.DeviceType.GetDescriptor());
    Console.WriteLine("TimeStamp: " + basicWithCoolingEnergy.TimeStamp);
    Console.WriteLine("Device error codes: " + basicWithCoolingEnergy.ErrorCodes.GetDescriptor());
    Console.WriteLine("Energy for heating: " + basicWithCoolingEnergy.EnergyForHeating + " kWh");
    Console.WriteLine("Energy for cooling: " + basicWithCoolingEnergy.EnergyForCooling + " kWh");
    Console.WriteLine("Volume: " + Math.Round((Double)basicWithCoolingEnergy.Volume * 0.001, 3) + " m\u00B3");
    Console.WriteLine("Energy for heating of the past period 1: " + basicWithCoolingEnergy.EnergyForHeatingOfThePastPeriod1 + " kWh");
    Console.WriteLine("Energy for cooling of the past period 1: " + basicWithCoolingEnergy.EnergyForCoolingOfThePastPeriod1 + " kWh");
    Console.WriteLine("Volume of the past period 1: " + Math.Round((Double)basicWithCoolingEnergy.VolumeOfThePastPeriod1 * 0.001, 3) + " m\u00B3");
    Console.WriteLine("Energy for heating of the past period 2: " + basicWithCoolingEnergy.EnergyForHeatingOfThePastPeriod2 + " kWh");
    Console.WriteLine("Energy for cooling of the past period 2: " + basicWithCoolingEnergy.EnergyForCoolingOfThePastPeriod2 + " kWh");
    Console.WriteLine("Volume of the past period 2: " + Math.Round((Double)basicWithCoolingEnergy.VolumeOfThePastPeriod2 * 0.001, 3) + " m\u00B3");
    Console.WriteLine("Period between past values: " + basicWithCoolingEnergy.PeriodBetweenPastValues + " s");
}
else if (parsedData is Nordic nordic)
{
    Console.WriteLine("Parser error: " + nordic.ParserErrorCode.GetDescriptor());
    Console.WriteLine("Device type: " + nordic.DeviceType.GetDescriptor());
    Console.WriteLine("TimeStamp: " + nordic.TimeStamp);
    Console.WriteLine("Date and time of past period 1: " + nordic.DateAndTimeOfPastPeriod1);
    Console.WriteLine("Energy of the past period 1: " + nordic.EnergyOfThePastPeriod1 + " kWh");
    Console.WriteLine("Volume of the past period 1: " + Math.Round((Double)nordic.VolumeOfThePastPeriod1 * 0.001, 3) + " m\u00B3");
    Console.WriteLine("Power of the past period 1: " + Math.Round((Double)nordic.PowerOfThePastPeriod1 * 0.1, 3) + " kW");
    Console.WriteLine("Flow of the past period 1: " + Math.Round((Double)nordic.FlowOfThePastPeriod1 * 0.001, 3) + " m\u00B3/h");
    Console.WriteLine("Temperature 1 of the past period 1: " + Math.Round((Double)nordic.Temperature1OfThePastPeriod1 * 0.01, 3) + " °C");
    Console.WriteLine("Temperature 2 of the past period 1: " + Math.Round((Double)nordic.Temperature2OfThePastPeriod1 * 0.01, 3) + " °C");
    Console.WriteLine("Date and time of past period 2: " + nordic.DateAndTimeOfPastPeriod2);
    Console.WriteLine("Energy of the past period 2: " + nordic.EnergyOfThePastPeriod2 + " kWh");
    Console.WriteLine("Volume of the past period 2: " + Math.Round((Double)nordic.VolumeOfThePastPeriod2 * 0.001, 3) + " m\u00B3");
    Console.WriteLine("Power of the past period 2: " + Math.Round((Double)nordic.PowerOfThePastPeriod2 * 0.1, 3) + " kW");
    Console.WriteLine("Flow of the past period 2: " + Math.Round((Double)nordic.FlowOfThePastPeriod2 * 0.001, 3) + " m\u00B3/h");
    Console.WriteLine("Temperature 1 of the past period 2: " + Math.Round((Double)nordic.Temperature1OfThePastPeriod2 * 0.01, 3) + " °C");
    Console.WriteLine("Temperature 2 of the past period 2: " + Math.Round((Double)nordic.Temperature2OfThePastPeriod2 * 0.01, 3) + " °C");
}
else if (parsedData is NordicWithCoolingEnergy nordicWithCoolingEnergy)
{
    Console.WriteLine("Parser error: " + nordicWithCoolingEnergy.ParserErrorCode.GetDescriptor());
    Console.WriteLine("Device type: " + nordicWithCoolingEnergy.DeviceType.GetDescriptor());
    Console.WriteLine("TimeStamp: " + nordicWithCoolingEnergy.TimeStamp);
    Console.WriteLine("Date and time of past period: " + nordicWithCoolingEnergy.DateAndTimeOfPastPeriod);
    Console.WriteLine("Energy for heating of the past period: " + nordicWithCoolingEnergy.EnergyForHeatingOfThePastPeriod + " kWh");
    Console.WriteLine("Energy for cooling of the past period: " + nordicWithCoolingEnergy.EnergyForCoolingOfThePastPeriod + " kWh");
    Console.WriteLine("Volume of the past period: " + Math.Round((Double)nordicWithCoolingEnergy.VolumeOfThePastPeriod * 0.001, 3) + " m\u00B3");
    Console.WriteLine("Power of the past period: " + Math.Round((Double)nordicWithCoolingEnergy.PowerOfThePastPeriod * 0.1, 3) + " kW");
    Console.WriteLine("Flow of the past period: " + Math.Round((Double)nordicWithCoolingEnergy.FlowOfThePastPeriod * 0.001, 3) + " m\u00B3/h");
    Console.WriteLine("Temperature 1 of the past period: " + Math.Round((Double)nordicWithCoolingEnergy.Temperature1OfThePastPeriod * 0.01, 3) + " °C");
    Console.WriteLine("Temperature 2 of the past period: " + Math.Round((Double)nordicWithCoolingEnergy.Temperature2OfThePastPeriod * 0.01, 3) + " °C");
}
else
{
    Console.WriteLine("Parser error: " + parsedData.ParserErrorCode.GetDescriptor());
    Console.WriteLine("Device type: " + parsedData.DeviceType.GetDescriptor());
}