//@GeneratedCode
namespace SnQPoolIot.Logic.Controllers.Persistence.Account
{
    [Logic.Modules.Security.Authorize("SysAdmin", "AppAdmin")]
    sealed partial class IdentityXRoleController : GenericPersistenceController<SnQPoolIot.Contracts.Persistence.Account.IIdentityXRole, Entities.Persistence.Account.IdentityXRole>
    {
        static IdentityXRoleController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal IdentityXRoleController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal IdentityXRoleController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
