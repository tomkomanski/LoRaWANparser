using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;

namespace LoRaWANparser.MClimateCO2Display.Test
{
    [TestClass]
    public sealed class LoRaWANparser
    {
            [DataTestMethod]
            [DataRow(
            "010260900b347218009400"
            )]
            public void Frame01(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.Double;
                String parameter1Type = "Internal temperature";
                Double value1 = 20.80;
                String unit1 = "°C";
                ReadingValueType reading2ValueType = ReadingValueType.Double;
                String parameter2Type = "Relative humidity";
                Double value2 = 56.25;
                String unit2 = "%";
                ReadingValueType reading3ValueType = ReadingValueType.Double;
                String parameter3Type = "Device battery voltage";
                Double value3 = 2868;
                String unit3 = "mV";
                ReadingValueType reading4ValueType = ReadingValueType.Double;
                String parameter4Type = "CO2";
                Double value4 = 882;
                String unit4 = "ppm";
                ReadingValueType reading5ValueType = ReadingValueType.String;
                String parameter5Type = "Power source";
                String value5 = "Photovoltaic panel";
                String unit5 = "";
                ReadingValueType reading6ValueType = ReadingValueType.Double;
                String parameter6Type = "Device light intensity";
                Double value6 = 148;
                String unit6 = "lx";
                ReadingValueType reading7ValueType = ReadingValueType.String;
                String parameter7Type = "PIR sensor";
                String value7 = "No motion detected";
                String unit7 = "";

                IParser parser = new Parser();
                ParsedData parsedData = parser.Process(frame);

                Assert.IsTrue(parsedData.Reading.Count() == 7);
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

                Assert.IsTrue(parsedData.Reading.ToArray()[4].ReadingValueType == reading5ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[4].ParameterType.GetDescriptor() == parameter5Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[4].ValueString == value5);
                Assert.IsTrue(parsedData.Reading.ToArray()[4].Unit.GetDescriptor() == unit5);

                Assert.IsTrue(parsedData.Reading.ToArray()[5].ReadingValueType == reading6ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[5].ParameterType.GetDescriptor() == parameter6Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[5].Value == value6);
                Assert.IsTrue(parsedData.Reading.ToArray()[5].Unit.GetDescriptor() == unit6);

                Assert.IsTrue(parsedData.Reading.ToArray()[6].ReadingValueType == reading7ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[6].ParameterType.GetDescriptor() == parameter7Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[6].ValueString == value7);
                Assert.IsTrue(parsedData.Reading.ToArray()[6].Unit.GetDescriptor() == unit7);
            }

