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
        private static volatile bool _s_stop = false;
        public static bool IsParameterListEmpty(List<IGenerator> chargingparameterlist)
        {
            return (!chargingparameterlist.Any());
        }
        public void StreamBatteryChargingParameter(List<IGenerator> chargingparameter)
        {
                if (!IsParameterListEmpty(chargingparameter))
                {
                        DisplayBatteryChargingParameter(chargingparameter);
                }
        }
        public void DisplayBatteryChargingParameter(List<IGenerator> chargingparameter)
        {
            try
            {
                Console.WriteLine("Battery Charging Parameters\n");
                while (!_s_stop)
                {
                    Console.WriteLine("Temperature : {0}\tState of Charge : {1}",
                        chargingparameter[0].GenerateBatteryChargingParameter(BatteryParametersConstants.minimumChargingTemprature_Celsius,
                                                                     BatteryParametersConstants.maximumChargingTemprature_Celsius),

                        chargingparameter[1].GenerateBatteryChargingParameter(BatteryParametersConstants.minimumStateOfCharge_Percentage,
                                                             BatteryParametersConstants.maximumStateOfCharge_Percentage)
                        );
                    Thread.Sleep(2000);
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            _s_stop = true;
        }
    }
}
