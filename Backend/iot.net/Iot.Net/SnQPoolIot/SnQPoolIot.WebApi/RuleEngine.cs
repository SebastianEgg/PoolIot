using SnQPoolIot.Logic;
using SnQPoolIot.Logic.Entities.Business.Logging;
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
                // Inserten der Sensoren, welche sich in der SensorBox befinden
                var hasInserted = InsertSensors(sensorName);
                Sensors.Add(sensorName.ToLower(), sensor);
                // Startet das Einlesen der Messwerte
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
                    LogWriter.Instance.LogWrite($"Sensor {measurmentDto.SensorName} does not exist");
                }
            }
            else
            {
                LogWriter.Instance.LogWrite($"The Sensor is null!");
            }

        }

        public static int CheckNoiceSensorData(int? sensorValue)
        {
            var result = 0;
            if (sensorValue == null)
            {
                LogWriter.Instance.LogWrite($"The SensorValue is null!");
                return -1;
            }
            else if (sensorValue > 300)
            {
                MessageNotification.SendMessageByTelegram("Achtung es wurden zu Laute Messwerte gemessen bitte schauen Sie nach worum es sich handelt!");
            }

            return result;
        }
        public static async Task<bool> InsertSensors(string sensorName)
        {
            using var ctrl = Factory.Create<Contracts.Persistence.PoolIot.ISensor>();
            Sensor addSensor = new Sensor();
            addSensor.Name = sensorName.ToLower();
            var sensors = ctrl.GetAllAsync();
            var sensorsArray = sensors.Result;
            var isSensorInstered = false;
            foreach (var item in sensorsArray)
            {
                if(item.Name == sensorName)
                {
                    isSensorInstered = true;
                }
            }
            if(isSensorInstered == false)
            {
                await ctrl.InsertAsync(addSensor);
                await ctrl.SaveChangesAsync();
            }
            

            return true;
        }
    }
}