            [DataTestMethod]
            [DataRow(
            "042511"
            )]
            public void Frame02(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.String;
                String parameter1Type = "Device hardware version";
                String value1 = "2.5";
                String unit1 = "";
                ReadingValueType reading2ValueType = ReadingValueType.String;
                String parameter2Type = "Device software version";
                String value2 = "1.1";
                String unit2 = "";

                IParser parser = new Parser();
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
            "1209"
            )]
            public void Frame03(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.Double;
                String parameter1Type = "Device keep-alive period";
                Double value1 = 9.00;
                String unit1 = "min";

                IParser parser = new Parser();
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
            "1401"
            )]
            public void Frame04(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.String;
                String parameter1Type = "Device child-lock";
                String value1 = "Enabled";
                String unit1 = "";

                IParser parser = new Parser();
                ParsedData parsedData = parser.Process(frame);

                Assert.IsTrue(parsedData.Reading.Count() == 1);
                Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
                Assert.IsTrue(parsedData.CommandType.Count() == 1);
                Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Child lock");

                Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ValueString == value1);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
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

                IParser parser = new Parser();
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

                IParser parser = new Parser();
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

                IParser parser = new Parser();
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

                IParser parser = new Parser();
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

                IParser parser = new Parser();
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
            "250A0A0A"
            )]
            public void Frame10(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.Double;
                String parameter1Type = "Measurement period until the measured CO2 levels are inside the good zone";
                Double value1 = 10.00;
                String unit1 = "min";
                ReadingValueType reading2ValueType = ReadingValueType.Double;
                String parameter2Type = "Measurement period until the measured CO2 levels are inside the medium zone";
                Double value2 = 10.00;
                String unit2 = "min";
                ReadingValueType reading3ValueType = ReadingValueType.Double;
                String parameter3Type = "Measurement period until the measured CO2 levels are inside the bad zone";
                Double value3 = 10.00;
                String unit3 = "min";

                IParser parser = new Parser();
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
            "2B48"
            )]
            public void Frame11(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.Double;
                String parameter1Type = "CO2 auto-zero period";
                Double value1 = 72.00;
                String unit1 = "h";

                IParser parser = new Parser();
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
            "340F"
            )]
            public void Frame12(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.Double;
                String parameter1Type = "Display refresh period";
                Double value1 = 15.00;
                String unit1 = "h";

                IParser parser = new Parser();
                ParsedData parsedData = parser.Process(frame);

                Assert.IsTrue(parsedData.Reading.Count() == 1);
                Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
                Assert.IsTrue(parsedData.CommandType.Count() == 1);
                Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Full display refresh");

                Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
            }

            [DataTestMethod]
            [DataRow(
            "3D01"
            )]
            public void Frame13(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.String;
                String parameter1Type = "Device PIR sensor status";
                String value1 = "Enabled";
                String unit1 = "";

                IParser parser = new Parser();
                ParsedData parsedData = parser.Process(frame);

                Assert.IsTrue(parsedData.Reading.Count() == 1);
                Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
                Assert.IsTrue(parsedData.CommandType.Count() == 1);
                Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "PIR status");

                Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ValueString == value1);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
            }

            [DataTestMethod]
            [DataRow(
            "3F14"
            )]
            public void Frame14(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.Double;
                String parameter1Type = "Device PIR sensor sensitivity";
                Double value1 = 20.00;
                String unit1 = "";

                IParser parser = new Parser();
                ParsedData parsedData = parser.Process(frame);

                Assert.IsTrue(parsedData.Reading.Count() == 1);
                Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
                Assert.IsTrue(parsedData.CommandType.Count() == 1);
                Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "PIR sensitivity");

                Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
            }

            [DataTestMethod]
            [DataRow(
            "4100"
            )]
            public void Frame15(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.String;
                String parameter1Type = "Device measured temperature";
                String value1 = "Hidden";
                String unit1 = "";

                IParser parser = new Parser();
                ParsedData parsedData = parser.Process(frame);

                Assert.IsTrue(parsedData.Reading.Count() == 1);
                Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
                Assert.IsTrue(parsedData.CommandType.Count() == 1);
                Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Measured temperature");

                Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ValueString == value1);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
            }

            [DataTestMethod]
            [DataRow(
            "4300"
            )]
            public void Frame16(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.String;
                String parameter1Type = "Device measured humidity";
                String value1 = "Hidden";
                String unit1 = "";

                IParser parser = new Parser();
                ParsedData parsedData = parser.Process(frame);

                Assert.IsTrue(parsedData.Reading.Count() == 1);
                Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
                Assert.IsTrue(parsedData.CommandType.Count() == 1);
                Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Measured humidity");

                Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ValueString == value1);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
            }

            [DataTestMethod]
            [DataRow(
            "4500"
            )]
            public void Frame17(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.String;
                String parameter1Type = "Device measured light intensity";
                String value1 = "Hidden";
                String unit1 = "";

                IParser parser = new Parser();
                ParsedData parsedData = parser.Process(frame);

                Assert.IsTrue(parsedData.Reading.Count() == 1);
                Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
                Assert.IsTrue(parsedData.CommandType.Count() == 1);
                Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Measured light intensity");

                Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ValueString == value1);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
            }

            [DataTestMethod]
            [DataRow(
            "4703"
            )]
            public void Frame18(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.Double;
                String parameter1Type = "Device PIR sensor initialization period";
                Double value1 = 3.00;
                String unit1 = "s";

                IParser parser = new Parser();
                ParsedData parsedData = parser.Process(frame);

                Assert.IsTrue(parsedData.Reading.Count() == 1);
                Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
                Assert.IsTrue(parsedData.CommandType.Count() == 1);
                Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "PIR initialization period");

                Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
            }

            [DataTestMethod]
            [DataRow(
            "4903"
            )]
            public void Frame19(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.Double;
                String parameter1Type = "Device PIR sensor measurement period";
                Double value1 = 3.00;
                String unit1 = "s";

                IParser parser = new Parser();
                ParsedData parsedData = parser.Process(frame);

                Assert.IsTrue(parsedData.Reading.Count() == 1);
                Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
                Assert.IsTrue(parsedData.CommandType.Count() == 1);
                Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "PIR measurement period");

                Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
            }

            [DataTestMethod]
            [DataRow(
            "4B0036"
            )]
            public void Frame20(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.Double;
                String parameter1Type = "Device PIR sensor check period";
                Double value1 = 54.00;
                String unit1 = "s";

                IParser parser = new Parser();
                ParsedData parsedData = parser.Process(frame);

                Assert.IsTrue(parsedData.Reading.Count() == 1);
                Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
                Assert.IsTrue(parsedData.CommandType.Count() == 1);
                Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "PIR check period");

                Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
            }

            [DataTestMethod]
            [DataRow(
            "4D000A"
            )]
            public void Frame21(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.Double;
                String parameter1Type = "Device PIR sensor blind period";
                Double value1 = 10.00;
                String unit1 = "s";

                IParser parser = new Parser();
                ParsedData parsedData = parser.Process(frame);

                Assert.IsTrue(parsedData.Reading.Count() == 1);
                Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
                Assert.IsTrue(parsedData.CommandType.Count() == 1);
                Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "PIR blind period");

                Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
            }

            [DataTestMethod]
            [DataRow(
            "800F"
            )]
            public void Frame22(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.Double;
                String parameter1Type = "CO2 measurement blind time";
                Double value1 = 15.00;
                String unit1 = "min";

                IParser parser = new Parser();
                ParsedData parsedData = parser.Process(frame);

                Assert.IsTrue(parsedData.Reading.Count() == 1);
                Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
                Assert.IsTrue(parsedData.CommandType.Count() == 1);
                Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "CO2 measurement blind time");

                Assert.IsTrue(parsedData.Reading.ToArray()[0].ParameterType.GetDescriptor() == parameter1Type);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].ReadingValueType == reading1ValueType);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Value == value1);
                Assert.IsTrue(parsedData.Reading.ToArray()[0].Unit.GetDescriptor() == unit1);
            }

            [DataTestMethod]
            [DataRow(
            "8304"
            )]
            public void Frame23(String frame)
            {
                ReadingValueType reading1ValueType = ReadingValueType.String;
                String parameter1Type = "CO2 chart on display";
                String value1 = "Shown";
                String unit1 = "";
                ReadingValueType reading2ValueType = ReadingValueType.String;
                String parameter2Type = "CO2 digital value on display";
                String value2 = "Hidden";
                String unit2 = "";
                ReadingValueType reading3ValueType = ReadingValueType.String;
                String parameter3Type = "CO2 emoji on display";
                String value3 = "Hidden";
                String unit3 = "";

                IParser parser = new Parser();
                ParsedData parsedData = parser.Process(frame);

                Assert.IsTrue(parsedData.Reading.Count() == 3);
                Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
                Assert.IsTrue(parsedData.CommandType.Count() == 1);
                Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "CO2 related images");

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
            }

        [DataTestMethod]
        [DataRow(
        "21-00-52-01-02-3A-6C-0A-66-CD-08-00-0A-00"
        )]
        public void Frame24(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.Double;
            String parameter1Type = "CO2 auto-zero value";
            Double value1 = 82.00;
            String unit1 = "ppm";
            ReadingValueType reading2ValueType = ReadingValueType.Double;
            String parameter2Type = "Internal temperature";
            Double value2 = 17.00;
            String unit2 = "°C";
            ReadingValueType reading3ValueType = ReadingValueType.Double;
            String parameter3Type = "Relative humidity";
            Double value3 = 42.18;
            String unit3 = "%";
            ReadingValueType reading4ValueType = ReadingValueType.Double;
            String parameter4Type = "Device battery voltage";
            Double value4 = 2662;
            String unit4 = "mV";
            ReadingValueType reading5ValueType = ReadingValueType.Double;
            String parameter5Type = "CO2";
            Double value5 = 461;
            String unit5 = "ppm";
            ReadingValueType reading6ValueType = ReadingValueType.String;
            String parameter6Type = "Power source";
            String value6 = "Photovoltaic panel";
            String unit6 = "";
            ReadingValueType reading7ValueType = ReadingValueType.Double;
            String parameter7Type = "Device light intensity";
            Double value7 = 10;
            String unit7 = "lx";
            ReadingValueType reading8ValueType = ReadingValueType.String;
            String parameter8Type = "PIR sensor";
            String value8 = "No motion detected";
            String unit8 = "";

            IParser parser = new Parser();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 8);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 2);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "CO2 auto-zero value");
            Assert.IsTrue(parsedData.CommandType.ToArray()[1].GetDescriptor() == "Keep-alive");

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

            Assert.IsTrue(parsedData.Reading.ToArray()[4].ReadingValueType == reading5ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[4].ParameterType.GetDescriptor() == parameter5Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[4].Value == value5);
            Assert.IsTrue(parsedData.Reading.ToArray()[4].Unit.GetDescriptor() == unit5);

            Assert.IsTrue(parsedData.Reading.ToArray()[5].ReadingValueType == reading6ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[5].ParameterType.GetDescriptor() == parameter6Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[5].ValueString == value6);
            Assert.IsTrue(parsedData.Reading.ToArray()[5].Unit.GetDescriptor() == unit6);

            Assert.IsTrue(parsedData.Reading.ToArray()[6].ReadingValueType == reading7ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[6].ParameterType.GetDescriptor() == parameter7Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[6].Value == value7);
            Assert.IsTrue(parsedData.Reading.ToArray()[6].Unit.GetDescriptor() == unit7);

            Assert.IsTrue(parsedData.Reading.ToArray()[7].ReadingValueType == reading8ValueType);
            Assert.IsTrue(parsedData.Reading.ToArray()[7].ParameterType.GetDescriptor() == parameter8Type);
            Assert.IsTrue(parsedData.Reading.ToArray()[7].ValueString == value8);
            Assert.IsTrue(parsedData.Reading.ToArray()[7].Unit.GetDescriptor() == unit8);
        }
    }
}
