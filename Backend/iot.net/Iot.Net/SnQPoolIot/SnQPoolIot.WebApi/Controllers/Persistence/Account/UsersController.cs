//@GeneratedCode
namespace SnQPoolIot.WebApi.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Account.IUser;
    using TModel = Transfer.Models.Persistence.Account.User;
    [ApiController]
    [Route("Controller")]
    public partial class UsersController : WebApi.Controllers.GenericController<TContract, TModel>
    {
    }
}
