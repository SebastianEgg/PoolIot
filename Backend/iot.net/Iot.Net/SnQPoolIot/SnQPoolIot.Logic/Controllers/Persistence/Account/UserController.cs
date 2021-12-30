//@GeneratedCode
namespace SnQPoolIot.Logic.Controllers.Persistence.Account
{
    sealed partial class UserController : GenericPersistenceController<SnQPoolIot.Contracts.Persistence.Account.IUser, Entities.Persistence.Account.User>
    {
        static UserController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        internal UserController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        internal UserController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            Constructed();
        }
    }
}
