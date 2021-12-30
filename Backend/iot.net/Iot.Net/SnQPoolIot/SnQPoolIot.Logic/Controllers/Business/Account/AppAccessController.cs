//@GeneratedCode
namespace SnQPoolIot.Logic.Controllers.Business.Account
{
    [Logic.Modules.Security.Authorize("SysAdmin", "AppAdmin")]
    sealed partial class AppAccessController : GenericOneToManyController<SnQPoolIot.Contracts.Business.Account.IAppAccess, Entities.Business.Account.AppAccess, SnQPoolIot.Contracts.Persistence.Account.IIdentity, SnQPoolIot.Logic.Entities.Persistence.Account.Identity, SnQPoolIot.Contracts.Persistence.Account.IRole, SnQPoolIot.Logic.Entities.Persistence.Account.Role>
    {
        static AppAccessController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public AppAccessController(DataContext.IContext context)
        :base(context)
        {
            Constructing();
            oneEntityController = new SnQPoolIot.Logic.Controllers.Persistence.Account.IdentityController(this);
            manyEntityController = new SnQPoolIot.Logic.Controllers.Persistence.Account.RoleController(this);
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public AppAccessController(ControllerObject controller)
        :base(controller)
        {
            Constructing();
            oneEntityController = new SnQPoolIot.Logic.Controllers.Persistence.Account.IdentityController(this);
            manyEntityController = new SnQPoolIot.Logic.Controllers.Persistence.Account.RoleController(this);
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
        private SnQPoolIot.Logic.Controllers.Persistence.Account.RoleController manyEntityController = null;
        protected override GenericController<SnQPoolIot.Contracts.Persistence.Account.IRole, SnQPoolIot.Logic.Entities.Persistence.Account.Role> ManyEntityController
        {
            get => manyEntityController;
            set => manyEntityController = value as SnQPoolIot.Logic.Controllers.Persistence.Account.RoleController;
        }
    }
}
