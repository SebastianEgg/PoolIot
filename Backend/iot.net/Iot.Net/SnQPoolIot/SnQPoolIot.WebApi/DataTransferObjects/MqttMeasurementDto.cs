using System;

namespace SnQPoolIot.WebApi.DataTransferObjects
{
    public class MqttMeasurementDto
    {
        //public event EventHandler OnMeasurementCreated;
        public int SensorId { get; set; }

        public string SensorName { get; set; }

        public DateTime Timestamp { get; set; }

        public string Value { get; set; }

    }
}
