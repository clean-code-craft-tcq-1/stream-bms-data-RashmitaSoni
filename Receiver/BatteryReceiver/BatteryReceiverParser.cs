using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryReceiver
{
    public class BatteryReceiverParser : IBatteryReceiverParser
    {
        public string TemperatureValue, StateOfChargeValue;
        public List<BatteryConstants> GetBatteryReadingsFromInput(List<string> BatteryReadings)
        {
            List<BatteryConstants> batteryConstants = new List<BatteryConstants>();
            if (BatteryReadings.Count == 0)
            {
                return null;
            }
            foreach ( string reading in BatteryReadings)
            {
                BatteryConstants batteryConstantValues = new BatteryConstants();
                string[] batteryReadingValue = reading.Split(" ");
                GetValue(batteryReadingValue);
                batteryConstantValues.Temperature = (float)Convert.ToDouble(TemperatureValue);
                batteryConstantValues.StateOfCharge = (float)Convert.ToDouble(StateOfChargeValue);
                batteryConstants.Add(batteryConstantValues);
            }
            return batteryConstants;
        }
        public void GetValue(string[] batteryReading)
        {
            for ( int i = 0; i < batteryReading.Length; i++)
            {
                if (batteryReading[i] == "Temperature")
                {
                    TemperatureValue = batteryReading[i + 2];
                    break;
                }
            }
            StateOfChargeValue = batteryReading[batteryReading.Length - 1];
        }
        
    }
}
