using SnQPoolIot.Transfer.Models.Persistence.PoolIot;
using SnQPoolIot.WebApi.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnQPoolIot.WebApi
{
    public enum SensorName
    {
        NeoPixel,
        Noise,
        Temperature,
        Humidity,
        Pressure,
        Motion,
        Co2
    }
    /// <summary>
    /// Singleton Implementierung für Zugriff auf die RuleEngine
    /// /// </summary>
    public class RuleEngine
    {

        private Dictionary<string, MqttMeasurementDto> Sensors { get; set; } = new Dictionary<string,MqttMeasurementDto>();

        private static RuleEngine _ruleEngine = null;

        public Logic.Entities.Business.Logging.LogWriter logWritter = new Logic.Entities.Business.Logging.LogWriter();

        public static RuleEngine Instance {
            get
            {
                if(_ruleEngine == null)
                {
                    _ruleEngine = new RuleEngine();
                }
                return _ruleEngine;
                   
            }
        }

        public MqttActions MqttActions { get; }

        private RuleEngine()
        {
            MqttActions = new MqttActions();

            MqttActions.OnMqttMessageReceived += MqttActions_OnMqttMessageReceived;


            foreach (var sensorName in Enum.GetNames(typeof(SensorName)))
            {
                MqttMeasurementDto sensor = new MqttMeasurementDto();
                Sensors.Add(sensorName.ToLower(), sensor);
                MqttActions.StartMqttClientAndRegisterObserverAsync($"{sensorName.ToLower()}/state").Wait();
            }

        }

        private void MqttActions_OnMqttMessageReceived(object sender, DataTransferObjects.MqttMeasurementDto measurmentDto)
        {
            var sensor = Sensors[measurmentDto.SensorName];
            if(sensor != null)
            {
                Sensors[measurmentDto.SensorName] = measurmentDto;
                if(measurmentDto.SensorName == SensorName.Noise.ToString().ToLower())
                {
                    CheckNoiceSensorData(int.Parse(measurmentDto.Value));
                }
                else
                {
                    logWritter.LogWrite($"Sensor {measurmentDto.SensorName} does not exist");
                }
            }
            else
            {
                logWritter.LogWrite($"The Sensor is null!");
            }

        }

        public static int CheckNoiceSensorData(int? sensorValue)
        {
            var result = 0;
            var logWritterInStaticMethod = new Logic.Entities.Business.Logging.LogWriter();
            if (sensorValue == null)
            {
                logWritterInStaticMethod.LogWrite($"The Sensor is null!");
                return -1;
            }
            else if (sensorValue > 300)
            {
                MessageNotification.SendMessageByTelegram("Achtung es wurden zu Laute Messwerte gemessen bitte schauen Sie noch warum es sich handelt");
            }

            return result;
        }
    }
}
