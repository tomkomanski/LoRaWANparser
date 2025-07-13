using System;
using System.Globalization;
using LoRaWANparser.ApatorInvonic2.Enums;
using LoRaWANparser.ApatorInvonic2.Models;

namespace LoRaWANparser.ApatorInvonic2.Test
{
    [TestClass]
    public sealed class LoRaWANparser
    {
        // Basic LT
        [DataTestMethod]
        [DataRow(
        "61a0426204240e00006e050000d8c503001700009906004e09d30834120000100e0000"
        )]
        public void BasicLTFrame1(String frame)
        {
            ParserErrorCode parserErrorCode = ParserErrorCode.NoError;
            DeviceType deviceType = DeviceType.BasicLT;
            DateTime timeStamp = DateTime.ParseExact("2022-03-29 06:00:01", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DeviceErrorCode deviceErrorCode = DeviceErrorCode.PowerLow;
            Int32 energyForHeatingOfThePastPeriod = 3620;
            Int32 energyForCoolingOfThePastPeriod = 1390;
            Double volumeOfThePastPeriod = 247.256;
            Double powerOfThePastPeriod = 1.7;
            Double flowOfThePastPeriod = 0.699;
            Double temperature1OfThePastPeriod = 23.82;
            Double temperature2OfThePastPeriod = 22.59;
            Int32 workingTimeWithoutError = 4660;
            Int32 periodBetweenPastValues = 3600;

            IParser parser = new Parser();
            ParsedData parsedData = parser.Process(frame);
            BasicLT basicLT = (BasicLT)parsedData;

            Assert.IsTrue(basicLT.ParserErrorCode == parserErrorCode);
            Assert.IsTrue(basicLT.DeviceType == deviceType);
            Assert.IsTrue(basicLT.TimeStamp == timeStamp);
            Assert.IsTrue(basicLT.ErrorCodes == deviceErrorCode);
            Assert.IsTrue(basicLT.EnergyForHeatingOfThePastPeriod == energyForHeatingOfThePastPeriod);
            Assert.IsTrue(basicLT.EnergyForCoolingOfThePastPeriod == energyForCoolingOfThePastPeriod);
            Assert.IsTrue(Math.Round((Double)basicLT.VolumeOfThePastPeriod * 0.001, 3) == volumeOfThePastPeriod);
            Assert.IsTrue(Math.Round((Double)basicLT.PowerOfThePastPeriod * 0.1, 3) == powerOfThePastPeriod);
            Assert.IsTrue(Math.Round((Double)basicLT.FlowOfThePastPeriod * 0.001, 3) == flowOfThePastPeriod);
            Assert.IsTrue(Math.Round((Double)basicLT.Temperature1OfThePastPeriod * 0.01, 3) == temperature1OfThePastPeriod);
            Assert.IsTrue(Math.Round((Double)basicLT.Temperature2OfThePastPeriod * 0.01, 3) == temperature2OfThePastPeriod);
            Assert.IsTrue(basicLT.WorkingTimeWithoutError == workingTimeWithoutError);
            Assert.IsTrue(basicLT.PeriodBetweenPastValues == periodBetweenPastValues);
        }

        // Basic with heating energy
        [DataTestMethod]
        [DataRow(
        "61a04262006e050000d8c503006d0500005ac503006d050000dcc403006c0500005dc40300100e0000"
        )]
        public void BasicWithHeatingEnergyFrame1(String frame)
        {
            ParserErrorCode parserErrorCode = ParserErrorCode.NoError;
            DeviceType deviceType = DeviceType.BasicWithHeatingEnergy;
            DateTime timeStamp = DateTime.ParseExact("2022-03-29 06:00:01", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DeviceErrorCode deviceErrorCode = DeviceErrorCode.NoError;
            Int32 energy = 1390;
            Double volume = 247.256;
            Int32 energyOfThePastPeriod1 = 1389;
            Double volumeOfThePastPeriod1 = 247.13;
            Int32 energyOfThePastPeriod2 = 1389;
            Double volumeOfThePastPeriod2 = 247.004;
            Int32 energyOfThePastPeriod3 = 1388;
            Double volumeOfThePastPeriod3 = 246.877;
            Int32 periodBetweenPastValues = 3600;

            IParser parser = new Parser();
            ParsedData parsedData = parser.Process(frame);
            BasicWithHeatingEnergy basicWithHeatingEnergy = (BasicWithHeatingEnergy)parsedData;

            Assert.IsTrue(basicWithHeatingEnergy.ParserErrorCode == parserErrorCode);
            Assert.IsTrue(basicWithHeatingEnergy.DeviceType == deviceType);
            Assert.IsTrue(basicWithHeatingEnergy.TimeStamp == timeStamp);
            Assert.IsTrue(basicWithHeatingEnergy.ErrorCodes == deviceErrorCode);
            Assert.IsTrue(basicWithHeatingEnergy.Energy == energy);
            Assert.IsTrue(Math.Round((Double)basicWithHeatingEnergy.Volume * 0.001, 3) == volume);
            Assert.IsTrue(basicWithHeatingEnergy.EnergyOfThePastPeriod1 == energyOfThePastPeriod1);
            Assert.IsTrue(Math.Round((Double)basicWithHeatingEnergy.VolumeOfThePastPeriod1 * 0.001, 3) == volumeOfThePastPeriod1);
            Assert.IsTrue(basicWithHeatingEnergy.EnergyOfThePastPeriod2 == energyOfThePastPeriod2);
            Assert.IsTrue(Math.Round((Double)basicWithHeatingEnergy.VolumeOfThePastPeriod2 * 0.001, 3) == volumeOfThePastPeriod2);
            Assert.IsTrue(basicWithHeatingEnergy.EnergyOfThePastPeriod3 == energyOfThePastPeriod3);
            Assert.IsTrue(Math.Round((Double)basicWithHeatingEnergy.VolumeOfThePastPeriod3 * 0.001, 3) == volumeOfThePastPeriod3);
            Assert.IsTrue(basicWithHeatingEnergy.PeriodBetweenPastValues == periodBetweenPastValues);
        }

        // Basic with cooling energy
        [DataTestMethod]
        [DataRow(
        "c46f0363008d020000000000003ba701008b020000000000006da6010089020000000000009fa50100c0120000"
        )]
        public void BasicWithCoolingEnergyFrame1(String frame)
        {
            ParserErrorCode parserErrorCode = ParserErrorCode.NoError;
            DeviceType deviceType = DeviceType.BasicWithCoolingEnergy;
            DateTime timeStamp = DateTime.ParseExact("2022-08-22 12:00:04", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DeviceErrorCode deviceErrorCode = DeviceErrorCode.NoError;
            Int32 energyForHeating = 653;
            Int32 energyForCooling = 0;
            Double volume = 108.347;
            Int32 energyForHeatingOfThePastPeriod1 = 651;
            Int32 energyForCoolingOfThePastPeriod1 = 0;
            Double volumeOfThePastPeriod1 = 108.141;
            Int32 energyForHeatingOfThePastPeriod2 = 649;
            Int32 energyForCoolingOfThePastPeriod2 = 0;
            Double volumeOfThePastPeriod2 = 107.935;
            Int32 periodBetweenPastValues = 4800;

            IParser parser = new Parser();
            ParsedData parsedData = parser.Process(frame);
            BasicWithCoolingEnergy basicWithCoolingEnergy = (BasicWithCoolingEnergy)parsedData;

            Assert.IsTrue(basicWithCoolingEnergy.ParserErrorCode == parserErrorCode);
            Assert.IsTrue(basicWithCoolingEnergy.DeviceType == deviceType);
            Assert.IsTrue(basicWithCoolingEnergy.TimeStamp == timeStamp);
            Assert.IsTrue(basicWithCoolingEnergy.ErrorCodes == deviceErrorCode);
            Assert.IsTrue(basicWithCoolingEnergy.EnergyForHeating == energyForHeating);
            Assert.IsTrue(basicWithCoolingEnergy.EnergyForCooling == energyForCooling);
            Assert.IsTrue(Math.Round((Double)basicWithCoolingEnergy.Volume * 0.001, 3) == volume);
            Assert.IsTrue(basicWithCoolingEnergy.EnergyForHeatingOfThePastPeriod1 == energyForHeatingOfThePastPeriod1);
            Assert.IsTrue(basicWithCoolingEnergy.EnergyForCoolingOfThePastPeriod1 == energyForCoolingOfThePastPeriod1);
            Assert.IsTrue(Math.Round((Double)basicWithCoolingEnergy.VolumeOfThePastPeriod1 * 0.001, 3) == volumeOfThePastPeriod1);
            Assert.IsTrue(basicWithCoolingEnergy.EnergyForHeatingOfThePastPeriod2 == energyForHeatingOfThePastPeriod2);
            Assert.IsTrue(basicWithCoolingEnergy.EnergyForCoolingOfThePastPeriod2 == energyForCoolingOfThePastPeriod2);
            Assert.IsTrue(Math.Round((Double)basicWithCoolingEnergy.VolumeOfThePastPeriod2 * 0.001, 3) == volumeOfThePastPeriod2);
            Assert.IsTrue(basicWithCoolingEnergy.PeriodBetweenPastValues == periodBetweenPastValues);
        }

        // Nordic
        [DataTestMethod]
        [DataRow(
        "a9ac0463801804630d070000ead10300100000260100df0b280900c70263f306000013c60300090000260100f50b450a"
        )]
        public void NordicWithHeatingEnergyFrame1(String frame)
        {
            ParserErrorCode parserErrorCode = ParserErrorCode.NoError;
            DeviceType deviceType = DeviceType.Nordic;
            DateTime timeStamp = DateTime.ParseExact("2022-08-23 10:32:09", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime dateAndTimeOfPastPeriod1 = DateTime.ParseExact("2022-08-23 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            Int32 energyOfThePastPeriod1 = 1805;
            Double volumeOfThePastPeriod1 = 250.346;
            Double powerOfThePastPeriod1 = 1.0;
            Double flowOfThePastPeriod1 = 0.126;
            Double temperature1OfThePastPeriod1 = 30.39;
            Double temperature2OfThePastPeriod1 = 23.44;
            DateTime dateAndTimeOfPastPeriod2 = DateTime.ParseExact("2022-08-22 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            Int32 energyOfThePastPeriod2 = 1779;
            Double volumeOfThePastPeriod2 = 247.315;
            Double powerOfThePastPeriod2 = 0.9;
            Double flowOfThePastPeriod2 = 0.126;
            Double temperature1OfThePastPeriod2 = 30.61;
            Double temperature2OfThePastPeriod2 = 26.29;

            IParser parser = new Parser();
            ParsedData parsedData = parser.Process(frame);
            Nordic nordic = (Nordic)parsedData;

            Assert.IsTrue(nordic.ParserErrorCode == parserErrorCode);
            Assert.IsTrue(nordic.DeviceType == deviceType);
            Assert.IsTrue(nordic.TimeStamp == timeStamp);
            Assert.IsTrue(nordic.DateAndTimeOfPastPeriod1 == dateAndTimeOfPastPeriod1);
            Assert.IsTrue(nordic.EnergyOfThePastPeriod1 == energyOfThePastPeriod1);
            Assert.IsTrue(Math.Round((Double)nordic.VolumeOfThePastPeriod1 * 0.001, 3) == volumeOfThePastPeriod1);
            Assert.IsTrue(Math.Round((Double)nordic.PowerOfThePastPeriod1 * 0.1, 3) == powerOfThePastPeriod1);
            Assert.IsTrue(Math.Round((Double)nordic.FlowOfThePastPeriod1 * 0.001, 3) == flowOfThePastPeriod1);
            Assert.IsTrue(Math.Round((Double)nordic.Temperature1OfThePastPeriod1 * 0.01, 3) == temperature1OfThePastPeriod1);
            Assert.IsTrue(Math.Round((Double)nordic.Temperature2OfThePastPeriod1 * 0.01, 3) == temperature2OfThePastPeriod1);
            Assert.IsTrue(nordic.DateAndTimeOfPastPeriod2 == dateAndTimeOfPastPeriod2);
            Assert.IsTrue(nordic.EnergyOfThePastPeriod2 == energyOfThePastPeriod2);
            Assert.IsTrue(Math.Round((Double)nordic.VolumeOfThePastPeriod2 * 0.001, 3) == volumeOfThePastPeriod2);
            Assert.IsTrue(Math.Round((Double)nordic.PowerOfThePastPeriod2 * 0.1, 3) == powerOfThePastPeriod2);
            Assert.IsTrue(Math.Round((Double)nordic.FlowOfThePastPeriod2 * 0.001, 3) == flowOfThePastPeriod2);
            Assert.IsTrue(Math.Round((Double)nordic.Temperature1OfThePastPeriod2 * 0.01, 3) == temperature1OfThePastPeriod2);
            Assert.IsTrue(Math.Round((Double)nordic.Temperature2OfThePastPeriod2 * 0.01, 3) == temperature2OfThePastPeriod2);
        }

        // Nordic with cooling energy
        [DataTestMethod]
        [DataRow(
        "a9ac0463801804630d0700000d040000ead10300100000140100da0a2809"
        )]
        public void NordicWithCoolingEnergyFrame1(String frame)
        {
            ParserErrorCode parserErrorCode = ParserErrorCode.NoError;
            DeviceType deviceType = DeviceType.NordicWithCoolingEnergy;
            DateTime timeStamp = DateTime.ParseExact("2022-08-23 10:32:09", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime dateAndTimeOfPastPeriod = DateTime.ParseExact("2022-08-23 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            Int32 energyForHeatingOfThePastPeriod = 1805;
            Int32 energyForCoolingOfThePastPeriod = 1037;
            Double volumeOfThePastPeriod = 250.346;
            Double powerOfThePastPeriod = 1.0;
            Double flowOfThePastPeriod = 0.114;
            Double temperature1OfThePastPeriod = 27.78;
            Double temperature2OfThePastPeriod = 23.44;

            IParser parser = new Parser();
            ParsedData parsedData = parser.Process(frame);
            NordicWithCoolingEnergy nordicWithCoolingEnergy = (NordicWithCoolingEnergy)parsedData;

            Assert.IsTrue(nordicWithCoolingEnergy.ParserErrorCode == parserErrorCode);
            Assert.IsTrue(nordicWithCoolingEnergy.DeviceType == deviceType);
            Assert.IsTrue(nordicWithCoolingEnergy.TimeStamp == timeStamp);
            Assert.IsTrue(nordicWithCoolingEnergy.DateAndTimeOfPastPeriod == dateAndTimeOfPastPeriod);
            Assert.IsTrue(nordicWithCoolingEnergy.EnergyForHeatingOfThePastPeriod == energyForHeatingOfThePastPeriod);
            Assert.IsTrue(nordicWithCoolingEnergy.EnergyForCoolingOfThePastPeriod == energyForCoolingOfThePastPeriod);
            Assert.IsTrue(Math.Round((Double)nordicWithCoolingEnergy.VolumeOfThePastPeriod * 0.001, 3) == volumeOfThePastPeriod);
            Assert.IsTrue(Math.Round((Double)nordicWithCoolingEnergy.PowerOfThePastPeriod * 0.1, 3) == powerOfThePastPeriod);
            Assert.IsTrue(Math.Round((Double)nordicWithCoolingEnergy.FlowOfThePastPeriod * 0.001, 3) == flowOfThePastPeriod);
            Assert.IsTrue(Math.Round((Double)nordicWithCoolingEnergy.Temperature1OfThePastPeriod * 0.01, 3) == temperature1OfThePastPeriod);
            Assert.IsTrue(Math.Round((Double)nordicWithCoolingEnergy.Temperature2OfThePastPeriod * 0.01, 3) == temperature2OfThePastPeriod);
        }
    }
}