//@GeneratedCode
namespace SnQPoolIot.Adapters
{
    public static partial class Factory
    {
        public static Contracts.Client.IAdapterAccess<C> Create<C>()
        {
            Contracts.Client.IAdapterAccess<C> result = null;
            if (Adapter == AdapterType.Controller)
            {
                if (typeof(C) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData))
                {
                    result = new Controller.GenericControllerAdapter<SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData>() as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList))
                {
                    result = new Controller.GenericControllerAdapter<SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList>() as Contracts.Client.IAdapterAccess<C>;
                }
            }
            else if (Adapter == AdapterType.Service)
            {
                if (typeof(C) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData))
                {
                    result = new Service.GenericServiceAdapter<SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData, Transfer.Models.Persistence.PoolIot.SensorData>(BaseUri, "SensorDatas")
                    as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList))
                {
                    result = new Service.GenericServiceAdapter<SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList, Transfer.Models.Persistence.PoolIot.SensorList>(BaseUri, "SensorLists")
                    as Contracts.Client.IAdapterAccess<C>;
                }
            }
            return result;
        }
#if ACCOUNT_ON
        public static Contracts.Client.IAdapterAccess<C> Create<C>(string sessionToken)
        {
            Contracts.Client.IAdapterAccess<C> result = null;
            if (Adapter == AdapterType.Controller)
            {
                if (typeof(C) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData))
                {
                    result = new Controller.GenericControllerAdapter<SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList))
                {
                    result = new Controller.GenericControllerAdapter<SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList>(sessionToken) as Contracts.Client.IAdapterAccess<C>;
                }
            }
            else if (Adapter == AdapterType.Service)
            {
                if (typeof(C) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData))
                {
                    result = new Service.GenericServiceAdapter<SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData, Transfer.Models.Persistence.PoolIot.SensorData>(sessionToken, BaseUri, "SensorDatas") as Contracts.Client.IAdapterAccess<C>;
                }
                else if (typeof(C) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList))
                {
                    result = new Service.GenericServiceAdapter<SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList, Transfer.Models.Persistence.PoolIot.SensorList>(sessionToken, BaseUri, "SensorLists") as Contracts.Client.IAdapterAccess<C>;
                }
            }
            return result;
        }
#endif
    }
}
