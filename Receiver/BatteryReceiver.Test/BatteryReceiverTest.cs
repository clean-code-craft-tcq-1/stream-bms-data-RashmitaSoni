using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BatteryReceiver.Test
{
    [TestClass]
    public class BatteryReceiverTest
    {
        IBatteryReceiverParser _batteryParser = new BatteryReceiverParser();
        [TestMethod]
        public void GivenEmptyReadings_WhenBatteryReadingIsNull_ReturnNull()
        {
            BatteryReceiverParser batteryReceiverParser = new BatteryReceiverParser();
            List<BatteryConstants> batteryConstants;
            List<string> inputStream = new List<string>() { };
            batteryConstants = batteryReceiverParser.GetBatteryReadingsFromInput(inputStream);
            Assert.IsNull(batteryConstants);
        }
        [TestMethod]
        public void GivenBatteryReadings_WhenBatteryreadingListIsValid_ReturnNotNull()
        {
            BatteryReceiverParser batteryReceiverParser = new BatteryReceiverParser();
            List<BatteryConstants> batteryConstants;
            List<string> inputStream = new List<string>() { "Temperature : 10  State of Charge : 0.4" };
            batteryConstants = batteryReceiverParser.GetBatteryReadingsFromInput(inputStream);
            Assert.IsNotNull(batteryConstants);
        }
        [TestMethod]
        public void GivenBatteryReadings_WhenBatteryreadingListIsValid_ReturnMaximumTemperature()
        {
            BatteryReceiverCalculator batteryReceiverCalculator = new BatteryReceiverCalculator(_batteryParser);
            BatteryParameters batteryParameters;
            string inputStream = "Temperature : 10  State of Charge : 0.4";
            batteryParameters = batteryReceiverCalculator.GetMinMaxBatteryReadings(inputStream);
            Assert.IsTrue(10 == batteryParameters.Temperature.maxTemperature);
        }

        [TestMethod]
        public void GivenBatteryReadings_WhenBatteryreadingListIsValid_ReturnAverageCount()
        {
            BatteryReceiverCalculator batteryReceiverCalculator = new BatteryReceiverCalculator(_batteryParser);
            BatteryParameters batteryParameters;
            List<string> inputStream = new List<string>() { "Temperature : 10  State of Charge : 0.4", "Temperature : 20  State of Charge : 0.6" };
            batteryParameters = batteryReceiverCalculator.GetAverageBatteryReadings(inputStream);
            Assert.IsTrue(15 == batteryParameters.Temperature.TemperatureAverage);
        }
    }
}
