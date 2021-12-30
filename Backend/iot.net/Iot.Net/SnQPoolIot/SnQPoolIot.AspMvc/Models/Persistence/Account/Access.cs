//@GeneratedCode
namespace SnQPoolIot.AspMvc.Models.Persistence.Account
{
    using System;
    public partial class Access : SnQPoolIot.Contracts.Persistence.Account.IAccess
    {
        static Access()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Access()
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
        public System.String Key
        {
            get;
            set;
        }
        public System.String Value
        {
            get;
            set;
        }
        = string.Empty;
        public void CopyProperties(SnQPoolIot.Contracts.Persistence.Account.IAccess other)
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
                IdentityId = other.IdentityId;
                Key = other.Key;
                Value = other.Value;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.Persistence.Account.IAccess other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.Persistence.Account.IAccess other);
        public static Persistence.Account.Access Create()
        {
            BeforeCreate();
            var result = new Persistence.Account.Access();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Account.Access Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Account.Access();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Account.Access Create(SnQPoolIot.Contracts.Persistence.Account.IAccess other)
        {
            BeforeCreate(other);
            var result = new Persistence.Account.Access();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Account.Access instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Account.Access instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.Persistence.Account.IAccess other);
        static partial void AfterCreate(Persistence.Account.Access instance, SnQPoolIot.Contracts.Persistence.Account.IAccess other);
    }
}
