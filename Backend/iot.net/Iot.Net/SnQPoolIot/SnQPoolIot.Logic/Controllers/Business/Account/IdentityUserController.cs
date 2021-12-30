//@GeneratedCode
namespace SnQPoolIot.Logic.Controllers.Business.Account
{
    sealed partial class IdentityUserController : GenericOneToAnotherController<SnQPoolIot.Contracts.Business.Account.IIdentityUser, Entities.Business.Account.IdentityUser, SnQPoolIot.Contracts.Persistence.Account.IIdentity, SnQPoolIot.Logic.Entities.Persistence.Account.Identity, SnQPoolIot.Contracts.Persistence.Account.IUser, SnQPoolIot.Logic.Entities.Persistence.Account.User>
    {
        static IdentityUserController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public IdentityUserController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            oneEntityController = new SnQPoolIot.Logic.Controllers.Persistence.Account.IdentityController(this);
            anotherEntityController = new SnQPoolIot.Logic.Controllers.Persistence.Account.UserController(this);
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public IdentityUserController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            oneEntityController = new SnQPoolIot.Logic.Controllers.Persistence.Account.IdentityController(this);
            anotherEntityController = new SnQPoolIot.Logic.Controllers.Persistence.Account.UserController(this);
            Constructed();
        }
        [Attributes.ControllerManagedField]
        private SnQPoolIot.Logic.Controllers.Persistence.Account.IdentityController oneEntityController = null;
        protected override GenericController<SnQPoolIot.Contracts.Persistence.Account.IIdentity, SnQPoolIot.Logic.Entities.Persistence.Account.Identity> OneEntityController
        {
            get => oneEntityController;
            set => oneEntityController = value as SnQPoolIot.Logic.Controllers.Persistence.Account.IdentityController;
        }
        [Attributes.ControllerManagedField]
        private SnQPoolIot.Logic.Controllers.Persistence.Account.UserController anotherEntityController = null;
        protected override GenericController<SnQPoolIot.Contracts.Persistence.Account.IUser, SnQPoolIot.Logic.Entities.Persistence.Account.User> AnotherEntityController
        {
            get => anotherEntityController;
            set => anotherEntityController = value as SnQPoolIot.Logic.Controllers.Persistence.Account.UserController;
        }
    }
}
