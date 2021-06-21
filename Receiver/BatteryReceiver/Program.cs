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
                displayBatteryReading.DisplayMinMaxBatteryReadings(batteryParameters);
                if (BatteryReadingInputSet.Count >= 5)
                {
                    batteryParameters = batteryReceiverCalculator.GetAverageBatteryReadings(BatteryReadingInputSet.GetRange(BatteryReadingInputSet.Count - 4, 4));
                    displayBatteryReading.DisplayAverageBatteryReadings(batteryParameters);
                }
            }
        }
    }
}
