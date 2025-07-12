using System;
using LoRaWANparser.MClimateCO2.Enums;

namespace LoRaWANparser.MClimateCO2.Models
{
    public class Reading
    {
        public ParameterType ParameterType { get; set; }
        public ReadingValueType ReadingValueType { get; set; }
        public Nullable<Double> Value { get; set; }
        public String ValueString { get; set; }
        public Unit Unit { get; set; }
    }
}