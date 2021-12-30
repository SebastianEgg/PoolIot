//@GeneratedCode
namespace SnQPoolIot.Transfer.Models.Modules.Account
{
    using System;
    public partial class JsonWebLogon : SnQPoolIot.Contracts.Modules.Account.IJsonWebLogon
    {
        static JsonWebLogon()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public JsonWebLogon()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.String Token
        {
            get;
            set;
        }
        public void CopyProperties(SnQPoolIot.Contracts.Modules.Account.IJsonWebLogon other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Token = other.Token;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.Modules.Account.IJsonWebLogon other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.Modules.Account.IJsonWebLogon other);
        public static Modules.Account.JsonWebLogon Create()
        {
            BeforeCreate();
            var result = new Modules.Account.JsonWebLogon();
            AfterCreate(result);
            return result;
        }
        public static Modules.Account.JsonWebLogon Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Modules.Account.JsonWebLogon();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Modules.Account.JsonWebLogon Create(SnQPoolIot.Contracts.Modules.Account.IJsonWebLogon other)
        {
            BeforeCreate(other);
            var result = new Modules.Account.JsonWebLogon();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Modules.Account.JsonWebLogon instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Modules.Account.JsonWebLogon instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.Modules.Account.IJsonWebLogon other);
        static partial void AfterCreate(Modules.Account.JsonWebLogon instance, SnQPoolIot.Contracts.Modules.Account.IJsonWebLogon other);
    }
}
