//@GeneratedCode
namespace SnQPoolIot.Transfer.Models.Persistence.Account
{
    using System;
    public partial class Role : SnQPoolIot.Contracts.Persistence.Account.IRole
    {
        static Role()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Role()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.String Designation
        {
            get;
            set;
        }
        public System.String Description
        {
            get;
            set;
        }
        public void CopyProperties(SnQPoolIot.Contracts.Persistence.Account.IRole other)
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
                Designation = other.Designation;
                Description = other.Description;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.Persistence.Account.IRole other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.Persistence.Account.IRole other);
        public static Persistence.Account.Role Create()
        {
            BeforeCreate();
            var result = new Persistence.Account.Role();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Account.Role Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Account.Role();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Account.Role Create(SnQPoolIot.Contracts.Persistence.Account.IRole other)
        {
            BeforeCreate(other);
            var result = new Persistence.Account.Role();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Account.Role instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Account.Role instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.Persistence.Account.IRole other);
        static partial void AfterCreate(Persistence.Account.Role instance, SnQPoolIot.Contracts.Persistence.Account.IRole other);
    }
}
