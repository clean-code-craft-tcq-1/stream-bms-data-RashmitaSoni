using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryReceiver
{
    public class BatteryParameters
    {
        public BatteryParameters()
        {
            Temperature = new Temperature();
            StateOfCharge = new StateOfCharge();
        }
        public Temperature Temperature { get; set; }
        public StateOfCharge StateOfCharge { get; set; }
    }
}
