//@CodeCopy
//MdStart
#if ACCOUNT_ON
using SnQPoolIot.Contracts.Client;
using SnQPoolIot.Contracts.Persistence.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnQPoolIot.Logic.Modules.Account
{
    internal partial class AccountManagerWrapper : IAccountManager
    {
        #region Public logon
        public Task InitAppAccessAsync(string name, string email, string password, bool enableJwtAuth)
        {
            return AccountManager.InitAppAccessAsync(name, email, password, enableJwtAuth);
        }
        //Die Methoden LogonAsync dienen zum asynchronen Einloggen von Benutzern mit unterschiedlichen Parametern
        public Task<ILoginSession> LogonAsync(string jsonWebToken)
        {
            return AccountManager.LogonAsync(jsonWebToken);
        }
        public Task<ILoginSession> LogonAsync(string email, string password)
        {
            return LogonAsync(email, password, string.Empty);
        }
        public Task<ILoginSession> LogonAsync(string email, string password, string optionalInfo)
        {
            return AccountManager.LogonAsync(email, password, optionalInfo);
        }
        //Die Methoden LogoutAsync dienen zum asynchronen Ausloggen von Benutzern mit unterschiedlichen Parametern
        public Task LogoutAsync(string sessionToken)
        {
            return AccountManager.LogoutAsync(sessionToken);
        }
        // Überprüft asynchron die Rolle des eingeloggten Users.
        public Task<IEnumerable<string>> QueryRolesAsync(string sessionToken)
        {
            return AccountManager.QueryRolesAsync(sessionToken);
        }
        // Überprüft asynchron eine Rolle in der Datenbank
        public Task<bool> HasRoleAsync(string sessionToken, string role)
        {
            return AccountManager.HasRoleAsync(sessionToken, role);
        }
        // 
        public Task<ILoginSession> QueryLoginAsync(string sessionToken)
        {
            return AccountManager.QueryLoginAsync(sessionToken);
        }
        // Diese Methode überprüft asynchron, ob eine Session noch gültig ist.
        public Task<bool> IsSessionAliveAsync(string sessionToken)
        {
            return AccountManager.IsSessionAliveAsync(sessionToken);
        }
        // Diese Methode ändert asynchron das Passwort eines User.
        public Task ChangePasswordAsync(string sessionToken, string oldPassword, string newPassword)
        {
            return AccountManager.ChangePasswordAsync(sessionToken, oldPassword, newPassword);
        }
        // Diese Methode ändert asynchron das Passwort eines User über die E-Mail.
        public Task ChangePasswordForAsync(string sessionToken, string email, string newPassword)
        {
            return AccountManager.ChangePasswordForAsync(sessionToken, email, newPassword);
        }
        public Task ResetFailedCountForAsync(string sessionToken, string email)
        {
            return AccountManager.ResetFailedCountForAsync(sessionToken, email);
        }
        #endregion Public logon
    }
}
#endif
//MdEnd
