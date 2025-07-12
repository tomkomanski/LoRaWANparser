using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers;
using LoRaWANparser.MClimateCO2Display.Parsers.Interfaces;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display
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
                parsedData.AddParserErrorCode(ParserErrorCode.IncorrectFrame);
                return parsedData;
            }

            Byte[] bufferBytes = hexFrame.HexStringToHexByte().ToArray();

            if (!bufferBytes.Any())
            {
                parsedData.AddParserErrorCode(ParserErrorCode.IncorrectFrame);
                return parsedData;
            }

            Queue<Byte> buffer = new();
            buffer.EnqueueChunk(bufferBytes);

            while (buffer.Count() > 1)
            {
                if (buffer.Count() >= 11 && buffer.First() == 0x01)
                {
                    List<Byte> bufferKeepAlive = new(buffer.DequeueChunk(11));
                    IPartialParser keepAlive = KeepAlive.GetParser();
                    ParsedData keepAliveProcessData = keepAlive.Process(bufferKeepAlive);
                    parsedData.AddParserErrorCode(keepAliveProcessData.ParserErrorCode);
                    parsedData.AddCommandType(keepAliveProcessData.CommandType);
                    parsedData.AddReading(keepAliveProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x04)
                {
                    List<Byte> bufferHardwareAndSoftware = new(buffer.DequeueChunk(3));
                    IPartialParser hardwareAndSoftware = HardwareAndSoftware.GetParser();
                    ParsedData hardwareAndSoftwareProcessData = hardwareAndSoftware.Process(bufferHardwareAndSoftware);
                    parsedData.AddParserErrorCode(hardwareAndSoftwareProcessData.ParserErrorCode);
                    parsedData.AddCommandType(hardwareAndSoftwareProcessData.CommandType);
                    parsedData.AddReading(hardwareAndSoftwareProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x12)
                {
                    List<Byte> bufferKeepAlivePeriod = new(buffer.DequeueChunk(2));
                    IPartialParser keepAlivePeriod = KeepAlivePeriod.GetParser();
                    ParsedData keepAlivePeriodProcessData = keepAlivePeriod.Process(bufferKeepAlivePeriod);
                    parsedData.AddParserErrorCode(keepAlivePeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(keepAlivePeriodProcessData.CommandType);
                    parsedData.AddReading(keepAlivePeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x14)
                {
                    List<Byte> bufferChildLock = new(buffer.DequeueChunk(2));
                    IPartialParser childLock = ChildLock.GetParser();
                    ParsedData childLockProcessData = childLock.Process(bufferChildLock);
                    parsedData.AddParserErrorCode(childLockProcessData.ParserErrorCode);
                    parsedData.AddCommandType(childLockProcessData.CommandType);
                    parsedData.AddReading(childLockProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x19)
                {
                    List<Byte> bufferNetworkJoinRetryPeriod = new(buffer.DequeueChunk(2));
                    IPartialParser networkJoinRetryPeriod = NetworkJoinRetryPeriod.GetParser();
                    ParsedData networkJoinRetryPeriodProcessData = networkJoinRetryPeriod.Process(bufferNetworkJoinRetryPeriod);
                    parsedData.AddParserErrorCode(networkJoinRetryPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(networkJoinRetryPeriodProcessData.CommandType);
                    parsedData.AddReading(networkJoinRetryPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x1B)
                {
                    List<Byte> bufferUplinkMessages = new(buffer.DequeueChunk(2));
                    IPartialParser uplinkMessages = UplinkMessages.GetParser();
                    ParsedData uplinkMessagesProcessData = uplinkMessages.Process(bufferUplinkMessages);
                    parsedData.AddParserErrorCode(uplinkMessagesProcessData.ParserErrorCode);
                    parsedData.AddCommandType(uplinkMessagesProcessData.CommandType);
                    parsedData.AddReading(uplinkMessagesProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x1D)
                {
                    List<Byte> bufferRadioCommunicationWatchDog = new(buffer.DequeueChunk(3));
                    IPartialParser radioCommunicationWatchDog = RadioCommunicationWatchDog.GetParser();
                    ParsedData radioCommunicationWatchDogProcessData = radioCommunicationWatchDog.Process(bufferRadioCommunicationWatchDog);
                    parsedData.AddParserErrorCode(radioCommunicationWatchDogProcessData.ParserErrorCode);
                    parsedData.AddCommandType(radioCommunicationWatchDogProcessData.CommandType);
                    parsedData.AddReading(radioCommunicationWatchDogProcessData.Reading);
                }
                else if (buffer.Count() >= 5 && buffer.First() == 0x1F)
                {
                    List<Byte> bufferCO2BoundaryLevels = new(buffer.DequeueChunk(5));
                    IPartialParser co2BoundaryLevels = CO2BoundaryLevels.GetParser();
                    ParsedData co2BoundaryLevelsProcessData = co2BoundaryLevels.Process(bufferCO2BoundaryLevels);
                    parsedData.AddParserErrorCode(co2BoundaryLevelsProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2BoundaryLevelsProcessData.CommandType);
                    parsedData.AddReading(co2BoundaryLevelsProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x21)
                {
                    List<Byte> bufferCO2AutoZeroValue = new(buffer.DequeueChunk(3));
                    IPartialParser co2AutoZeroValue = CO2AutoZeroValue.GetParser();
                    ParsedData co2AutoZeroValueProcessData = co2AutoZeroValue.Process(bufferCO2AutoZeroValue);
                    parsedData.AddParserErrorCode(co2AutoZeroValueProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2AutoZeroValueProcessData.CommandType);
                    parsedData.AddReading(co2AutoZeroValueProcessData.Reading);
                }
                else if (buffer.Count() >= 4 && buffer.First() == 0x25)
                {
                    List<Byte> bufferCO2MeasurementPeriod = new(buffer.DequeueChunk(4));
                    IPartialParser co2MeasurementPeriod = CO2MeasurementPeriod.GetParser();
                    ParsedData co2MeasurementPeriodProcessData = co2MeasurementPeriod.Process(bufferCO2MeasurementPeriod);
                    parsedData.AddParserErrorCode(co2MeasurementPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2MeasurementPeriodProcessData.CommandType);
                    parsedData.AddReading(co2MeasurementPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x2B)
                {
                    List<Byte> bufferCO2AutoZeroPeriod = new(buffer.DequeueChunk(2));
                    IPartialParser co2AutoZeroPeriod = CO2AutoZeroPeriod.GetParser();
                    ParsedData co2AutoZeroPeriodProcessData = co2AutoZeroPeriod.Process(bufferCO2AutoZeroPeriod);
                    parsedData.AddParserErrorCode(co2AutoZeroPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2AutoZeroPeriodProcessData.CommandType);
                    parsedData.AddReading(co2AutoZeroPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x34)
                {
                    List<Byte> bufferFullDisplayRefresh = new(buffer.DequeueChunk(2));
                    IPartialParser fullDisplayRefresh = FullDisplayRefresh.GetParser();
                    ParsedData fullDisplayRefreshProcessData = fullDisplayRefresh.Process(bufferFullDisplayRefresh);
                    parsedData.AddParserErrorCode(fullDisplayRefreshProcessData.ParserErrorCode);
                    parsedData.AddCommandType(fullDisplayRefreshProcessData.CommandType);
                    parsedData.AddReading(fullDisplayRefreshProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x3D)
                {
                    List<Byte> bufferPIRstatus = new(buffer.DequeueChunk(2));
                    IPartialParser pirStatus = PIRstatus.GetParser();
                    ParsedData pirStatusProcessData = pirStatus.Process(bufferPIRstatus);
                    parsedData.AddParserErrorCode(pirStatusProcessData.ParserErrorCode);
                    parsedData.AddCommandType(pirStatusProcessData.CommandType);
                    parsedData.AddReading(pirStatusProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x3F)
                {
                    List<Byte> bufferPIRsensitivity = new(buffer.DequeueChunk(2));
                    IPartialParser pirSensitivity = PIRsensitivity.GetParser();
                    ParsedData pirSensitivityProcessData = pirSensitivity.Process(bufferPIRsensitivity);
                    parsedData.AddParserErrorCode(pirSensitivityProcessData.ParserErrorCode);
                    parsedData.AddCommandType(pirSensitivityProcessData.CommandType);
                    parsedData.AddReading(pirSensitivityProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x41)
                {
                    List<Byte> bufferMeasuredTemperature = new(buffer.DequeueChunk(2));
                    IPartialParser measuredTemperature = MeasuredTemperature.GetParser();
                    ParsedData measuredTemperatureProcessData = measuredTemperature.Process(bufferMeasuredTemperature);
                    parsedData.AddParserErrorCode(measuredTemperatureProcessData.ParserErrorCode);
                    parsedData.AddCommandType(measuredTemperatureProcessData.CommandType);
                    parsedData.AddReading(measuredTemperatureProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x43)
                {
                    List<Byte> bufferMeasuredHumidity = new(buffer.DequeueChunk(2));
                    IPartialParser measuredHumidity = MeasuredHumidity.GetParser();
                    ParsedData measuredHumidityProcessData = measuredHumidity.Process(bufferMeasuredHumidity);
                    parsedData.AddParserErrorCode(measuredHumidityProcessData.ParserErrorCode);
                    parsedData.AddCommandType(measuredHumidityProcessData.CommandType);
                    parsedData.AddReading(measuredHumidityProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x45)
                {
                    List<Byte> bufferMeasuredLightIntensity = new(buffer.DequeueChunk(2));
                    IPartialParser measuredLightIntensity = MeasuredLightIntensity.GetParser();
                    ParsedData measuredLightIntensityProcessData = measuredLightIntensity.Process(bufferMeasuredLightIntensity);
                    parsedData.AddParserErrorCode(measuredLightIntensityProcessData.ParserErrorCode);
                    parsedData.AddCommandType(measuredLightIntensityProcessData.CommandType);
                    parsedData.AddReading(measuredLightIntensityProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x47)
                {
                    List<Byte> bufferPIRinitializationPeriod = new(buffer.DequeueChunk(2));
                    IPartialParser pirInitializationPeriod = PIRinitializationPeriod.GetParser();
                    ParsedData pirInitializationPeriodProcessData = pirInitializationPeriod.Process(bufferPIRinitializationPeriod);
                    parsedData.AddParserErrorCode(pirInitializationPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(pirInitializationPeriodProcessData.CommandType);
                    parsedData.AddReading(pirInitializationPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x49)
                {
                    List<Byte> bufferPIRmeasurementPeriod = new(buffer.DequeueChunk(2));
                    IPartialParser pirMeasurementPeriod = PIRmeasurementPeriod.GetParser();
                    ParsedData pirMeasurementPeriodProcessData = pirMeasurementPeriod.Process(bufferPIRmeasurementPeriod);
                    parsedData.AddParserErrorCode(pirMeasurementPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(pirMeasurementPeriodProcessData.CommandType);
                    parsedData.AddReading(pirMeasurementPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x4B)
                {
                    List<Byte> bufferPIRcheckPeriod = new(buffer.DequeueChunk(3));
                    IPartialParser pirCheckPeriod = PIRcheckPeriod.GetParser();
                    ParsedData pirCheckPeriodProcessData = pirCheckPeriod.Process(bufferPIRcheckPeriod);
                    parsedData.AddParserErrorCode(pirCheckPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(pirCheckPeriodProcessData.CommandType);
                    parsedData.AddReading(pirCheckPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x4D)
                {
                    List<Byte> bufferPIRblindPeriod = new(buffer.DequeueChunk(3));
                    IPartialParser pirBlindPeriod = PIRblindPeriod.GetParser();
                    ParsedData pirBlindPeriodProcessData = pirBlindPeriod.Process(bufferPIRblindPeriod);
                    parsedData.AddParserErrorCode(pirBlindPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(pirBlindPeriodProcessData.CommandType);
                    parsedData.AddReading(pirBlindPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x80)
                {
                    List<Byte> bufferCO2MeasurementBlindTime = new(buffer.DequeueChunk(2));
                    IPartialParser co2MeasurementBlindTime = CO2MeasurementBlindTime.GetParser();
                    ParsedData co2MeasurementBlindTimeProcessData = co2MeasurementBlindTime.Process(bufferCO2MeasurementBlindTime);
                    parsedData.AddParserErrorCode(co2MeasurementBlindTimeProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2MeasurementBlindTimeProcessData.CommandType);
                    parsedData.AddReading(co2MeasurementBlindTimeProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x83)
                {
                    List<Byte> bufferCO2RelatedImages = new(buffer.DequeueChunk(2));
                    IPartialParser co2RelatedImages = CO2RelatedImages.GetParser();
                    ParsedData co2RelatedImagesProcessData = co2RelatedImages.Process(bufferCO2RelatedImages);
                    parsedData.AddParserErrorCode(co2RelatedImagesProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2RelatedImagesProcessData.CommandType);
                    parsedData.AddReading(co2RelatedImagesProcessData.Reading);
                }
                else
                {
                    parsedData.AddParserErrorCode(ParserErrorCode.UnknownFrame);
                    return parsedData;
                }
            }

            return parsedData;
        }
    }
}