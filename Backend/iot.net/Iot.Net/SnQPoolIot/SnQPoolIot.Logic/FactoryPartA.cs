//@GeneratedCode
namespace SnQPoolIot.Logic
{
    public static partial class Factory
    {
        static partial void CreateController<C>(ref Contracts.Client.IControllerAccess<C> controller) where C : Contracts.IIdentifiable
        {
            if (typeof(C) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData))
            {
                controller = new Controllers.Persistence.PoolIot.SensorDataController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList))
            {
                controller = new Controllers.Persistence.PoolIot.SensorListController(CreateContext()) as Contracts.Client.IControllerAccess<C>;
            }
            else
            {
                throw new Logic.Modules.Exception.LogicException(Modules.Exception.ErrorType.InvalidControllerType);
            }
        }
        static partial void CreateController<C>(object sharedController, ref Contracts.Client.IControllerAccess<C> controller) where C : Contracts.IIdentifiable
        {
            if (typeof(C) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData))
            {
                controller = new Controllers.Persistence.PoolIot.SensorDataController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList))
            {
                controller = new Controllers.Persistence.PoolIot.SensorListController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<C>;
            }
            else
            {
                throw new Logic.Modules.Exception.LogicException(Modules.Exception.ErrorType.InvalidControllerType);
            }
        }
#if ACCOUNT_ON
        public static void CreateController<C>(string sessionToken, ref Contracts.Client.IControllerAccess<C> controller) where C : Contracts.IIdentifiable
        {
            if (typeof(C) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData))
            {
                controller = new Controllers.Persistence.PoolIot.SensorDataController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else if (typeof(C) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList))
            {
                controller = new Controllers.Persistence.PoolIot.SensorListController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<C>;
            }
            else
            {
                throw new Logic.Modules.Exception.LogicException(Modules.Exception.ErrorType.InvalidControllerType);
            }
        }
#endif
    }
}
