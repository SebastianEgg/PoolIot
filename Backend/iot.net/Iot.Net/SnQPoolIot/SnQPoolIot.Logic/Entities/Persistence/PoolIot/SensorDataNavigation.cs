//@GeneratedCode
namespace SnQPoolIot.Logic.Entities.Persistence.PoolIot
{
    partial class SensorData
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("SensorId")]
        public SnQPoolIot.Logic.Entities.Persistence.PoolIot.Sensor Sensor
        {
            get;
            set;
        }
    }
}
