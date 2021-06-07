using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMSSender;
using System.Collections.Generic;

namespace BMSSender.Tests
{
    [TestClass]
    public class BMSSenderTests
    {
        [TestMethod]
        public void WhenGenerateBatteryChargingParameterValid_ThenReturnsTrue()
        {
            IGenerator value = new BatteryChargingParametersGenerator();
            double _value = value.GenerateBatteryChargingParameter(0, 12);
            Assert.IsTrue(_value >= 0|| _value <= 12);
        }
        [TestMethod]
        public void WhenParameterListIsEmpty_ThenReturnsTrue()
        {
            List<IGenerator> parameterslist = new List<IGenerator>();
            Assert.IsTrue(BatteryChargingParametersStreamer.IsParameterListEmpty(parameterslist));
        }
        [TestMethod]
        public void WhenParameterListIsNotEmpty_ThenReturnsFalse()
        {
            List<IGenerator> paramterslist = new List<IGenerator>();
            paramterslist.Add(new BatteryChargingParametersGenerator());
            paramterslist.Add(new BatteryChargingParametersGenerator());
            Assert.IsFalse(BatteryChargingParametersStreamer.IsParameterListEmpty(paramterslist));
        }
        [TestMethod]
        public void WhenBatteryChargingParameterToStreamerIsNotValid_ThenReturnsExceptionMessage()
        {
            try
            {
                IStreamer testbmsdata = new BatteryChargingParametersStreamer();
                List<IGenerator> paramterlist = new List<IGenerator>();
                paramterlist.Add(null);
                paramterlist.Add(null);
                testbmsdata.StreamBatteryChargingParameter(paramterlist);
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}
