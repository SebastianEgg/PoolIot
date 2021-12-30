//@GeneratedCode
namespace SnQPoolIot.Logic.Controllers.Persistence.Account
{
    sealed partial class ActionLogController : GenericPersistenceController<SnQPoolIot.Contracts.Persistence.Account.IActionLog, Entities.Persistence.Account.ActionLog>
    {
        static ActionLogController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal ActionLogController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal ActionLogController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
