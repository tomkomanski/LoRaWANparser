using System;
using LoRaWANparser.ApatorInvonic2.Enums;
using LoRaWANparser.ApatorInvonic2.Models;
using LoRaWANparser.ApatorInvonic2.Parsers;
using LoRaWANparser.ApatorInvonic2.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.ApatorInvonic2
{
    public class Parser : IParser
    {
        public Parser()
        {
        }

        public ParsedData Process(String hexFrame)
        {
            ParsedData parsedData = new();

            if (String.IsNullOrEmpty(hexFrame))
            {
                parsedData.SetParserErrorCode(ParserErrorCode.IncorrectFrame);
                parsedData.SetDeviceType(DeviceType.Unknown);
                return parsedData;
            }

            Byte[] bufferBytes = hexFrame.HexStringToHexByte().ToArray();

            if (!bufferBytes.Any())
            {
                parsedData.SetParserErrorCode(ParserErrorCode.IncorrectFrame);
                parsedData.SetDeviceType(DeviceType.Unknown);
                return parsedData;
            }

            if (bufferBytes.Count() == 35)
            {
                IPartialParser basicLTParser = BasicLTParser.GetParser();

                BasicLT basicLT = (BasicLT)basicLTParser.Decoder(bufferBytes);
                basicLT.SetParserErrorCode(ParserErrorCode.NoError);
                basicLT.SetDeviceType(DeviceType.BasicLT);

                return basicLT;
            }
            else if (bufferBytes.Count() == 41)
            {
                IPartialParser basicWithHeatingEnergyParser = BasicWithHeatingEnergyParser.GetParser();

                BasicWithHeatingEnergy basicWithHeatingEnergy = (BasicWithHeatingEnergy)basicWithHeatingEnergyParser.Decoder(bufferBytes);
                basicWithHeatingEnergy.SetParserErrorCode(ParserErrorCode.NoError);
                basicWithHeatingEnergy.SetDeviceType(DeviceType.BasicWithHeatingEnergy);

                return basicWithHeatingEnergy;
            }
            else if (bufferBytes.Count() == 45)
            {
                IPartialParser basicWithCoolingEnergyParser = BasicWithCoolingEnergyParser.GetParser();

                BasicWithCoolingEnergy basicWithCoolingEnergy = (BasicWithCoolingEnergy)basicWithCoolingEnergyParser.Decoder(bufferBytes);
                basicWithCoolingEnergy.SetParserErrorCode(ParserErrorCode.NoError);
                basicWithCoolingEnergy.SetDeviceType(DeviceType.BasicWithCoolingEnergy);

                return basicWithCoolingEnergy;
            }
            else if (bufferBytes.Count() == 48)
            {
                IPartialParser nordicParser = NordicParser.GetParser();

                Nordic nordic = (Nordic)nordicParser.Decoder(bufferBytes);
                nordic.SetParserErrorCode(ParserErrorCode.NoError);
                nordic.SetDeviceType(DeviceType.Nordic);

                return nordic;
            }
            else if (bufferBytes.Count() == 30)
            {
                IPartialParser nordicWithCoolingEnergyParser = NordicWithCoolingEnergyParser.GetParser();

                NordicWithCoolingEnergy nordicWithCoolingEnergy = (NordicWithCoolingEnergy)nordicWithCoolingEnergyParser.Decoder(bufferBytes);
                nordicWithCoolingEnergy.SetParserErrorCode(ParserErrorCode.NoError);
                nordicWithCoolingEnergy.SetDeviceType(DeviceType.NordicWithCoolingEnergy);

                return nordicWithCoolingEnergy;
            }
            else
            {
                parsedData.SetParserErrorCode(ParserErrorCode.NoError);
                parsedData.SetDeviceType(DeviceType.Unknown);
                return parsedData;
            }
        }
    }
}