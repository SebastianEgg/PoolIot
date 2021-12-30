//@GeneratedCode
namespace SnQPoolIot.AspMvc.Models.Persistence.Account
{
    using System;
    public partial class LoginSession : SnQPoolIot.Contracts.Persistence.Account.ILoginSession
    {
        static LoginSession()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public LoginSession()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.Int32 IdentityId
        {
            get
            {
                OnIdentityIdReading();
                return _identityId;
            }
            set
            {
                bool handled = false;
                OnIdentityIdChanging(ref handled, ref _identityId);
                if (handled == false)
                {
                    _identityId = value;
                }
                OnIdentityIdChanged();
            }
        }
        private System.Int32 _identityId;
        partial void OnIdentityIdReading();
        partial void OnIdentityIdChanging(ref bool handled, ref System.Int32 _identityId);
        partial void OnIdentityIdChanged();
        public System.Boolean IsRemoteAuth
        {
            get;
            set;
        }
        public System.String Origin
        {
            get
            {
                OnOriginReading();
                return _origin;
            }
            set
            {
                bool handled = false;
                OnOriginChanging(ref handled, ref _origin);
                if (handled == false)
                {
                    _origin = value;
                }
                OnOriginChanged();
            }
        }
        private System.String _origin;
        partial void OnOriginReading();
        partial void OnOriginChanging(ref bool handled, ref System.String _origin);
        partial void OnOriginChanged();
        public System.String Name
        {
            get
            {
                OnNameReading();
                return _name;
            }
            set
            {
                bool handled = false;
                OnNameChanging(ref handled, ref _name);
                if (handled == false)
                {
                    _name = value;
                }
                OnNameChanged();
            }
        }
        private System.String _name;
        partial void OnNameReading();
        partial void OnNameChanging(ref bool handled, ref System.String _name);
        partial void OnNameChanged();
        public System.String Email
        {
            get
            {
                OnEmailReading();
                return _email;
            }
            set
            {
                bool handled = false;
                OnEmailChanging(ref handled, ref _email);
                if (handled == false)
                {
                    _email = value;
                }
                OnEmailChanged();
            }
        }
        private System.String _email;
        partial void OnEmailReading();
        partial void OnEmailChanging(ref bool handled, ref System.String _email);
        partial void OnEmailChanged();
        public System.Int32 TimeOutInMinutes
        {
            get
            {
                OnTimeOutInMinutesReading();
                return _timeOutInMinutes;
            }
            set
            {
                bool handled = false;
                OnTimeOutInMinutesChanging(ref handled, ref _timeOutInMinutes);
                if (handled == false)
                {
                    _timeOutInMinutes = value;
                }
                OnTimeOutInMinutesChanged();
            }
        }
        private System.Int32 _timeOutInMinutes;
        partial void OnTimeOutInMinutesReading();
        partial void OnTimeOutInMinutesChanging(ref bool handled, ref System.Int32 _timeOutInMinutes);
        partial void OnTimeOutInMinutesChanged();
        public System.String JsonWebToken
        {
            get;
            set;
        }
        public System.String SessionToken
        {
            get;
            set;
        }
        public System.DateTime LoginTime
        {
            get;
            set;
        }
        public System.DateTime LastAccess
        {
            get
            {
                OnLastAccessReading();
                return _lastAccess;
            }
            set
            {
                bool handled = false;
                OnLastAccessChanging(ref handled, ref _lastAccess);
                if (handled == false)
                {
                    _lastAccess = value;
                }
                OnLastAccessChanged();
            }
        }
        private System.DateTime _lastAccess;
        partial void OnLastAccessReading();
        partial void OnLastAccessChanging(ref bool handled, ref System.DateTime _lastAccess);
        partial void OnLastAccessChanged();
        public System.DateTime? LogoutTime
        {
            get
            {
                OnLogoutTimeReading();
                return _logoutTime;
            }
            set
            {
                bool handled = false;
                OnLogoutTimeChanging(ref handled, ref _logoutTime);
                if (handled == false)
                {
                    _logoutTime = value;
                }
                OnLogoutTimeChanged();
            }
        }
        private System.DateTime? _logoutTime;
        partial void OnLogoutTimeReading();
        partial void OnLogoutTimeChanging(ref bool handled, ref System.DateTime? _logoutTime);
        partial void OnLogoutTimeChanged();
        public System.String OptionalInfo
        {
            get;
            set;
        }
        public void CopyProperties(SnQPoolIot.Contracts.Persistence.Account.ILoginSession other)
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
                IsRemoteAuth = other.IsRemoteAuth;
                Origin = other.Origin;
                Name = other.Name;
                Email = other.Email;
                TimeOutInMinutes = other.TimeOutInMinutes;
                JsonWebToken = other.JsonWebToken;
                SessionToken = other.SessionToken;
                LoginTime = other.LoginTime;
                LastAccess = other.LastAccess;
                LogoutTime = other.LogoutTime;
                OptionalInfo = other.OptionalInfo;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQPoolIot.Contracts.Persistence.Account.ILoginSession other, ref bool handled);
        partial void AfterCopyProperties(SnQPoolIot.Contracts.Persistence.Account.ILoginSession other);
        public static Persistence.Account.LoginSession Create()
        {
            BeforeCreate();
            var result = new Persistence.Account.LoginSession();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Account.LoginSession Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Account.LoginSession();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Account.LoginSession Create(SnQPoolIot.Contracts.Persistence.Account.ILoginSession other)
        {
            BeforeCreate(other);
            var result = new Persistence.Account.LoginSession();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Account.LoginSession instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Account.LoginSession instance, object other);
        static partial void BeforeCreate(SnQPoolIot.Contracts.Persistence.Account.ILoginSession other);
        static partial void AfterCreate(Persistence.Account.LoginSession instance, SnQPoolIot.Contracts.Persistence.Account.ILoginSession other);
    }
}
