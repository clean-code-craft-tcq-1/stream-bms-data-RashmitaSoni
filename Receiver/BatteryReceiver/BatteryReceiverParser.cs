using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryReceiver
{
    public class BatteryReceiverParser : IBatteryReceiverParser
    {
        public string TemperatureValue, StateOfChargeValue;
        public char BatteryParameterDelimeter = '\t';
        public char ValueDelimeter = ':';
        public List<BatteryConstants> GetBatteryReadingsFromInput(List<string> BatteryReadings)
        {
            List<BatteryConstants> batteryConstants = new List<BatteryConstants>();
            if (BatteryReadings.Count == 0)
            {
                return null;
            }
            foreach (string reading in BatteryReadings)
            {
                BatteryConstants batteryConstantValues = new BatteryConstants();
                string[] batteryReadingValue = reading.Split(BatteryParameterDelimeter);
                GetValue(batteryReadingValue);
                batteryConstantValues.Temperature = float.Parse(TemperatureValue);
                batteryConstantValues.StateOfCharge = float.Parse(StateOfChargeValue);
                batteryConstants.Add(batteryConstantValues);
            }
            return batteryConstants;
        }
        public void GetValue(string[] batteryReading)
        {
            string[] temp = batteryReading[0].Split(ValueDelimeter);
            TemperatureValue = temp[1].Trim();
            string[] soc = batteryReading[1].Split(ValueDelimeter);
            StateOfChargeValue = soc[1].Trim();
        }   
    }
}
