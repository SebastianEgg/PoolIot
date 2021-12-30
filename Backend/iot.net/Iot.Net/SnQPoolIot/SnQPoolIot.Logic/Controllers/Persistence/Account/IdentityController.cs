//@GeneratedCode
namespace SnQPoolIot.Logic.Controllers.Persistence.Account
{
    [Logic.Modules.Security.Authorize("SysAdmin", "AppAdmin")]
    sealed partial class IdentityController : GenericPersistenceController<SnQPoolIot.Contracts.Persistence.Account.IIdentity, Entities.Persistence.Account.Identity>
    {
        static IdentityController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal IdentityController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal IdentityController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
