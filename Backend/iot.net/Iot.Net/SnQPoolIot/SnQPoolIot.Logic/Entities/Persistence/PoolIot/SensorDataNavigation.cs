//@GeneratedCode
namespace SnQPoolIot.Logic.Entities.Persistence.PoolIot
{
    partial class SensorData
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("SensorListId")]
        public SnQPoolIot.Logic.Entities.Persistence.PoolIot.SensorList SensorList
        {
            get;
            set;
        }
    }
}
