using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryReceiver
{
    public class Temperature
    {
        public float _minTemperature = float.MaxValue;
        public float _maxTemperature = float.MinValue;
        public float minTemperature
        {
            get { return _minTemperature; }
            set { _minTemperature = value; }
        }
        public float maxTemperature
        {
            get { return _maxTemperature; }
            set { _maxTemperature = value; }
        }
        public float TemperatureAverage { get; set; }
    }
}
