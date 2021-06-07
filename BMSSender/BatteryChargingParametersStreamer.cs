using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BMSSender
{
    public class BatteryChargingParametersStreamer : IStreamer
    {
        public static bool IsParameterListEmpty(List<IGenerator> chargingparameterlist)
        {
            return (!chargingparameterlist.Any());
        }
        public void StreamBatteryChargingParameter(List<IGenerator> chargingparameter)
        {
            if (!IsParameterListEmpty(chargingparameter))
            {
                Console.WriteLine("Battery Charging Parameters (Press Escape to exit)\n");
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Console.WriteLine("Temperature : {0}\tState of Charge : {1}",
                            chargingparameter[0].GenerateBatteryChargingParameter(BatteryParametersConstants.minimumChargingTemprature_Celsius,
                                                                         BatteryParametersConstants.maximumChargingTemprature_Celsius),

                            chargingparameter[1].GenerateBatteryChargingParameter(BatteryParametersConstants.minimumStateOfCharge_Percentage,
                                                                 BatteryParametersConstants.maximumStateOfCharge_Percentage)
                            );
                        Thread.Sleep(2000);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
        }
    }
}
