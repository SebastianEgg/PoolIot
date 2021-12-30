//@GeneratedCode
namespace SnQPoolIot.Transfer.Models.Persistence.Account
{
    using System;
    public partial class User : SnQPoolIot.Contracts.Persistence.Account.IUser
    {
        static User()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public User()
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
        public System.String Firstname
        {
            get;
            set;
        }
        public System.String Lastname
        {
            get;
            set;
        }
        public void CopyProperties(SnQPoolIot.Contracts.Persistence.Account.IUser other)
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
                Firstname = other.Firstname;
                Lastname = other.Lastname;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.Persistence.Account.IUser other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.Persistence.Account.IUser other);
        public static Persistence.Account.User Create()
        {
            BeforeCreate();
            var result = new Persistence.Account.User();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Account.User Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Account.User();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Account.User Create(SnQPoolIot.Contracts.Persistence.Account.IUser other)
        {
            BeforeCreate(other);
            var result = new Persistence.Account.User();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Account.User instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Account.User instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.Persistence.Account.IUser other);
        static partial void AfterCreate(Persistence.Account.User instance, SnQPoolIot.Contracts.Persistence.Account.IUser other);
    }
}
