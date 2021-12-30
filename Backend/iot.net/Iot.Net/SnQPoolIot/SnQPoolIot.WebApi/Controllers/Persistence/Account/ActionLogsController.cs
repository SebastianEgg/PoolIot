//@GeneratedCode
namespace SnQPoolIot.WebApi.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Account.IActionLog;
    using TModel = Transfer.Models.Persistence.Account.ActionLog;
    [ApiController]
    [Route("Controller")]
    public partial class ActionLogsController : WebApi.Controllers.GenericController<TContract, TModel>
    {
    }
}
