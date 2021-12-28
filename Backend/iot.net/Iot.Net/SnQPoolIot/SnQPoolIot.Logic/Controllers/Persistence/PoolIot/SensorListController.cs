//@GeneratedCode
namespace SnQPoolIot.Logic.Controllers.Persistence.PoolIot
{
    sealed partial class SensorListController : GenericPersistenceController<SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList, Entities.Persistence.PoolIot.SensorList>
    {
        static SensorListController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal SensorListController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal SensorListController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
