//@GeneratedCode
namespace SnQPoolIot.AspMvc.Models.ThirdParty
{
    using System;
    public partial class Translation : SnQPoolIot.Contracts.ThirdParty.ITranslation
    {
        static Translation()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Translation()
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
        public SnQPoolIot.Contracts.Modules.Common.LanguageCode KeyLanguage
        {
            get;
            set;
        }
        public System.String Key
        {
            get;
            set;
        }
        public SnQPoolIot.Contracts.Modules.Common.LanguageCode ValueLanguage
        {
            get;
            set;
        }
        public System.String Value
        {
            get;
            set;
        }
        public void CopyProperties(SnQPoolIot.Contracts.ThirdParty.ITranslation other)
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
                KeyLanguage = other.KeyLanguage;
                Key = other.Key;
                ValueLanguage = other.ValueLanguage;
                Value = other.Value;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.ThirdParty.ITranslation other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.ThirdParty.ITranslation other);
        public static ThirdParty.Translation Create()
        {
            BeforeCreate();
            var result = new ThirdParty.Translation();
            AfterCreate(result);
            return result;
        }
        public static ThirdParty.Translation Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new ThirdParty.Translation();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static ThirdParty.Translation Create(SnQPoolIot.Contracts.ThirdParty.ITranslation other)
        {
            BeforeCreate(other);
            var result = new ThirdParty.Translation();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(ThirdParty.Translation instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(ThirdParty.Translation instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.ThirdParty.ITranslation other);
        static partial void AfterCreate(ThirdParty.Translation instance, SnQPoolIot.Contracts.ThirdParty.ITranslation other);
    }
}
