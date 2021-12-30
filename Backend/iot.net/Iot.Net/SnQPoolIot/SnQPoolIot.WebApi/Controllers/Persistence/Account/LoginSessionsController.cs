//@GeneratedCode
namespace SnQPoolIot.WebApi.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Account.ILoginSession;
    using TModel = Transfer.Models.Persistence.Account.LoginSession;
    [ApiController]
    [Route("Controller")]
    public partial class LoginSessionsController : WebApi.Controllers.GenericController<TContract, TModel>
    {
    }
}
