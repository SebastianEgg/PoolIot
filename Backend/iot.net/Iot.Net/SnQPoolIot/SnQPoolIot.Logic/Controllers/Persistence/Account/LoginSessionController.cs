//@GeneratedCode
namespace SnQPoolIot.Logic.Controllers.Persistence.Account
{
    [Logic.Modules.Security.Authorize("SysAdmin", "AppAdmin")]
    sealed partial class LoginSessionController : GenericPersistenceController<SnQPoolIot.Contracts.Persistence.Account.ILoginSession, Entities.Persistence.Account.LoginSession>
    {
        static LoginSessionController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal LoginSessionController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal LoginSessionController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
