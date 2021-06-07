using System;
using BMSSender;
using System.Collections.Generic;
using Xunit;

namespace BMSSender.Tests
{
    public class BMSSenderTests
    {
        [Fact]
        public void WhenGenerateBatteryChargingParameterValid_ThenReturnsTrue()
        {
            IGenerator value = new BatteryChargingParametersGenerator();
            double _value = value.GenerateBatteryChargingParameter(0, 12);
            Assert.True(_value >= 0|| _value <= 12);
        }
        [Fact]
        public void WhenParameterListIsEmpty_ThenReturnsTrue()
        {
            List<IGenerator> parameterslist = new List<IGenerator>();
            Assert.True(BatteryChargingParametersStreamer.IsParameterListEmpty(parameterslist));
        }
        [Fact]
        public void WhenParameterListIsNotEmpty_ThenReturnsFalse()
        {
            List<IGenerator> paramterslist = new List<IGenerator>();
            paramterslist.Add(new BatteryChargingParametersGenerator());
            paramterslist.Add(new BatteryChargingParametersGenerator());
            Assert.False(BatteryChargingParametersStreamer.IsParameterListEmpty(paramterslist));
        }
        [Fact]
        public void WhenBatteryChargingParameterToStreamerIsNotValid_ThenReturnsExceptionMessage()
        {
            IStreamer testbmsdata = new BatteryChargingParametersStreamer();
            List<IGenerator> paramterlist = new List<IGenerator>();
            paramterlist.Add(null);
            paramterlist.Add(null);
            var exception = Record.Exception(() => testbmsdata.StreamBatteryChargingParameter(paramterlist));
            Assert.NotNull(exception);
        }
        [Fact]
        public void WhenDisplayFunctionIsNotValid_ThenReturnsExceptionMessage()
        {
                BatteryChargingParametersStreamer testdisplaymethod = new BatteryChargingParametersStreamer();
                List<IGenerator> paramterlist = new List<IGenerator>();
                paramterlist.Add(null);
                paramterlist.Add(null);
                testdisplaymethod.DisplayBatteryChargingParameter(paramterlist);
                var exception = Record.Exception(() => testdisplaymethod.DisplayBatteryChargingParameter(paramterlist));
                Assert.NotNull(exception);
        }
    }
}
