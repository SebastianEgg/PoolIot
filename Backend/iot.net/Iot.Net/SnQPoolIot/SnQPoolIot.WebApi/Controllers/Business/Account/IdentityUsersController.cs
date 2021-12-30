//@GeneratedCode
namespace SnQPoolIot.WebApi.Controllers.Business.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Business.Account.IIdentityUser;
    using TModel = Transfer.Models.Business.Account.IdentityUser;
    [ApiController]
    [Route("Controller")]
    public partial class IdentityUsersController : WebApi.Controllers.GenericController<TContract, TModel>
    {
    }
}
