//@GeneratedCode
namespace SnQPoolIot.AspMvc.Models.Business.Account
{
    using System;
    public partial class AppAccess : SnQPoolIot.Contracts.Business.Account.IAppAccess
    {
        static AppAccess()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public AppAccess()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public void CopyProperties(SnQPoolIot.Contracts.Business.Account.IAppAccess other)
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
                OneItem.CopyProperties(other.OneItem);
                ClearManyItems();
                foreach (var item in other.ManyItems)
                {
                    AddManyItem(item);
                }
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.Business.Account.IAppAccess other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.Business.Account.IAppAccess other);
        public static Business.Account.AppAccess Create()
        {
            BeforeCreate();
            var result = new Business.Account.AppAccess();
            AfterCreate(result);
            return result;
        }
        public static Business.Account.AppAccess Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Business.Account.AppAccess();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Business.Account.AppAccess Create(SnQPoolIot.Contracts.Business.Account.IAppAccess other)
        {
            BeforeCreate(other);
            var result = new Business.Account.AppAccess();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Business.Account.AppAccess instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Business.Account.AppAccess instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.Business.Account.IAppAccess other);
        static partial void AfterCreate(Business.Account.AppAccess instance, SnQPoolIot.Contracts.Business.Account.IAppAccess other);
    }
}
