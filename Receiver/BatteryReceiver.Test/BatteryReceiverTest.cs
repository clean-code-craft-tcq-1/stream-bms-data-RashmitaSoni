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
            List<string> inputStream = new List<string>() { };
            Assert.IsNull(new BatteryReceiverParser().GetBatteryReadingsFromInput(inputStream));
        }
        [TestMethod]
        public void GivenBatteryReadings_WhenBatteryReadingListIsValid_ReturnNotNull()
        {
            List<string> inputStream = new List<string>() { "Temperature : 10\tState of Charge : 0.4" };
            Assert.IsNotNull(new BatteryReceiverParser().GetBatteryReadingsFromInput(inputStream));
        }
        [TestMethod]
        public void GivenBatteryReadings_WhenBatteryReadingListHasValues_ReturnMaximumTemperature()
        {
            BatteryReceiverCalculator batteryReceiverCalculator = new BatteryReceiverCalculator(_batteryParser);
            string inputStream = "Temperature : 10\tState of Charge : 0.4";
            Assert.IsTrue(10 == batteryReceiverCalculator.GetMinMaxBatteryReadings(inputStream).Temperature.maxTemperature);
        }
        [TestMethod]
        public void GivenBatteryReadings_WhenBatteryReadingListHasValues_ReturnMinimumTemperature()
        {
            BatteryReceiverCalculator batteryReceiverCalculator = new BatteryReceiverCalculator(_batteryParser);
            string inputStream = "Temperature : 10\tState of Charge : 0.4";
            Assert.IsTrue(10 == batteryReceiverCalculator.GetMinMaxBatteryReadings(inputStream).Temperature.minTemperature);
        }
        [TestMethod]
        public void GivenBatteryReadings_WhenBatteryReadingListHasValues_ReturnAverageCount()
        {
            BatteryReceiverCalculator batteryReceiverCalculator = new BatteryReceiverCalculator(_batteryParser);
            List<string> inputStream = new List<string>() { "Temperature : 10\tState of Charge : 0.4", "Temperature : 20\tState of Charge : 0.6" };
            Assert.IsTrue(15 == batteryReceiverCalculator.GetAverageBatteryReadings(inputStream).Temperature.TemperatureAverage);
        }
    }
}
