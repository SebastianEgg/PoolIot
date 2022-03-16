//@CodeCopy
//MdStart
#if ACCOUNT_ON
using Microsoft.AspNetCore.Mvc;
using SnQPoolIot.Contracts.Client;
using SnQPoolIot.Contracts.Persistence.Account;
using SnQPoolIot.Transfer.Models.Modules.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnQPoolIot.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public partial class AccountController : ControllerBase
    {
        private IAccountManager accountManager = null;
        private IAccountManager AccountManager => accountManager ??= Logic.Factory.CreateAccountManager();
        private static ILoginSession ConvertTo(ILoginSession loginSession)
        {
            var result = new Transfer.Models.Persistence.Account.LoginSession();

            result.CopyProperties(loginSession);
            return result;
        }
        /// <summary>
        /// Dieser Request dient zum Einloggen mittels Session Token. Ohne, dass sich der Benutzer vorher einloggt kann er keine Daten sehen.
        /// </summary>
        /// <param name="logon"></param>
        /// <returns></returns>
        [HttpPost("/api/[controller]/Logon")]
        public async Task<ILoginSession> LogonAsync([FromBody] Logon logon)
        {
            return ConvertTo(await AccountManager.LogonAsync(logon.Email, logon.Password, logon.OptionalInfo).ConfigureAwait(false));
        }
        /// <summary>
        /// Dieser Request dient zum Ermitteln von einer Session, wo man sehen kann welcher User wann und wo eingeloggt wurde.
        /// </summary>
        /// <param name="logon"></param>
        /// <returns></returns>
        [HttpPost("/api/[controller]/JsonWebLogon")]
        public async Task<ILoginSession> JsonWebLogonAsync([FromBody] JsonWebLogon logon)
        {
            return ConvertTo(await AccountManager.LogonAsync(logon.Token).ConfigureAwait(false));
        }
        /// <summary>
        /// Dieser Request dient zum Ausloggen von einem User.
        /// </summary>
        /// <param name="sessionToken"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/Logout/{sessionToken}")]
        public Task LogoutAsync(string sessionToken)
        {
            return AccountManager.LogoutAsync(sessionToken);
        }
        /// <summary>
        /// Dieser Request dient zum Ändern von dem Passwort des gerade eingeloggten Users.
        /// </summary>
        /// <param name="sessionToken"></param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/ChangePassword/{sessionToken}/{oldPwd}/{newPwd}")]
        public Task ChangePasswordAsync(string sessionToken, string oldPwd, string newPwd)
        {
            return AccountManager.ChangePasswordAsync(sessionToken, oldPwd, newPwd);
        }
        /// <summary>
        /// Dieser Request dient zum Ändern von einem Passwort eines Users, mittels E-Mails und Passworts des User’s.
        /// </summary>
        /// <param name="sessionToken"></param>
        /// <param name="email"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/ChangePasswordFor/{sessionToken}/{email}/{newPwd}")]
        public Task ChangePasswordForAsync(string sessionToken, string email, string newPwd)
        {
            return AccountManager.ChangePasswordForAsync(sessionToken, email, newPwd);
        }
        /// <summary>
        /// Dieser Request zeigt an, wenn ein Reset von einem Passwort eines User's fehlgeschlagen hat. 
        /// </summary>
        /// <param name="sessionToken"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/ResetFailedCountFor/{sessionToken}/{email}")]
        public Task ResetFailedCountForAsync(string sessionToken, string email)
        {
            return AccountManager.ResetFailedCountForAsync(sessionToken, email);
        }
        /// <summary>
        /// Dieser Request dient zum Kontrollieren von der Rolle eines User’s.
        /// </summary>
        /// <param name="sessionToken"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/HasRole/{sessionToken}/{role}")]
        public Task<bool> HasRoleAsync(string sessionToken, string role)
        {
            return AccountManager.HasRoleAsync(sessionToken, role);
        }
        /// <summary>
        /// Dieser Request dient zum Kontrollieren, ob die Session noch gültig ist.
        /// </summary>
        /// <param name="sessionToken"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/IsSessionAlive/{sessionToken}")]
        public Task<bool> IsSessionAliveAsync(string sessionToken)
        {
            return AccountManager.IsSessionAliveAsync(sessionToken);
        }
        /// <summary>
        /// Dieser Request gibt alle Rollen dieser Session zurück.
        /// </summary>
        /// <param name="sessionToken"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/QueryRoles/{sessionToken}")]
        public Task<IEnumerable<string>> QueryRolesAsync(string sessionToken)
        {
            return AccountManager.QueryRolesAsync(sessionToken);
        }
        /// <summary>
        /// Dieser Request dient zum Ermitteln vom eingeloggten User.
        /// </summary>
        /// <param name="sessionToken"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/QueryLogin/{sessionToken}")]
        public async Task<ILoginSession> QueryLoginAsync(string sessionToken)
        {
            return ConvertTo(await AccountManager.QueryLoginAsync(sessionToken).ConfigureAwait(false));
        }
    }
}
#endif
//MdEnd
