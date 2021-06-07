using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSender
{
    public class BMSSender
    {
        public static void Main()
        {
            IStreamer bmsdata = new BatteryChargingParametersStreamer();
            List<IGenerator> paramterslist = new List<IGenerator>();
            paramterslist.Add(new BatteryChargingParametersGenerator());
            paramterslist.Add(new BatteryChargingParametersGenerator());
            bmsdata.StreamBatteryChargingParameter(paramterslist);
        }
    }
}
