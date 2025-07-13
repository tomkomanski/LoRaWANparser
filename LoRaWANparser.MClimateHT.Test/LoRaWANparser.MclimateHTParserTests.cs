using LoRaWANparser.MClimateHT.Enums;
using LoRaWANparser.MClimateHT.Models;

namespace LoRaWANparser.MClimateHT.Test
{
    [TestClass]
    public sealed class LoRaWANparser
    {
        [DataTestMethod]
        [DataRow(
        "01026499fb0400"
        )]
        public void Frame01(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.Double;
            String parameter1Type = "Internal temperature";
            Double value1 = 21.2;
            String unit1 = "°C";
            ReadingValueType reading2ValueType = ReadingValueType.Double;
            String parameter2Type = "Relative humidity";
            Double value2 = 59.76;
            String unit2 = "%";
            ReadingValueType reading3ValueType = ReadingValueType.Double;
            String parameter3Type = "Device battery voltage";
            Double value3 = 3608;
            String unit3 = "mV";
            ReadingValueType reading4ValueType = ReadingValueType.String;
            String parameter4Type = "External thermistor temperature";
            String value4 = "External thermistor connection broken";
            String unit4 = "";

            IParser parser = new Parser();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 4);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Keep-alive");

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
            Assert.IsTrue(parsedData.Reading.ToArray()[3].ValueString == value4);
            Assert.IsTrue(parsedData.Reading.ToArray()[3].Unit.GetDescriptor() == unit4);
        }

        [DataTestMethod]
        [DataRow(
        "01028880ab029c"
        )]
        public void Frame02(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.Double;
            String parameter1Type = "Internal temperature";
            Double value1 = 24.8;
            String unit1 = "°C";
            ReadingValueType reading2ValueType = ReadingValueType.Double;
            String parameter2Type = "Relative humidity";
            Double value2 = 50.00;
            String unit2 = "%";
            ReadingValueType reading3ValueType = ReadingValueType.Double;
            String parameter3Type = "Device battery voltage";
            Double value3 = 2968;
            String unit3 = "mV";
            ReadingValueType reading4ValueType = ReadingValueType.Double;
            String parameter4Type = "External thermistor temperature";
            Double value4 = 66.80;
            String unit4 = "°C";

            IParser parser = new Parser();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 4);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 1);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Keep-alive");

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
        }

        [DataTestMethod]
        [DataRow(
        "04-20-20-12-0A-1B-00-01-02-59-75-F6-04-00"
        )]
        public void Frame03(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.String;
            String parameter1Type = "Device hardware version";
            String value1 = "2.0";
            String unit1 = "";
            ReadingValueType reading2ValueType = ReadingValueType.String;
            String parameter2Type = "Device software version";
            String value2 = "2.0";
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
            String parameter5Type = "Internal temperature";
            Double value5 = 20.10;
            String unit5 = "°C";
            ReadingValueType reading6ValueType = ReadingValueType.Double;
            String parameter6Type = "Relative humidity";
            Double value6 = 45.70;
            String unit6 = "%";
            ReadingValueType reading7ValueType = ReadingValueType.Double;
            String parameter7Type = "Device battery voltage";
            Double value7 = 3568;
            String unit7 = "mV";
            ReadingValueType reading8ValueType = ReadingValueType.String;
            String parameter8Type = "External thermistor temperature";
            String value8 = "External thermistor connection broken";
            String unit8 = "";

            IParser parser = new Parser();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 8);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 4);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Hardware and software version");
            Assert.IsTrue(parsedData.CommandType.ToArray()[1].GetDescriptor() == "Keep-alive period");
            Assert.IsTrue(parsedData.CommandType.ToArray()[2].GetDescriptor() == "Uplink messages");
            Assert.IsTrue(parsedData.CommandType.ToArray()[3].GetDescriptor() == "Keep-alive");

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
            Assert.IsTrue(parsedData.Reading.ToArray()[7].ValueString == value8);
            Assert.IsTrue(parsedData.Reading.ToArray()[7].Unit.GetDescriptor() == unit8);
        }

        [DataTestMethod]
        [DataRow(
        "04-20-20-12-0A-1B-00-01-02-5B-71-F5-04-00"
        )]
        public void Frame04(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.String;
            String parameter1Type = "Device hardware version";
            String value1 = "2.0";
            String unit1 = "";
            ReadingValueType reading2ValueType = ReadingValueType.String;
            String parameter2Type = "Device software version";
            String value2 = "2.0";
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
            String parameter5Type = "Internal temperature";
            Double value5 = 20.30;
            String unit5 = "°C";
            ReadingValueType reading6ValueType = ReadingValueType.Double;
            String parameter6Type = "Relative humidity";
            Double value6 = 44.14;
            String unit6 = "%";
            ReadingValueType reading7ValueType = ReadingValueType.Double;
            String parameter7Type = "Device battery voltage";
            Double value7 = 3560;
            String unit7 = "mV";
            ReadingValueType reading8ValueType = ReadingValueType.String;
            String parameter8Type = "External thermistor temperature";
            String value8 = "External thermistor connection broken";
            String unit8 = "";

            IParser parser = new Parser();
            ParsedData parsedData = parser.Process(frame);

            Assert.IsTrue(parsedData.Reading.Count() == 8);
            Assert.IsTrue(parsedData.ParserErrorCode.Count() == 0);
            Assert.IsTrue(parsedData.CommandType.Count() == 4);
            Assert.IsTrue(parsedData.CommandType.ToArray()[0].GetDescriptor() == "Hardware and software version");
            Assert.IsTrue(parsedData.CommandType.ToArray()[1].GetDescriptor() == "Keep-alive period");
            Assert.IsTrue(parsedData.CommandType.ToArray()[2].GetDescriptor() == "Uplink messages");
            Assert.IsTrue(parsedData.CommandType.ToArray()[3].GetDescriptor() == "Keep-alive");

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
            Assert.IsTrue(parsedData.Reading.ToArray()[7].ValueString == value8);
            Assert.IsTrue(parsedData.Reading.ToArray()[7].Unit.GetDescriptor() == unit8);
        }

        [DataTestMethod]
        [DataRow(
        "1209"
        )]
        public void Frame05(String frame)
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
        "041211"
        )]
        public void Frame06(String frame)
        {
            ReadingValueType reading1ValueType = ReadingValueType.String;
            String parameter1Type = "Device hardware version";
            String value1 = "1.2";
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
        "19C6"
        )]
        public void Frame07(String frame)
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
        "1D0509"
        )]
        public void Frame08(String frame)
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
        "1B00"
        )]
        public void Frame09(String frame)
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
    }
}