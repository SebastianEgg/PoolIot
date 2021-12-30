//@GeneratedCode
namespace SnQPoolIot.AspMvc.Models.Persistence.Account
{
    using System;
    public partial class ActionLog : SnQPoolIot.Contracts.Persistence.Account.IActionLog
    {
        static ActionLog()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public ActionLog()
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
        public System.DateTime Time
        {
            get;
            set;
        }
        public System.String Subject
        {
            get;
            set;
        }
        public System.String Action
        {
            get;
            set;
        }
        public System.String Info
        {
            get;
            set;
        }
        public void CopyProperties(SnQPoolIot.Contracts.Persistence.Account.IActionLog other)
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
                Time = other.Time;
                Subject = other.Subject;
                Action = other.Action;
                Info = other.Info;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.Persistence.Account.IActionLog other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.Persistence.Account.IActionLog other);
        public static Persistence.Account.ActionLog Create()
        {
            BeforeCreate();
            var result = new Persistence.Account.ActionLog();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Account.ActionLog Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Account.ActionLog();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Account.ActionLog Create(SnQPoolIot.Contracts.Persistence.Account.IActionLog other)
        {
            BeforeCreate(other);
            var result = new Persistence.Account.ActionLog();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Account.ActionLog instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Account.ActionLog instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.Persistence.Account.IActionLog other);
        static partial void AfterCreate(Persistence.Account.ActionLog instance, SnQPoolIot.Contracts.Persistence.Account.IActionLog other);
    }
}
