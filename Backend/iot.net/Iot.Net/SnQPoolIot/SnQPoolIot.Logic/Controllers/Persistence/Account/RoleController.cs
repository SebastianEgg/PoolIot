//@GeneratedCode
namespace SnQPoolIot.Logic.Controllers.Persistence.Account
{
    [Logic.Modules.Security.Authorize("SysAdmin", "AppAdmin")]
    sealed partial class RoleController : GenericPersistenceController<SnQPoolIot.Contracts.Persistence.Account.IRole, Entities.Persistence.Account.Role>
    {
        static RoleController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal RoleController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal RoleController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
