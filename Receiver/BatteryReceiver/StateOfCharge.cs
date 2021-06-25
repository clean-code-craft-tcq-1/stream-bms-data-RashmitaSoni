using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryReceiver
{
    public class StateOfCharge
    {
        public float _minStateOfCharge = float.MaxValue;
        public float _maxStateOfCharge = float.MinValue;
        public float minStateOfCharge
        {
            get { return _minStateOfCharge; }
            set { _minStateOfCharge = value; }
        }
        public float maxStateOfCharge
        {
            get { return _maxStateOfCharge; }
            set { _maxStateOfCharge = value; }
        }
        public float StateOfChargeAverage { get; set; }
    }
}
