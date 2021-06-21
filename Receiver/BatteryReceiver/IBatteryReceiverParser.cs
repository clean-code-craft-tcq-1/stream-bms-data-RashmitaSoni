using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryReceiver
{
    public interface IBatteryReceiverParser
    {
        List<BatteryConstants> GetBatteryReadingsFromInput(List<string> BatteryReadings);
    }
}
