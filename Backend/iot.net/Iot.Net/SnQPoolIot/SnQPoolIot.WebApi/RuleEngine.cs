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

        private Dictionary<string, MqttMeasurmentDto> Sensors { get; set; } = new Dictionary<string,MqttMeasurmentDto>();

        private static RuleEngine _ruleEngine = null;

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
            _ruleEngine = new RuleEngine();
            MqttActions = new MqttActions();

            MqttActions.OnMqttMessageReceived += MqttActions_OnMqttMessageReceived;


            foreach (var sensorName in Enum.GetNames(typeof(SensorName)))
            {
                Sensors.Add(sensorName.ToLower(), null);
                MqttActions.StartMqttClientAndRegisterObserverAsync($"{sensorName.ToLower()}/state").Wait();
            }


            //var resNeopixel = MqttActions.StartMqttClientAndRegisterObserverAsync("neopixel/state");
            //var resNoise = MqttActions.StartMqttClientAndRegisterObserverAsync("noise/state");
            //var resTemperature = MqttActions.StartMqttClientAndRegisterObserverAsync("temperature/state");
            //var reshumidity = MqttActions.StartMqttClientAndRegisterObserverAsync("humidity/state");
            //var resPressure = MqttActions.StartMqttClientAndRegisterObserverAsync("pressure/state");
            //var resMotion = MqttActions.StartMqttClientAndRegisterObserverAsync("motion/state");
            //var resCo2 = MqttActions.StartMqttClientAndRegisterObserverAsync("co2/state");

        }

        private void MqttActions_OnMqttMessageReceived(object sender, DataTransferObjects.MqttMeasurmentDto measurmentDto)
        {
            var sensor = Sensors[measurmentDto.SensorName];
            if(sensor != null)
            {
                Sensors[measurmentDto.SensorName] = measurmentDto;
                if(measurmentDto.SensorName == SensorName.Noise.ToString().ToLower())
                {
                    CheckNoiceSensorData(int.Parse(measurmentDto.Value));
                }
            }
            else
            {
                throw new ApplicationException($"Sensor {measurmentDto.SensorName} does not exist");
            }

        }

        public static int CheckNoiceSensorData(int? sensorValue)
        {
            var result = 0;

            if (sensorValue == null)
            {
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
