//@GeneratedCode
namespace SnQPoolIot.WebApi.Controllers.Business.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Business.Account.IAppAccess;
    using TModel = Transfer.Models.Business.Account.AppAccess;
    [ApiController]
    [Route("Controller")]
    public partial class AppAccessesController : WebApi.Controllers.GenericController<TContract, TModel>
    {
    }
}
