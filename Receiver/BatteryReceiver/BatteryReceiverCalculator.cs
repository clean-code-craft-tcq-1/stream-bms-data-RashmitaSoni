using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryReceiver
{
    public class BatteryReceiverCalculator
    {
        public BatteryParameters batteryParameters;
        public IBatteryReceiverParser _batteryReceiverParser;
        public BatteryReceiverCalculator(IBatteryReceiverParser batteryReceiverParser)
        {
            _batteryReceiverParser = batteryReceiverParser;
            batteryParameters = new BatteryParameters();
        }
        public BatteryParameters GetMinMaxBatteryReadings(string BatteryData)
        {
            if (!string.IsNullOrEmpty(BatteryData))
            {
                List<BatteryConstants> batteryConstants = _batteryReceiverParser.GetBatteryReadingsFromInput(new List<string>() { BatteryData });
                CalculateMinimumReading(batteryConstants[0]);
                CalculateMaximumReading(batteryConstants[0]);
                return batteryParameters;
            }
            return null;
        }
        public BatteryParameters GetAverageBatteryReadings(List<string> batteryInputParameters)
        {
            List<BatteryConstants> batteryConstants = _batteryReceiverParser.GetBatteryReadingsFromInput(batteryInputParameters);
            CalculateReadingAverage(batteryConstants);
            return batteryParameters;
        }
        public void CalculateMinimumReading(BatteryConstants batteryConstants)
        {
            batteryParameters.Temperature.minTemperature = Math.Min(batteryParameters.Temperature.minTemperature, batteryConstants.Temperature);
            batteryParameters.StateOfCharge.minStateOfCharge = Math.Min(batteryParameters.StateOfCharge.minStateOfCharge, batteryConstants.StateOfCharge);
        }
        public void CalculateMaximumReading(BatteryConstants batteryConstants)
        {
            batteryParameters.Temperature.maxTemperature = Math.Max(batteryParameters.Temperature.maxTemperature, batteryConstants.Temperature);
            batteryParameters.StateOfCharge.maxStateOfCharge = Math.Max(batteryParameters.StateOfCharge.maxStateOfCharge, batteryConstants.StateOfCharge);
        }
        public void CalculateReadingAverage(List<BatteryConstants> batteryConstants)
        {
            float sumOfTemperature = 0;
            float sumOfStateOfCharge = 0;
            if (batteryConstants.Count <= 0)
                return;
            batteryParameters.Temperature.TemperatureAverage = batteryConstants[0].Temperature;
            batteryParameters.StateOfCharge.StateOfChargeAverage = batteryConstants[0].StateOfCharge;
            foreach (BatteryConstants batteryConstant in batteryConstants)
            {
                sumOfTemperature += batteryConstant.Temperature;
                sumOfStateOfCharge += batteryConstant.StateOfCharge;
            }
            batteryParameters.Temperature.TemperatureAverage = sumOfTemperature / batteryConstants.Count;
            batteryParameters.StateOfCharge.StateOfChargeAverage = sumOfStateOfCharge / batteryConstants.Count;
        }
    }
}
