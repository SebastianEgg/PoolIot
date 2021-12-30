//@GeneratedCode
namespace SnQPoolIot.Logic.Entities.Persistence.Account
{
    using System;
    partial class IdentityXRole : SnQPoolIot.Contracts.Persistence.Account.IIdentityXRole
    {
        static IdentityXRole()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public IdentityXRole()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.Int32 IdentityId
        {
            get;
            set;
        }
        public System.Int32 RoleId
        {
            get;
            set;
        }
        public void CopyProperties(SnQPoolIot.Contracts.Persistence.Account.IIdentityXRole other)
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
                IdentityId = other.IdentityId;
                RoleId = other.RoleId;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.Persistence.Account.IIdentityXRole other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.Persistence.Account.IIdentityXRole other);
        public override bool Equals(object obj)
        {
            if (obj is not SnQPoolIot.Contracts.Persistence.Account.IIdentityXRole instance)
            {
                return false;
            }
            return base.Equals(instance) && Equals(instance);
        }
        protected bool Equals(SnQPoolIot.Contracts.Persistence.Account.IIdentityXRole other)
        {
            if (other == null)
            {
                return false;
            }
            return IdentityId == other.IdentityId
            && RoleId == other.RoleId;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(IdentityId, RoleId);
        }
        public static Persistence.Account.IdentityXRole Create()
        {
            BeforeCreate();
            var result = new Persistence.Account.IdentityXRole();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Account.IdentityXRole Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Account.IdentityXRole();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Account.IdentityXRole Create(SnQPoolIot.Contracts.Persistence.Account.IIdentityXRole other)
        {
            BeforeCreate(other);
            var result = new Persistence.Account.IdentityXRole();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Account.IdentityXRole instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Account.IdentityXRole instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.Persistence.Account.IIdentityXRole other);
        static partial void AfterCreate(Persistence.Account.IdentityXRole instance, SnQPoolIot.Contracts.Persistence.Account.IIdentityXRole other);
    }
}
