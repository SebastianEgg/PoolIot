//@GeneratedCode
namespace SnQPoolIot.Logic.Controllers.Persistence.PoolIot
{
    sealed partial class SensorDataController : GenericPersistenceController<SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData, Entities.Persistence.PoolIot.SensorData>
    {
        static SensorDataController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal SensorDataController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal SensorDataController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
