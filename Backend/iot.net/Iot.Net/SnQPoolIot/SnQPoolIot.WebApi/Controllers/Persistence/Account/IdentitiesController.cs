//@GeneratedCode
namespace SnQPoolIot.WebApi.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Account.IIdentity;
    using TModel = Transfer.Models.Persistence.Account.Identity;
    [ApiController]
    [Route("Controller")]
    public partial class IdentitiesController : WebApi.Controllers.GenericController<TContract, TModel>
    {
    }
}
