//@GeneratedCode
namespace SnQPoolIot.Transfer.Models.Persistence.PoolIot
{
    using System;
    public partial class SensorList : SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList
    {
        static SensorList()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public SensorList()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.String Name
        {
            get;
            set;
        }
        public System.Int32 SensorID
        {
            get;
            set;
        }
        public void CopyProperties(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Id = other.Id;
                RowVersion = other.RowVersion;
                Name = other.Name;
                SensorID = other.SensorID;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList other);
        public static Persistence.PoolIot.SensorList Create()
        {
            BeforeCreate();
            var result = new Persistence.PoolIot.SensorList();
            AfterCreate(result);
            return result;
        }
        public static Persistence.PoolIot.SensorList Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.PoolIot.SensorList();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.PoolIot.SensorList Create(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList other)
        {
            BeforeCreate(other);
            var result = new Persistence.PoolIot.SensorList();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.PoolIot.SensorList instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.PoolIot.SensorList instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList other);
        static partial void AfterCreate(Persistence.PoolIot.SensorList instance, SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList other);
    }
}
