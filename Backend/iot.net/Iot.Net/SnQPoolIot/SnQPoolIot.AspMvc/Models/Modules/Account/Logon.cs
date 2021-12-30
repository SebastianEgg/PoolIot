//@GeneratedCode
namespace SnQPoolIot.AspMvc.Models.Modules.Account
{
    using System;
    public partial class Logon : SnQPoolIot.Contracts.Modules.Account.ILogon
    {
        static Logon()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Logon()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
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
        public System.String OptionalInfo
        {
            get;
            set;
        }
        public void CopyProperties(SnQPoolIot.Contracts.Modules.Account.ILogon other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Email = other.Email;
                Password = other.Password;
                OptionalInfo = other.OptionalInfo;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.Modules.Account.ILogon other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.Modules.Account.ILogon other);
        public static Modules.Account.Logon Create()
        {
            BeforeCreate();
            var result = new Modules.Account.Logon();
            AfterCreate(result);
            return result;
        }
        public static Modules.Account.Logon Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Modules.Account.Logon();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Modules.Account.Logon Create(SnQPoolIot.Contracts.Modules.Account.ILogon other)
        {
            BeforeCreate(other);
            var result = new Modules.Account.Logon();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Modules.Account.Logon instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Modules.Account.Logon instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.Modules.Account.ILogon other);
        static partial void AfterCreate(Modules.Account.Logon instance, SnQPoolIot.Contracts.Modules.Account.ILogon other);
    }
}
