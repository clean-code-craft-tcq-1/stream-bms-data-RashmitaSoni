using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSSender
{
    public class BatteryChargingParametersGenerator : IGenerator
    {
        Random randomvalue = new Random();
        public float GenerateBatteryChargingParameter(float minimumlimit, float maximumlimit)
        {
            return (float)Math.Round((randomvalue.NextDouble() * (maximumlimit - minimumlimit) + minimumlimit), 2);
        }

    }
}
