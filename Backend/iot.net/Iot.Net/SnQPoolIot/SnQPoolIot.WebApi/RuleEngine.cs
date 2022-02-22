using SnQPoolIot.Transfer.Models.Persistence.PoolIot;
using System.Threading.Tasks;

namespace SnQPoolIot.WebApi
{
    public class RuleEngine
    {
        public static int CheckNoiceSensorData(int? sensorValue)
        {
            var result = 0;

            if (sensorValue == null)
            {
                return -1;
            }
            else if (sensorValue > 300)
            {
                MessageNotification.MessageTelegramm("Achtung es wurden zu Laute Messwerte gemessen bitte schauen Sie noch warum es sich handelt");
            }

            return result;
        }
    }
}
