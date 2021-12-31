//@GeneratedCode
namespace SnQPoolIot.AspMvc.Models.ThirdParty
{
    using System;
    public partial class HtmlItem : SnQPoolIot.Contracts.ThirdParty.IHtmlItem
    {
        static HtmlItem()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public HtmlItem()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.String AppName
        {
            get;
            set;
        }
        public System.String Key
        {
            get;
            set;
        }
        public System.String Description
        {
            get;
            set;
        }
        public System.String Content
        {
            get;
            set;
        }
        public SnQPoolIot.Contracts.Modules.Common.State State
        {
            get;
            set;
        }
        public void CopyProperties(SnQPoolIot.Contracts.ThirdParty.IHtmlItem other)
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
                AppName = other.AppName;
                Key = other.Key;
                Description = other.Description;
                Content = other.Content;
                State = other.State;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.ThirdParty.IHtmlItem other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.ThirdParty.IHtmlItem other);
        public static ThirdParty.HtmlItem Create()
        {
            BeforeCreate();
            var result = new ThirdParty.HtmlItem();
            AfterCreate(result);
            return result;
        }
        public static ThirdParty.HtmlItem Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new ThirdParty.HtmlItem();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static ThirdParty.HtmlItem Create(SnQPoolIot.Contracts.ThirdParty.IHtmlItem other)
        {
            BeforeCreate(other);
            var result = new ThirdParty.HtmlItem();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(ThirdParty.HtmlItem instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(ThirdParty.HtmlItem instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.ThirdParty.IHtmlItem other);
        static partial void AfterCreate(ThirdParty.HtmlItem instance, SnQPoolIot.Contracts.ThirdParty.IHtmlItem other);
    }
}
