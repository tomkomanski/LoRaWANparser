using System;
using LoRaWANparser.MClimateCO2Display.Enums;
using LoRaWANparser.MClimateCO2Display.Models;
using LoRaWANparser.MClimateCO2Display.Parsers;
using LoRaWANparser.Tools;

namespace LoRaWANparser.MClimateCO2Display
{
    public class Parser
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
                    KeepAlive keepAlive = new();
                    ParsedData keepAliveProcessData = keepAlive.KeepAliveProcess(bufferKeepAlive);
                    parsedData.AddParserErrorCode(keepAliveProcessData.ParserErrorCode);
                    parsedData.AddCommandType(keepAliveProcessData.CommandType);
                    parsedData.AddReading(keepAliveProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x04)
                {
                    List<Byte> bufferHardwareAndSoftware = new(buffer.DequeueChunk(3));
                    HardwareAndSoftware hardwareAndSoftware = new();
                    ParsedData hardwareAndSoftwareProcessData = hardwareAndSoftware.HardwareAndSoftwareProcess(bufferHardwareAndSoftware);
                    parsedData.AddParserErrorCode(hardwareAndSoftwareProcessData.ParserErrorCode);
                    parsedData.AddCommandType(hardwareAndSoftwareProcessData.CommandType);
                    parsedData.AddReading(hardwareAndSoftwareProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x12)
                {
                    List<Byte> bufferKeepAlivePeriod = new(buffer.DequeueChunk(2));
                    KeepAlivePeriod keepAlivePeriod = new();
                    ParsedData keepAlivePeriodProcessData = keepAlivePeriod.KeepAlivePeriodProcess(bufferKeepAlivePeriod);
                    parsedData.AddParserErrorCode(keepAlivePeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(keepAlivePeriodProcessData.CommandType);
                    parsedData.AddReading(keepAlivePeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x14)
                {
                    List<Byte> bufferChildLock = new(buffer.DequeueChunk(2));
                    ChildLock childLock = new();
                    ParsedData childLockProcessData = childLock.ChildLockProcess(bufferChildLock);
                    parsedData.AddParserErrorCode(childLockProcessData.ParserErrorCode);
                    parsedData.AddCommandType(childLockProcessData.CommandType);
                    parsedData.AddReading(childLockProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x19)
                {
                    List<Byte> bufferNetworkJoinRetryPeriod = new(buffer.DequeueChunk(2));
                    NetworkJoinRetryPeriod networkJoinRetryPeriod = new();
                    ParsedData networkJoinRetryPeriodProcessData = networkJoinRetryPeriod.NetworkJoinRetryPeriodProcess(bufferNetworkJoinRetryPeriod);
                    parsedData.AddParserErrorCode(networkJoinRetryPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(networkJoinRetryPeriodProcessData.CommandType);
                    parsedData.AddReading(networkJoinRetryPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x1B)
                {
                    List<Byte> bufferUplinkMessages = new(buffer.DequeueChunk(2));
                    UplinkMessages uplinkMessages = new();
                    ParsedData uplinkMessagesProcessData = uplinkMessages.UplinkMessagesProcess(bufferUplinkMessages);
                    parsedData.AddParserErrorCode(uplinkMessagesProcessData.ParserErrorCode);
                    parsedData.AddCommandType(uplinkMessagesProcessData.CommandType);
                    parsedData.AddReading(uplinkMessagesProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x1D)
                {
                    List<Byte> bufferRadioCommunicationWatchDog = new(buffer.DequeueChunk(3));
                    RadioCommunicationWatchDog radioCommunicationWatchDog = new();
                    ParsedData radioCommunicationWatchDogProcessData = radioCommunicationWatchDog.RadioCommunicationWatchDogProcess(bufferRadioCommunicationWatchDog);
                    parsedData.AddParserErrorCode(radioCommunicationWatchDogProcessData.ParserErrorCode);
                    parsedData.AddCommandType(radioCommunicationWatchDogProcessData.CommandType);
                    parsedData.AddReading(radioCommunicationWatchDogProcessData.Reading);
                }
                else if (buffer.Count() >= 5 && buffer.First() == 0x1F)
                {
                    List<Byte> bufferCO2BoundaryLevels = new(buffer.DequeueChunk(5));
                    CO2BoundaryLevels co2BoundaryLevels = new();
                    ParsedData co2BoundaryLevelsProcessData = co2BoundaryLevels.CO2BoundaryLevelsProcess(bufferCO2BoundaryLevels);
                    parsedData.AddParserErrorCode(co2BoundaryLevelsProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2BoundaryLevelsProcessData.CommandType);
                    parsedData.AddReading(co2BoundaryLevelsProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x21)
                {
                    List<Byte> bufferCO2AutoZeroValue = new(buffer.DequeueChunk(3));
                    CO2AutoZeroValue co2AutoZeroValue = new();
                    ParsedData co2AutoZeroValueProcessData = co2AutoZeroValue.CO2AutoZeroValueProcess(bufferCO2AutoZeroValue);
                    parsedData.AddParserErrorCode(co2AutoZeroValueProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2AutoZeroValueProcessData.CommandType);
                    parsedData.AddReading(co2AutoZeroValueProcessData.Reading);
                }
                else if (buffer.Count() >= 4 && buffer.First() == 0x25)
                {
                    List<Byte> bufferCO2MeasurementPeriod = new(buffer.DequeueChunk(4));
                    CO2MeasurementPeriod co2MeasurementPeriod = new();
                    ParsedData co2MeasurementPeriodProcessData = co2MeasurementPeriod.CO2MeasurementPeriodProcess(bufferCO2MeasurementPeriod);
                    parsedData.AddParserErrorCode(co2MeasurementPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2MeasurementPeriodProcessData.CommandType);
                    parsedData.AddReading(co2MeasurementPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x2B)
                {
                    List<Byte> bufferCO2AutoZeroPeriod = new(buffer.DequeueChunk(2));
                    CO2AutoZeroPeriod co2AutoZeroPeriod = new();
                    ParsedData co2AutoZeroPeriodProcessData = co2AutoZeroPeriod.CO2AutoZeroPeriodProcess(bufferCO2AutoZeroPeriod);
                    parsedData.AddParserErrorCode(co2AutoZeroPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2AutoZeroPeriodProcessData.CommandType);
                    parsedData.AddReading(co2AutoZeroPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x34)
                {
                    List<Byte> bufferFullDisplayRefresh = new(buffer.DequeueChunk(2));
                    FullDisplayRefresh fullDisplayRefresh = new();
                    ParsedData fullDisplayRefreshProcessData = fullDisplayRefresh.FullDisplayRefreshProcess(bufferFullDisplayRefresh);
                    parsedData.AddParserErrorCode(fullDisplayRefreshProcessData.ParserErrorCode);
                    parsedData.AddCommandType(fullDisplayRefreshProcessData.CommandType);
                    parsedData.AddReading(fullDisplayRefreshProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x3D)
                {
                    List<Byte> bufferPIRstatus = new(buffer.DequeueChunk(2));
                    PIRstatus pirStatus = new();
                    ParsedData pirStatusProcessData = pirStatus.PIRstatusProcess(bufferPIRstatus);
                    parsedData.AddParserErrorCode(pirStatusProcessData.ParserErrorCode);
                    parsedData.AddCommandType(pirStatusProcessData.CommandType);
                    parsedData.AddReading(pirStatusProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x3F)
                {
                    List<Byte> bufferPIRsensitivity = new(buffer.DequeueChunk(2));
                    PIRsensitivity pirSensitivity = new();
                    ParsedData pirSensitivityProcessData = pirSensitivity.PIRsensitivityProcess(bufferPIRsensitivity);
                    parsedData.AddParserErrorCode(pirSensitivityProcessData.ParserErrorCode);
                    parsedData.AddCommandType(pirSensitivityProcessData.CommandType);
                    parsedData.AddReading(pirSensitivityProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x41)
                {
                    List<Byte> bufferMeasuredTemperature = new(buffer.DequeueChunk(2));
                    MeasuredTemperature measuredTemperature = new();
                    ParsedData measuredTemperatureProcessData = measuredTemperature.MeasuredTemperatureProcess(bufferMeasuredTemperature);
                    parsedData.AddParserErrorCode(measuredTemperatureProcessData.ParserErrorCode);
                    parsedData.AddCommandType(measuredTemperatureProcessData.CommandType);
                    parsedData.AddReading(measuredTemperatureProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x43)
                {
                    List<Byte> bufferMeasuredHumidity = new(buffer.DequeueChunk(2));
                    MeasuredHumidity measuredHumidity = new();
                    ParsedData measuredHumidityProcessData = measuredHumidity.MeasuredHumidityProcess(bufferMeasuredHumidity);
                    parsedData.AddParserErrorCode(measuredHumidityProcessData.ParserErrorCode);
                    parsedData.AddCommandType(measuredHumidityProcessData.CommandType);
                    parsedData.AddReading(measuredHumidityProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x45)
                {
                    List<Byte> bufferMeasuredLightIntensity = new(buffer.DequeueChunk(2));
                    MeasuredLightIntensity measuredLightIntensity = new();
                    ParsedData measuredLightIntensityProcessData = measuredLightIntensity.MeasuredLightIntensityProcess(bufferMeasuredLightIntensity);
                    parsedData.AddParserErrorCode(measuredLightIntensityProcessData.ParserErrorCode);
                    parsedData.AddCommandType(measuredLightIntensityProcessData.CommandType);
                    parsedData.AddReading(measuredLightIntensityProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x47)
                {
                    List<Byte> bufferPIRinitializationPeriod = new(buffer.DequeueChunk(2));
                    PIRinitializationPeriod pirInitializationPeriod = new();
                    ParsedData pirInitializationPeriodProcessData = pirInitializationPeriod.PIRinitializationPeriodProcess(bufferPIRinitializationPeriod);
                    parsedData.AddParserErrorCode(pirInitializationPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(pirInitializationPeriodProcessData.CommandType);
                    parsedData.AddReading(pirInitializationPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x49)
                {
                    List<Byte> bufferPIRmeasurementPeriod = new(buffer.DequeueChunk(2));
                    PIRmeasurementPeriod pirMeasurementPeriod = new();
                    ParsedData pirMeasurementPeriodProcessData = pirMeasurementPeriod.PIRmeasurementPeriodProcess(bufferPIRmeasurementPeriod);
                    parsedData.AddParserErrorCode(pirMeasurementPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(pirMeasurementPeriodProcessData.CommandType);
                    parsedData.AddReading(pirMeasurementPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x4B)
                {
                    List<Byte> bufferPIRcheckPeriod = new(buffer.DequeueChunk(3));
                    PIRcheckPeriod pirCheckPeriod = new();
                    ParsedData pirCheckPeriodProcessData = pirCheckPeriod.PIRcheckPeriodProcess(bufferPIRcheckPeriod);
                    parsedData.AddParserErrorCode(pirCheckPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(pirCheckPeriodProcessData.CommandType);
                    parsedData.AddReading(pirCheckPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 3 && buffer.First() == 0x4D)
                {
                    List<Byte> bufferPIRblindPeriod = new(buffer.DequeueChunk(3));
                    PIRblindPeriod pirBlindPeriod = new();
                    ParsedData pirBlindPeriodProcessData = pirBlindPeriod.PIRblindPeriodProcess(bufferPIRblindPeriod);
                    parsedData.AddParserErrorCode(pirBlindPeriodProcessData.ParserErrorCode);
                    parsedData.AddCommandType(pirBlindPeriodProcessData.CommandType);
                    parsedData.AddReading(pirBlindPeriodProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x80)
                {
                    List<Byte> bufferCO2MeasurementBlindTime = new(buffer.DequeueChunk(2));
                    CO2MeasurementBlindTime co2MeasurementBlindTime = new();
                    ParsedData co2MeasurementBlindTimeProcessData = co2MeasurementBlindTime.CO2MeasurementBlindTimeProcess(bufferCO2MeasurementBlindTime);
                    parsedData.AddParserErrorCode(co2MeasurementBlindTimeProcessData.ParserErrorCode);
                    parsedData.AddCommandType(co2MeasurementBlindTimeProcessData.CommandType);
                    parsedData.AddReading(co2MeasurementBlindTimeProcessData.Reading);
                }
                else if (buffer.Count() >= 2 && buffer.First() == 0x83)
                {
                    List<Byte> bufferCO2RelatedImages = new(buffer.DequeueChunk(2));
                    CO2RelatedImages co2RelatedImages = new();
                    ParsedData co2RelatedImagesProcessData = co2RelatedImages.CO2RelatedImagesProcess(bufferCO2RelatedImages);
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