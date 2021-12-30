//@GeneratedCode
namespace SnQPoolIot.Logic.Controllers.Persistence.Account
{
    [Logic.Modules.Security.Authorize("SysAdmin", "AppAdmin")]
    sealed partial class AccessController : GenericPersistenceController<SnQPoolIot.Contracts.Persistence.Account.IAccess, Entities.Persistence.Account.Access>
    {
        static AccessController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal AccessController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal AccessController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
