using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSender
{
    public interface IGenerator
    {
        float GenerateBatteryChargingParameter(float minimumlimit, float maximumlimit);
    }
}
