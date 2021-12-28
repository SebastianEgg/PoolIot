//@GeneratedCode
namespace SnQPoolIot.Transfer.Models.Persistence.PoolIot
{
    using System;
    public partial class SensorData : SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData
    {
        static SensorData()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public SensorData()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.String Value
        {
            get;
            set;
        }
        public System.Int32 SensorListID
        {
            get;
            set;
        }
        public System.String Timestamp
        {
            get;
            set;
        }
        public void CopyProperties(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData other)
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
                Value = other.Value;
                SensorListID = other.SensorListID;
                Timestamp = other.Timestamp;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData other);
        public static Persistence.PoolIot.SensorData Create()
        {
            BeforeCreate();
            var result = new Persistence.PoolIot.SensorData();
            AfterCreate(result);
            return result;
        }
        public static Persistence.PoolIot.SensorData Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.PoolIot.SensorData();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.PoolIot.SensorData Create(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData other)
        {
            BeforeCreate(other);
            var result = new Persistence.PoolIot.SensorData();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.PoolIot.SensorData instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.PoolIot.SensorData instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData other);
        static partial void AfterCreate(Persistence.PoolIot.SensorData instance, SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData other);
    }
}
