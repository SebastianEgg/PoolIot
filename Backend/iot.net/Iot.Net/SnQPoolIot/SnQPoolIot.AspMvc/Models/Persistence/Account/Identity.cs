//@GeneratedCode
namespace SnQPoolIot.AspMvc.Models.Persistence.Account
{
    using System;
    public partial class Identity : SnQPoolIot.Contracts.Persistence.Account.IIdentity
    {
        static Identity()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Identity()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.String Guid
        {
            get;
            set;
        }
        public System.String Name
        {
            get;
            set;
        }
        public System.String Email
        {
            get;
            set;
        }
        public System.String Password
        {
            get;
            set;
        }
        public System.Int32 TimeOutInMinutes
        {
            get;
            set;
        }
        = 30;
        public System.Boolean EnableJwtAuth
        {
            get;
            set;
        }
        public System.Int32 AccessFailedCount
        {
            get;
            set;
        }
        public SnQPoolIot.Contracts.Modules.Common.State State
        {
            get;
            set;
        }
        = Contracts.Modules.Common.State.Active;
        public void CopyProperties(SnQPoolIot.Contracts.Persistence.Account.IIdentity other)
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
                Guid = other.Guid;
                Name = other.Name;
                Email = other.Email;
                Password = other.Password;
                TimeOutInMinutes = other.TimeOutInMinutes;
                EnableJwtAuth = other.EnableJwtAuth;
                AccessFailedCount = other.AccessFailedCount;
                State = other.State;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.Persistence.Account.IIdentity other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.Persistence.Account.IIdentity other);
        public static Persistence.Account.Identity Create()
        {
            BeforeCreate();
            var result = new Persistence.Account.Identity();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Account.Identity Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Account.Identity();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Account.Identity Create(SnQPoolIot.Contracts.Persistence.Account.IIdentity other)
        {
            BeforeCreate(other);
            var result = new Persistence.Account.Identity();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Account.Identity instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Account.Identity instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.Persistence.Account.IIdentity other);
        static partial void AfterCreate(Persistence.Account.Identity instance, SnQPoolIot.Contracts.Persistence.Account.IIdentity other);
    }
}
