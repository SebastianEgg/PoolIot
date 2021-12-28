//@GeneratedCode
namespace SnQPoolIot.Logic.Entities.Persistence.PoolIot
{
    using System;
    partial class SensorData : SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData
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
        public override bool Equals(object obj)
        {
            if (obj is not SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData instance)
            {
                return false;
            }
            return base.Equals(instance) && Equals(instance);
        }
        protected bool Equals(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData other)
        {
            if (other == null)
            {
                return false;
            }
            return IsEqualsWith(Value, other.Value)
            && SensorListID == other.SensorListID
            && IsEqualsWith(Timestamp, other.Timestamp);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Value, SensorListID, Timestamp);
        }
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
