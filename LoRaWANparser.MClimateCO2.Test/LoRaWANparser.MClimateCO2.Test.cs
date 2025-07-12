using System;
using LoRaWANparser.MClimateCO2.Enums;
using LoRaWANparser.MClimateCO2.Models;

namespace LoRaWANparser.MClimateCO2.Test
{
    [TestClass]
    public sealed class LoRaWANparser
    {
        [DataTestMethod]
        [DataRow(
        "01065c028c8bdf"
        )]
        public void Frame01(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.Double;
            String parameter1Type = "CO2";
            Double value1 = 1628;
            String unit1 = "ppm";
            ReadingValueType reading2ValueType = ReadingValueType.Double;
            String parameter2Type = "Internal temperature";
            Double value2 = 25.2;
            String unit2 = "°C";
            ReadingValueType reading3ValueType = ReadingValueType.Double;
            String parameter3Type = "Relative humidity";
            Double value3 = 54.29;
            String unit3 = "%";
            ReadingValueType reading4ValueType = ReadingValueType.Double;
            String parameter4Type = "Device battery voltage";
            Double value4 = 3384;
            String unit4 = "mV";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 4);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Keep-alive");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);

            Assert.IsTrue(parsedData.Reading.ToArray()[1].ReadingValueType == reading2ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].ParameterType.GetDescriptor() == parameter2Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Value == value2);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Unit.GetDescriptor() == unit2);

            Assert.IsTrue(parsedData.Reading.ToArray()[2].ReadingValueType == reading3ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].ParameterType.GetDescriptor() == parameter3Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].Value == value3);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].Unit.GetDescriptor() == unit3);

            Assert.IsTrue(parsedData.Reading.ToArray()[3].ReadingValueType == reading4ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].ParameterType.GetDescriptor() == parameter4Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].Value == value4);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].Unit.GetDescriptor() == unit4);
        }

        [DataTestMethod]
        [DataRow(
        "01ff1d026998fd"
        )]
        public void Frame02(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.Double;
            String parameter1Type = "CO2";
            Double value1 = 65309;
            String unit1 = "ppm";
            ReadingValueType reading2ValueType = ReadingValueType.Double;
            String parameter2Type = "Internal temperature";
            Double value2 = 21.7;
            String unit2 = "°C";
            ReadingValueType reading3ValueType = ReadingValueType.Double;
            String parameter3Type = "Relative humidity";
            Double value3 = 59.37;
            String unit3 = "%";
            ReadingValueType reading4ValueType = ReadingValueType.Double;
            String parameter4Type = "Device battery voltage";
            Double value4 = 3624;
            String unit4 = "mV";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 4);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Keep-alive");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);

            Assert.IsTrue(parsedData.Reading.ToArray()[1].ReadingValueType == reading2ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].ParameterType.GetDescriptor() == parameter2Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Value == value2);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Unit.GetDescriptor() == unit2);

            Assert.IsTrue(parsedData.Reading.ToArray()[2].ReadingValueType == reading3ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].ParameterType.GetDescriptor() == parameter3Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].Value == value3);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].Unit.GetDescriptor() == unit3);

            Assert.IsTrue(parsedData.Reading.ToArray()[3].ReadingValueType == reading4ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].ParameterType.GetDescriptor() == parameter4Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].Value == value4);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].Unit.GetDescriptor() == unit4);
        }

        [DataTestMethod]
        [DataRow(
        "1209"
        )]
        public void Frame03(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.Double;
            String parameter1Type = "Device keep-alive period";
            Double value1 = 9.00;
            String unit1 = "min";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 1);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Keep-alive period");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
        }

        [DataTestMethod]
        [DataRow(
        "041211"
        )]
        public void Frame04(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.String;
            String parameter1Type = "Device hardware version";
            String value1 = "1.2";
            String unit1 = "";
            ReadingValueType reading2ValueType = ReadingValueType.String;
            String parameter2Type = "Device software version";
            String value2 = "1.1";
            String unit2 = "";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 2);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Hardware and software version");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ValueString == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);

            Assert.IsTrue(parsedData.Reading.ToArray()[1].ParameterType.GetDescriptor() == parameter2Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].ReadingValueType == reading2ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].ValueString == value2);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Unit.GetDescriptor() == unit2);
        }

        [DataTestMethod]
        [DataRow(
        "19C6"
        )]
        public void Frame05(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.Double;
            String parameter1Type = "Device network join retry period";
            Double value1 = 16.50;
            String unit1 = "min";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 1);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Network join retry period");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
        }

        [DataTestMethod]
        [DataRow(
        "1B00"
        )]
        public void Frame06(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.String;
            String parameter1Type = "Device uplink messages";
            String value1 = "Device operates with unconfirmed uplinks";
            String unit1 = "";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 1);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Uplink messages");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ValueString == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
        }

        [DataTestMethod]
        [DataRow(
        "1D0509"
        )]
        public void Frame07(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.Double;
            String parameter1Type = "Device radio communication watchdog confirmed uplink";
            Double value1 = 5.00;
            String unit1 = "";
            ReadingValueType reading2ValueType = ReadingValueType.Double;
            String parameter2Type = "Device radio communication watchdog unconfirmed uplink";
            Double value2 = 9.00;
            String unit2 = "";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 2);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Radio communication watchdog");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);

            Assert.IsTrue(parsedData.Reading.ToArray()[1].ParameterType.GetDescriptor() == parameter2Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].ReadingValueType == reading2ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Value == value2);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Unit.GetDescriptor() == unit2);
        }

        [DataTestMethod]
        [DataRow(
        "1F038405DC"
        )]
        public void Frame08(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.Double;
            String parameter1Type = "CO2 boundary level good-medium zone";
            Double value1 = 900.00;
            String unit1 = "ppm";
            ReadingValueType reading2ValueType = ReadingValueType.Double;
            String parameter2Type = "CO2 boundary level medium-bad zone";
            Double value2 = 1500;
            String unit2 = "ppm";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 2);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "CO2 boundary levels");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);

            Assert.IsTrue(parsedData.Reading.ToArray()[1].ParameterType.GetDescriptor() == parameter2Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].ReadingValueType == reading2ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Value == value2);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Unit.GetDescriptor() == unit2);
        }

        [DataTestMethod]
        [DataRow(
        "210221"
        )]
        public void Frame09(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.Double;
            String parameter1Type = "CO2 auto-zero value";
            Double value1 = 545.00;
            String unit1 = "ppm";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 1);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "CO2 auto-zero value");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
        }

        [DataTestMethod]
        [DataRow(
        "23000A0C"
        )]
        public void Frame10(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.Double;
            String parameter1Type = "Notification period when measured CO2 is inside the good zone";
            Double value1 = 0.00;
            String unit1 = "min";
            ReadingValueType reading2ValueType = ReadingValueType.Double;
            String parameter2Type = "Notification period when measured CO2 is inside the medium zone";
            Double value2 = 10.00;
            String unit2 = "min";
            ReadingValueType reading3ValueType = ReadingValueType.Double;
            String parameter3Type = "Notification period when measured CO2 is inside the bad zone";
            Double value3 = 12.00;
            String unit3 = "min";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 3);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Notify period");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);

            Assert.IsTrue(parsedData.Reading.ToArray()[1].ParameterType.GetDescriptor() == parameter2Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].ReadingValueType == reading2ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Value == value2);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Unit.GetDescriptor() == unit2);

            Assert.IsTrue(parsedData.Reading.ToArray()[2].ParameterType.GetDescriptor() == parameter3Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].ReadingValueType == reading3ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].Value == value3);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].Unit.GetDescriptor() == unit3);
        }

        [DataTestMethod]
        [DataRow(
        "25090A0B"
        )]
        public void Frame11(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.Double;
            String parameter1Type = "Measurement period until the measured CO2 levels are inside the good zone";
            Double value1 = 9.00;
            String unit1 = "min";
            ReadingValueType reading2ValueType = ReadingValueType.Double;
            String parameter2Type = "Measurement period until the measured CO2 levels are inside the medium zone";
            Double value2 = 10.00;
            String unit2 = "min";
            ReadingValueType reading3ValueType = ReadingValueType.Double;
            String parameter3Type = "Measurement period until the measured CO2 levels are inside the bad zone";
            Double value3 = 11.00;
            String unit3 = "min";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 3);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "CO2 measurement period");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);

            Assert.IsTrue(parsedData.Reading.ToArray()[1].ParameterType.GetDescriptor() == parameter2Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].ReadingValueType == reading2ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Value == value2);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Unit.GetDescriptor() == unit2);

            Assert.IsTrue(parsedData.Reading.ToArray()[2].ParameterType.GetDescriptor() == parameter3Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].ReadingValueType == reading3ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].Value == value3);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].Unit.GetDescriptor() == unit3);
        }

        [DataTestMethod]
        [DataRow(
        "27000000026550046550"
        )]
        public void Frame12(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.Double;
            String parameter1Type = "Duration of the buzzer beeping for good CO2 levels";
            Double value1 = 0.00;
            String unit1 = "s";
            ReadingValueType reading2ValueType = ReadingValueType.Double;
            String parameter2Type = "Duration of the buzzer loud periods for good CO2 levels";
            Double value2 = 0.00;
            String unit2 = "ms";
            ReadingValueType reading3ValueType = ReadingValueType.Double;
            String parameter3Type = "Duration of the buzzer silent periods for good CO2 levels";
            Double value3 = 0.00;
            String unit3 = "ms";
            ReadingValueType reading4ValueType = ReadingValueType.Double;
            String parameter4Type = "Duration of the buzzer beeping for medium CO2 levels";
            Double value4 = 2.00;
            String unit4 = "s";
            ReadingValueType reading5ValueType = ReadingValueType.Double;
            String parameter5Type = "Duration of the buzzer loud periods for medium CO2 levels";
            Double value5 = 1010.00;
            String unit5 = "ms";
            ReadingValueType reading6ValueType = ReadingValueType.Double;
            String parameter6Type = "Duration of the buzzer silent periods for medium CO2 levels";
            Double value6 = 800.00;
            String unit6 = "ms";
            ReadingValueType reading7ValueType = ReadingValueType.Double;
            String parameter7Type = "Duration of the buzzer beeping for bad CO2 levels";
            Double value7 = 4.00;
            String unit7 = "s";
            ReadingValueType reading8ValueType = ReadingValueType.Double;
            String parameter8Type = "Duration of the buzzer loud periods for bad CO2 levels";
            Double value8 = 1010.00;
            String unit8 = "ms";
            ReadingValueType reading9ValueType = ReadingValueType.Double;
            String parameter9Type = "Duration of the buzzer silent periods for bad CO2 levels";
            Double value9 = 800.00;
            String unit9 = "ms";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 9);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Buzzer notification configuration");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);

            Assert.IsTrue(parsedData.Reading.ToArray()[1].ParameterType.GetDescriptor() == parameter2Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].ReadingValueType == reading2ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Value == value2);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Unit.GetDescriptor() == unit2);

            Assert.IsTrue(parsedData.Reading.ToArray()[2].ParameterType.GetDescriptor() == parameter3Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].ReadingValueType == reading3ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].Value == value3);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].Unit.GetDescriptor() == unit3);

            Assert.IsTrue(parsedData.Reading.ToArray()[3].ParameterType.GetDescriptor() == parameter4Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].ReadingValueType == reading4ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].Value == value4);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].Unit.GetDescriptor() == unit4);

            Assert.IsTrue(parsedData.Reading.ToArray()[4].ParameterType.GetDescriptor() == parameter5Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[4].ReadingValueType == reading5ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[4].Value == value5);
            Assert.IsTrue(parsedData.Reading.ToArray()[4].Unit.GetDescriptor() == unit5);

            Assert.IsTrue(parsedData.Reading.ToArray()[5].ParameterType.GetDescriptor() == parameter6Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[5].ReadingValueType == reading6ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[5].Value == value6);
            Assert.IsTrue(parsedData.Reading.ToArray()[5].Unit.GetDescriptor() == unit6);

            Assert.IsTrue(parsedData.Reading.ToArray()[6].ParameterType.GetDescriptor() == parameter7Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[6].ReadingValueType == reading7ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[6].Value == value7);
            Assert.IsTrue(parsedData.Reading.ToArray()[6].Unit.GetDescriptor() == unit7);

            Assert.IsTrue(parsedData.Reading.ToArray()[7].ParameterType.GetDescriptor() == parameter8Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[7].ReadingValueType == reading8ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[7].Value == value8);
            Assert.IsTrue(parsedData.Reading.ToArray()[7].Unit.GetDescriptor() == unit8);

            Assert.IsTrue(parsedData.Reading.ToArray()[8].ParameterType.GetDescriptor() == parameter9Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[8].ReadingValueType == reading9ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[8].Value == value9);
            Assert.IsTrue(parsedData.Reading.ToArray()[8].Unit.GetDescriptor() == unit9);
        }

        [DataTestMethod]
        [DataRow(
        "29 00 02 00 00 15 03 03 00 01 92 03 00 00 01 92"
        )]
        public void Frame13(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.String;
            String parameter1Type = "Red LED procedure for good CO2 level";
            String value1 = "None";
            String unit1 = "";
            ReadingValueType reading2ValueType = ReadingValueType.String;
            String parameter2Type = "Green LED procedure for good CO2 level";
            String value2 = "Blink fast for the given time duration";
            String unit2 = "";
            ReadingValueType reading3ValueType = ReadingValueType.String;
            String parameter3Type = "Blue LED procedure for good CO2 level";
            String value3 = "None";
            String unit3 = "";
            ReadingValueType reading4ValueType = ReadingValueType.Double;
            String parameter4Type = "Duration of the LED notification for good CO2 level";
            Double value4 = 210.00;
            String unit4 = "ms";
            ReadingValueType reading5ValueType = ReadingValueType.String;
            String parameter5Type = "Red LED procedure for medium CO2 level";
            String value5 = "Blink slow for the given time duration";
            String unit5 = "";
            ReadingValueType reading6ValueType = ReadingValueType.String;
            String parameter6Type = "Green LED procedure for medium CO2 level";
            String value6 = "Blink slow for the given time duration";
            String unit6 = "";
            ReadingValueType reading7ValueType = ReadingValueType.String;
            String parameter7Type = "Blue LED procedure for medium CO2 level";
            String value7 = "None";
            String unit7 = "";
            ReadingValueType reading8ValueType = ReadingValueType.Double;
            String parameter8Type = "Duration of the LED notification for medium CO2 level";
            Double value8 = 4020.00;
            String unit8 = "ms";
            ReadingValueType reading9ValueType = ReadingValueType.String;
            String parameter9Type = "Red LED procedure for bad CO2 level";
            String value9 = "Blink slow for the given time duration";
            String unit9 = "";
            ReadingValueType reading10ValueType = ReadingValueType.String;
            String parameter10Type = "Green LED procedure for bad CO2 level";
            String value10 = "None";
            String unit10 = "";
            ReadingValueType reading11ValueType = ReadingValueType.String;
            String parameter11Type = "Blue LED procedure for bad CO2 level";
            String value11 = "None";
            String unit11 = "";
            ReadingValueType reading12ValueType = ReadingValueType.Double;
            String parameter12Type = "Duration of the LED notification for bad CO2 level";
            Double value12 = 4020.00;
            String unit12 = "ms";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 12);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "LED notification configuration");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ValueString == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);

            Assert.IsTrue(parsedData.Reading.ToArray()[1].ParameterType.GetDescriptor() == parameter2Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].ReadingValueType == reading2ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].ValueString == value2);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Unit.GetDescriptor() == unit2);

            Assert.IsTrue(parsedData.Reading.ToArray()[2].ParameterType.GetDescriptor() == parameter3Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].ReadingValueType == reading3ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].ValueString == value3);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].Unit.GetDescriptor() == unit3);

            Assert.IsTrue(parsedData.Reading.ToArray()[3].ParameterType.GetDescriptor() == parameter4Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].ReadingValueType == reading4ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].Value == value4);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].Unit.GetDescriptor() == unit4);

            Assert.IsTrue(parsedData.Reading.ToArray()[4].ParameterType.GetDescriptor() == parameter5Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[4].ReadingValueType == reading5ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[4].ValueString == value5);
            Assert.IsTrue(parsedData.Reading.ToArray()[4].Unit.GetDescriptor() == unit5);

            Assert.IsTrue(parsedData.Reading.ToArray()[5].ParameterType.GetDescriptor() == parameter6Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[5].ReadingValueType == reading6ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[5].ValueString == value6);
            Assert.IsTrue(parsedData.Reading.ToArray()[5].Unit.GetDescriptor() == unit6);

            Assert.IsTrue(parsedData.Reading.ToArray()[6].ParameterType.GetDescriptor() == parameter7Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[6].ReadingValueType == reading7ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[6].ValueString == value7);
            Assert.IsTrue(parsedData.Reading.ToArray()[6].Unit.GetDescriptor() == unit7);

            Assert.IsTrue(parsedData.Reading.ToArray()[7].ParameterType.GetDescriptor() == parameter8Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[7].ReadingValueType == reading8ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[7].Value == value8);
            Assert.IsTrue(parsedData.Reading.ToArray()[7].Unit.GetDescriptor() == unit8);

            Assert.IsTrue(parsedData.Reading.ToArray()[8].ParameterType.GetDescriptor() == parameter9Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[8].ReadingValueType == reading9ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[8].ValueString == value9);
            Assert.IsTrue(parsedData.Reading.ToArray()[8].Unit.GetDescriptor() == unit9);

            Assert.IsTrue(parsedData.Reading.ToArray()[9].ParameterType.GetDescriptor() == parameter10Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[9].ReadingValueType == reading10ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[9].ValueString == value10);
            Assert.IsTrue(parsedData.Reading.ToArray()[9].Unit.GetDescriptor() == unit10);

            Assert.IsTrue(parsedData.Reading.ToArray()[10].ParameterType.GetDescriptor() == parameter11Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[10].ReadingValueType == reading11ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[10].ValueString == value11);
            Assert.IsTrue(parsedData.Reading.ToArray()[10].Unit.GetDescriptor() == unit11);

            Assert.IsTrue(parsedData.Reading.ToArray()[11].ParameterType.GetDescriptor() == parameter12Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[11].ReadingValueType == reading12ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[11].Value == value12);
            Assert.IsTrue(parsedData.Reading.ToArray()[11].Unit.GetDescriptor() == unit12);
        }

        [DataTestMethod]
        [DataRow(
        "2B48"
        )]
        public void Frame14(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.Double;
            String parameter1Type = "CO2 auto-zero period";
            Double value1 = 72.00;
            String unit1 = "h";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 1);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "CO2 auto-zero period");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
        }

        [DataTestMethod]
        [DataRow(
        "04-20-23-12-0A-1B-00-1F-03-84-05-DC-21-00-56-25-0A-0A-0A-23-00-0A-0A-29-00-02-00-00-15-03-03-00-01-92-03-00-00-01-92-01-03-6E-02-58-6F-F4"
        )]
        public void Frame15(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.String;
            String parameter1Type = "Device hardware version";
            String value1 = "2.0";
            String unit1 = "";
            ReadingValueType reading2ValueType = ReadingValueType.String;
            String parameter2Type = "Device software version";
            String value2 = "2.3";
            String unit2 = "";
            ReadingValueType reading3ValueType = ReadingValueType.Double;
            String parameter3Type = "Device keep-alive period";
            Double value3 = 10.00;
            String unit3 = "min";
            ReadingValueType reading4ValueType = ReadingValueType.String;
            String parameter4Type = "Device uplink messages";
            String value4 = "Device operates with unconfirmed uplinks";
            String unit4 = "";
            ReadingValueType reading5ValueType = ReadingValueType.Double;
            String parameter5Type = "CO2 boundary level good-medium zone";
            Double value5 = 900.00;
            String unit5 = "ppm";
            ReadingValueType reading6ValueType = ReadingValueType.Double;
            String parameter6Type = "CO2 boundary level medium-bad zone";
            Double value6 = 1500.00;
            String unit6 = "ppm";
            ReadingValueType reading7ValueType = ReadingValueType.Double;
            String parameter7Type = "CO2 auto-zero value";
            Double value7 = 86.00;
            String unit7 = "ppm";
            ReadingValueType reading8ValueType = ReadingValueType.Double;
            String parameter8Type = "Measurement period until the measured CO2 levels are inside the good zone";
            Double value8 = 10.00;
            String unit8 = "min";
            ReadingValueType reading9ValueType = ReadingValueType.Double;
            String parameter9Type = "Measurement period until the measured CO2 levels are inside the medium zone";
            Double value9 = 10.00;
            String unit9 = "min";
            ReadingValueType reading10ValueType = ReadingValueType.Double;
            String parameter10Type = "Measurement period until the measured CO2 levels are inside the bad zone";
            Double value10 = 10.00;
            String unit10 = "min";
            ReadingValueType reading11ValueType = ReadingValueType.Double;
            String parameter11Type = "Notification period when measured CO2 is inside the good zone";
            Double value11 = 0.00;
            String unit11 = "min";
            ReadingValueType reading12ValueType = ReadingValueType.Double;
            String parameter12Type = "Notification period when measured CO2 is inside the medium zone";
            Double value12 = 10.00;
            String unit12 = "min";
            ReadingValueType reading13ValueType = ReadingValueType.Double;
            String parameter13Type = "Notification period when measured CO2 is inside the bad zone";
            Double value13 = 10.00;
            String unit13 = "min";
            ReadingValueType reading14ValueType = ReadingValueType.String;
            String parameter14Type = "Red LED procedure for good CO2 level";
            String value14 = "None";
            String unit14 = "";
            ReadingValueType reading15ValueType = ReadingValueType.String;
            String parameter15Type = "Green LED procedure for good CO2 level";
            String value15 = "Blink fast for the given time duration";
            String unit15 = "";
            ReadingValueType reading16ValueType = ReadingValueType.String;
            String parameter16Type = "Blue LED procedure for good CO2 level";
            String value16 = "None";
            String unit16 = "";
            ReadingValueType reading17ValueType = ReadingValueType.Double;
            String parameter17Type = "Duration of the LED notification for good CO2 level";
            Double value17 = 210.00;
            String unit17 = "ms";
            ReadingValueType reading18ValueType = ReadingValueType.String;
            String parameter18Type = "Red LED procedure for medium CO2 level";
            String value18 = "Blink slow for the given time duration";
            String unit18 = "";
            ReadingValueType reading19ValueType = ReadingValueType.String;
            String parameter19Type = "Green LED procedure for medium CO2 level";
            String value19 = "Blink slow for the given time duration";
            String unit19 = "";
            ReadingValueType reading20ValueType = ReadingValueType.String;
            String parameter20Type = "Blue LED procedure for medium CO2 level";
            String value20 = "None";
            String unit20 = "";
            ReadingValueType reading21ValueType = ReadingValueType.Double;
            String parameter21Type = "Duration of the LED notification for medium CO2 level";
            Double value21 = 4020.00;
            String unit21 = "ms";
            ReadingValueType reading22ValueType = ReadingValueType.String;
            String parameter22Type = "Red LED procedure for bad CO2 level";
            String value22 = "Blink slow for the given time duration";
            String unit22 = "";
            ReadingValueType reading23ValueType = ReadingValueType.String;
            String parameter23Type = "Green LED procedure for bad CO2 level";
            String value23 = "None";
            String unit23 = "";
            ReadingValueType reading24ValueType = ReadingValueType.String;
            String parameter24Type = "Blue LED procedure for bad CO2 level";
            String value24 = "None";
            String unit24 = "";
            ReadingValueType reading25ValueType = ReadingValueType.Double;
            String parameter25Type = "Duration of the LED notification for bad CO2 level";
            Double value25 = 4020.00;
            String unit25 = "ms";
            ReadingValueType reading26ValueType = ReadingValueType.Double;
            String parameter26Type = "CO2";
            Double value26 = 878.00;
            String unit26 = "ppm";
            ReadingValueType reading27ValueType = ReadingValueType.Double;
            String parameter27Type = "Internal temperature";
            Double value27 = 20.00;
            String unit27 = "°C";
            ReadingValueType reading28ValueType = ReadingValueType.Double;
            String parameter28Type = "Relative humidity";
            Double value28 = 43.35;
            String unit28 = "%";
            ReadingValueType reading29ValueType = ReadingValueType.Double;
            String parameter29Type = "Device battery voltage";
            Double value29 = 3552;
            String unit29 = "mV";

            Parser parser = new();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 29);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 9);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Hardware and software version");
            Assert.IsTrue(parsedData.CommandType.ToArray()[1].GetDescriptor() == "Keep-alive period");
            Assert.IsTrue(parsedData.CommandType.ToArray()[2].GetDescriptor() == "Uplink messages");
            Assert.IsTrue(parsedData.CommandType.ToArray()[3].GetDescriptor() == "CO2 boundary levels");
            Assert.IsTrue(parsedData.CommandType.ToArray()[4].GetDescriptor() == "CO2 auto-zero value");
            Assert.IsTrue(parsedData.CommandType.ToArray()[5].GetDescriptor() == "CO2 measurement period");
            Assert.IsTrue(parsedData.CommandType.ToArray()[6].GetDescriptor() == "Notify period");
            Assert.IsTrue(parsedData.CommandType.ToArray()[7].GetDescriptor() == "LED notification configuration");
            Assert.IsTrue(parsedData.CommandType.ToArray()[8].GetDescriptor() == "Keep-alive");

            Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].ValueString == value1);
            Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);

            Assert.IsTrue(parsedData.Reading.ToArray()[1].ParameterType.GetDescriptor() == parameter2Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].ReadingValueType == reading2ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].ValueString == value2);
            Assert.IsTrue(parsedData.Reading.ToArray()[1].Unit.GetDescriptor() == unit2);

            Assert.IsTrue(parsedData.Reading.ToArray()[2].ParameterType.GetDescriptor() == parameter3Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].ReadingValueType == reading3ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].Value == value3);
            Assert.IsTrue(parsedData.Reading.ToArray()[2].Unit.GetDescriptor() == unit3);

            Assert.IsTrue(parsedData.Reading.ToArray()[3].ParameterType.GetDescriptor() == parameter4Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].ReadingValueType == reading4ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].ValueString == value4);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].Unit.GetDescriptor() == unit4);

            Assert.IsTrue(parsedData.Reading.ToArray()[4].ParameterType.GetDescriptor() == parameter5Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[4].ReadingValueType == reading5ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[4].Value == value5);
            Assert.IsTrue(parsedData.Reading.ToArray()[4].Unit.GetDescriptor() == unit5);

            Assert.IsTrue(parsedData.Reading.ToArray()[5].ParameterType.GetDescriptor() == parameter6Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[5].ReadingValueType == reading6ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[5].Value == value6);
            Assert.IsTrue(parsedData.Reading.ToArray()[5].Unit.GetDescriptor() == unit6);

            Assert.IsTrue(parsedData.Reading.ToArray()[6].ParameterType.GetDescriptor() == parameter7Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[6].ReadingValueType == reading7ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[6].Value == value7);
            Assert.IsTrue(parsedData.Reading.ToArray()[6].Unit.GetDescriptor() == unit7);

            Assert.IsTrue(parsedData.Reading.ToArray()[7].ParameterType.GetDescriptor() == parameter8Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[7].ReadingValueType == reading8ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[7].Value == value8);
            Assert.IsTrue(parsedData.Reading.ToArray()[7].Unit.GetDescriptor() == unit8);

            Assert.IsTrue(parsedData.Reading.ToArray()[8].ParameterType.GetDescriptor() == parameter9Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[8].ReadingValueType == reading9ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[8].Value == value9);
            Assert.IsTrue(parsedData.Reading.ToArray()[8].Unit.GetDescriptor() == unit9);

            Assert.IsTrue(parsedData.Reading.ToArray()[9].ParameterType.GetDescriptor() == parameter10Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[9].ReadingValueType == reading10ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[9].Value == value10);
            Assert.IsTrue(parsedData.Reading.ToArray()[9].Unit.GetDescriptor() == unit10);

            Assert.IsTrue(parsedData.Reading.ToArray()[10].ParameterType.GetDescriptor() == parameter11Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[10].ReadingValueType == reading11ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[10].Value == value11);
            Assert.IsTrue(parsedData.Reading.ToArray()[10].Unit.GetDescriptor() == unit11);

            Assert.IsTrue(parsedData.Reading.ToArray()[11].ParameterType.GetDescriptor() == parameter12Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[11].ReadingValueType == reading12ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[11].Value == value12);
            Assert.IsTrue(parsedData.Reading.ToArray()[11].Unit.GetDescriptor() == unit12);

            Assert.IsTrue(parsedData.Reading.ToArray()[12].ParameterType.GetDescriptor() == parameter13Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[12].ReadingValueType == reading13ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[12].Value == value13);
            Assert.IsTrue(parsedData.Reading.ToArray()[12].Unit.GetDescriptor() == unit13);

            Assert.IsTrue(parsedData.Reading.ToArray()[13].ParameterType.GetDescriptor() == parameter14Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[13].ReadingValueType == reading14ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[13].ValueString == value14);
            Assert.IsTrue(parsedData.Reading.ToArray()[13].Unit.GetDescriptor() == unit14);

            Assert.IsTrue(parsedData.Reading.ToArray()[14].ParameterType.GetDescriptor() == parameter15Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[14].ReadingValueType == reading15ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[14].ValueString == value15);
            Assert.IsTrue(parsedData.Reading.ToArray()[14].Unit.GetDescriptor() == unit15);

            Assert.IsTrue(parsedData.Reading.ToArray()[15].ParameterType.GetDescriptor() == parameter16Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[15].ReadingValueType == reading16ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[15].ValueString == value16);
            Assert.IsTrue(parsedData.Reading.ToArray()[15].Unit.GetDescriptor() == unit16);

            Assert.IsTrue(parsedData.Reading.ToArray()[16].ParameterType.GetDescriptor() == parameter17Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[16].ReadingValueType == reading17ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[16].Value == value17);
            Assert.IsTrue(parsedData.Reading.ToArray()[16].Unit.GetDescriptor() == unit17);

            Assert.IsTrue(parsedData.Reading.ToArray()[17].ParameterType.GetDescriptor() == parameter18Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[17].ReadingValueType == reading18ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[17].ValueString == value18);
            Assert.IsTrue(parsedData.Reading.ToArray()[17].Unit.GetDescriptor() == unit18);

            Assert.IsTrue(parsedData.Reading.ToArray()[18].ParameterType.GetDescriptor() == parameter19Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[18].ReadingValueType == reading19ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[18].ValueString == value19);
            Assert.IsTrue(parsedData.Reading.ToArray()[18].Unit.GetDescriptor() == unit19);

            Assert.IsTrue(parsedData.Reading.ToArray()[19].ParameterType.GetDescriptor() == parameter20Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[19].ReadingValueType == reading20ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[19].ValueString == value20);
            Assert.IsTrue(parsedData.Reading.ToArray()[19].Unit.GetDescriptor() == unit20);

            Assert.IsTrue(parsedData.Reading.ToArray()[20].ParameterType.GetDescriptor() == parameter21Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[20].ReadingValueType == reading21ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[20].Value == value21);
            Assert.IsTrue(parsedData.Reading.ToArray()[20].Unit.GetDescriptor() == unit21);

            Assert.IsTrue(parsedData.Reading.ToArray()[21].ParameterType.GetDescriptor() == parameter22Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[21].ReadingValueType == reading22ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[21].ValueString == value22);
            Assert.IsTrue(parsedData.Reading.ToArray()[21].Unit.GetDescriptor() == unit22);

            Assert.IsTrue(parsedData.Reading.ToArray()[22].ParameterType.GetDescriptor() == parameter23Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[22].ReadingValueType == reading23ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[22].ValueString == value23);
            Assert.IsTrue(parsedData.Reading.ToArray()[22].Unit.GetDescriptor() == unit23);

            Assert.IsTrue(parsedData.Reading.ToArray()[23].ParameterType.GetDescriptor() == parameter24Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[23].ReadingValueType == reading24ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[23].ValueString == value24);
            Assert.IsTrue(parsedData.Reading.ToArray()[23].Unit.GetDescriptor() == unit24);

            Assert.IsTrue(parsedData.Reading.ToArray()[24].ParameterType.GetDescriptor() == parameter25Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[24].ReadingValueType == reading25ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[24].Value == value25);
            Assert.IsTrue(parsedData.Reading.ToArray()[24].Unit.GetDescriptor() == unit25);

            Assert.IsTrue(parsedData.Reading.ToArray()[25].ReadingValueType == reading26ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[25].ParameterType.GetDescriptor() == parameter26Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[25].Value == value26);
            Assert.IsTrue(parsedData.Reading.ToArray()[25].Unit.GetDescriptor() == unit26);

            Assert.IsTrue(parsedData.Reading.ToArray()[26].ReadingValueType == reading27ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[26].ParameterType.GetDescriptor() == parameter27Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[26].Value == value27);
            Assert.IsTrue(parsedData.Reading.ToArray()[26].Unit.GetDescriptor() == unit27);

            Assert.IsTrue(parsedData.Reading.ToArray()[27].ReadingValueType == reading28ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[27].ParameterType.GetDescriptor() == parameter28Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[27].Value == value28);
            Assert.IsTrue(parsedData.Reading.ToArray()[27].Unit.GetDescriptor() == unit28);

            Assert.IsTrue(parsedData.Reading.ToArray()[28].ReadingValueType == reading29ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[28].ParameterType.GetDescriptor() == parameter29Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[28].Value == value29);
            Assert.IsTrue(parsedData.Reading.ToArray()[28].Unit.GetDescriptor() == unit29);
        }
    }
}
