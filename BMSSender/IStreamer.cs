using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSender
{
    public interface IStreamer
    {
        void StreamBatteryChargingParameter(List<IGenerator> chargingparameter);
    }
}
