//@GeneratedCode
namespace SnQPoolIot.Logic.Entities.Persistence.PoolIot
{
    using System;
    partial class Sensor : SnQPoolIot.Contracts.Persistence.PoolIot.ISensor
    {
        static Sensor()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Sensor()
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
        public void CopyProperties(SnQPoolIot.Contracts.Persistence.PoolIot.ISensor other)
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
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.Persistence.PoolIot.ISensor other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.Persistence.PoolIot.ISensor other);
        public override bool Equals(object obj)
        {
            if (obj is not SnQPoolIot.Contracts.Persistence.PoolIot.ISensor instance)
            {
                return false;
            }
            return base.Equals(instance) && Equals(instance);
        }
        protected bool Equals(SnQPoolIot.Contracts.Persistence.PoolIot.ISensor other)
        {
            if (other == null)
            {
                return false;
            }
            return IsEqualsWith(Name, other.Name);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
        public static Persistence.PoolIot.Sensor Create()
        {
            BeforeCreate();
            var result = new Persistence.PoolIot.Sensor();
            AfterCreate(result);
            return result;
        }
        public static Persistence.PoolIot.Sensor Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.PoolIot.Sensor();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.PoolIot.Sensor Create(SnQPoolIot.Contracts.Persistence.PoolIot.ISensor other)
        {
            BeforeCreate(other);
            var result = new Persistence.PoolIot.Sensor();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.PoolIot.Sensor instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.PoolIot.Sensor instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.Persistence.PoolIot.ISensor other);
        static partial void AfterCreate(Persistence.PoolIot.Sensor instance, SnQPoolIot.Contracts.Persistence.PoolIot.ISensor other);
    }
}
