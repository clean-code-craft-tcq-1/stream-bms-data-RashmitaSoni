using System;
using System.Collections.Generic;

namespace BatteryReceiver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BatteryParameters batteryParameters;
            IBatteryReceiverParser batteryReceiverParser = new BatteryReceiverParser(); 
            BatteryReceiverCalculator batteryReceiverCalculator = new BatteryReceiverCalculator(batteryReceiverParser);
            DisplayBatteryReading displayBatteryReading = new DisplayBatteryReading();
            string StreamReading;
            List<string> BatteryReadingInputSet = new List<string>();
            while ((StreamReading = Console.ReadLine()) != null && (StreamReading = Console.ReadLine()) != "Battery Charging Parameters (Press Escape to exit)")
            {
                Console.WriteLine(StreamReading);
                BatteryReadingInputSet.Add(StreamReading);
                batteryParameters = batteryReceiverCalculator.GetMinMaxBatteryReadings(StreamReading);
                StreamBatteryReadings(BatteryReadingInputSet, batteryParameters, batteryReceiverCalculator, displayBatteryReading);
                if (BatteryReadingInputSet.Count == 15)
                    break;
            }
        }
        public static void StreamBatteryReadings(List<string> BatteryReadingInputSet, BatteryParameters batteryParameters, BatteryReceiverCalculator batteryReceiverCalculator, DisplayBatteryReading displayBatteryReading)
        {
            displayBatteryReading.DisplayMinMaxBatteryReadings(batteryParameters);
            if (BatteryReadingInputSet.Count > 5)
            {
                batteryParameters = batteryReceiverCalculator.GetAverageBatteryReadings(BatteryReadingInputSet.GetRange(BatteryReadingInputSet.Count - 5, 5));
                displayBatteryReading.DisplayAverageBatteryReadings(batteryParameters);
            }
        }
    }
}
