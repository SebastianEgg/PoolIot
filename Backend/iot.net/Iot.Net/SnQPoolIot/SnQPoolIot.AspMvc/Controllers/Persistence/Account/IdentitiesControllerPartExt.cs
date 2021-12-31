//@CodeCopy
//MdStart
#if ACCOUNT_ON

using Microsoft.AspNetCore.Mvc;
using SnQPoolIot.AspMvc.Models.Persistence.Account;

namespace SnQPoolIot.AspMvc.Controllers.Persistence.Account
{
    public partial class IdentitiesController
    {
        protected override IActionResult ReturnAfterCreate(bool hasError, Identity model)
        {
            IActionResult result;

            if (hasError)
            {
                result = base.ReturnAfterCreate(hasError, model);
            }
            else
            {
                var redirectController = SessionWrapper.GetStringValue(StaticLiterals.RedirectControllerKey);

                if (string.IsNullOrEmpty(redirectController))
                {
                    result = RedirectToAction("Index", "IdentityUsers");
                }
                else
                {
                    SessionWrapper.SetStringValue(StaticLiterals.RedirectControllerKey, string.Empty);
                    result = RedirectToAction("Index", redirectController);
                }
            }
            return result;
        }
    }
}
#endif
//MdEnd
