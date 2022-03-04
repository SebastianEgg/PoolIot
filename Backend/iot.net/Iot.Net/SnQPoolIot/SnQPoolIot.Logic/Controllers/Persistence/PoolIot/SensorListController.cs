//@GeneratedCode
namespace SnQPoolIot.Logic.Controllers.Persistence.PoolIot
{
    sealed partial class SensorController : GenericPersistenceController<SnQPoolIot.Contracts.Persistence.PoolIot.ISensor, Entities.Persistence.PoolIot.Sensor>
    {
        static SensorController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal SensorController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal SensorController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
