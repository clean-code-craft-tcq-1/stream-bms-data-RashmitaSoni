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
            try
            {
                if (!IsParameterListEmpty(chargingparameter))
                {
                    Console.WriteLine("Battery Charging Parameters (Press Escape to exit)\n");
                    do
                    {
                        DisplayBatteryChargingParameter(chargingparameter);
                    } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please pass valid Battery Parameters");
            }
        }
        public void DisplayBatteryChargingParameter(List<IGenerator> chargingparameter)
        {
            try
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please pass valid Battery Parameters");
            }
        }
    }
}
