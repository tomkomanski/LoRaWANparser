using System;
using LoRaWANparser.MClimateCO2Display.Enums;

namespace LoRaWANparser.MClimateCO2Display.Models
{
    public class ParsedData
    {
        private List<ParserErrorCode> parserErrorCode = new();
        private List<CommandType> commandType = new();
        private List<Reading> reading = new();

        public IEnumerable<ParserErrorCode> ParserErrorCode
        {
            get
            {
                return this.parserErrorCode;
            }
        }

        public IEnumerable<CommandType> CommandType
        {
            get
            {
                return this.commandType;
            }
        }

        public IEnumerable<Reading> Reading
        {
            get
            {
                return this.reading;
            }
        }

        public void AddParserErrorCode(ParserErrorCode parserErrorCode)
        {
            this.parserErrorCode.Add(parserErrorCode);
        }

        public void AddCommandType(CommandType commandType)
        {
            this.commandType.Add(commandType);
        }

        public void AddReading(Reading reading)
        {
            this.reading.Add(reading);
        }

        public void AddParserErrorCode(IEnumerable<ParserErrorCode> parserErrorCode)
        {
            this.parserErrorCode.AddRange(parserErrorCode);
        }

        public void AddCommandType(IEnumerable<CommandType> commandType)
        {
            this.commandType.AddRange(commandType);
        }

        public void AddReading(IEnumerable<Reading> reading)
        {
            this.reading.AddRange(reading);
        }
    }
}