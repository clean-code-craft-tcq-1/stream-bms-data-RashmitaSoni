using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryReceiver
{
    public class DisplayBatteryReading
    {
        public void DisplayMinMaxBatteryReadings(BatteryParameters batteryParameters)
        {
            Console.WriteLine("Minimum Temperature - {0} Maximum Temperature - {1}\n" + "Minimum StateOfCharge - {2} Maximum StateOfCharge - {3}", batteryParameters.Temperature.minTemperature,
                                                batteryParameters.Temperature.maxTemperature, batteryParameters.StateOfCharge.minStateOfCharge, batteryParameters.StateOfCharge.maxStateOfCharge);
        }

        public void DisplayAverageBatteryReadings(BatteryParameters batteryParameters)
        {
            Console.WriteLine("Average Temperature - {0} Average StateOfCharge - {1}", batteryParameters.Temperature.TemperatureAverage, batteryParameters.StateOfCharge.StateOfChargeAverage);
        }
    }
}
